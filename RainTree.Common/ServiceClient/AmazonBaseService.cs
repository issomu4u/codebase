using CsvHelper;
using RainTree.Common.Exceptions;
using RainTree.Common.Extentions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RainTree.Common.ServiceClient
{
    public interface IAmazonBaseService
    {
        bool ConfigureRetry();

    }
    public class AmazonBaseService : IAmazonBaseService
    {
      //  protected static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// This is used to post/get to the different uris used by amazon per api
        /// ie. /Orders/2011-01-01
        /// </summary>
        public virtual string URI { get { return "/"; } }

        /// <summary>
        /// The API version varies in most amazon APIs
        /// </summary>
        public virtual string VERSION { get { return "2009-01-01"; } }

        /// <summary>
        /// There seem to be some xml namespace issues. therefore every api subclass
        /// like so AmazonAPISubclass.NS.
        /// For more information see http://stackoverflow.com/a/8719461/389453
        /// </summary>
        public virtual string NS { get { return ""; } }

        /// <summary>
        /// # Some APIs are available only to either a "Merchant" or "Seller"
        /// the type of account needs to be sent in every call to the amazon MWS.
        /// for the specific API being used.
        /// All subclasses need to public wrapper this if they require another account type
        /// like "Merchant" in which case you public it like so.
        /// ACCOUNT_TYPE = "Merchant"
        /// Which is the name of the parameter for that specific account type.
        /// </summary>
        public virtual string ACCOUNT_TYPE { get { return "SellerId"; } }

        private string accessKey;
        private string secretKey;
        private string accountId;
        private string domain;
        private string uri;
        private string version;
        public bool ScheduleRetry { get; private set; }
        public AmazonBaseService(string accessKey, string secretKey, string accountId,
            string domain = null, string uri = null, string version = null)
        {
            this.accessKey = accessKey;
            this.secretKey = secretKey;
            this.accountId = accountId;
            this.domain = domain ?? "https://mws.amazonservices.in";
            this.uri = uri ?? URI;
            this.version = version ?? VERSION;
        }

        public bool ConfigureRetry()
        {
            return ScheduleRetry;
        }

        /// <summary>
        /// Make request to Amazon MWS API with these parameters
        /// </summary>
        /// <param name="filterParams"></param>
        /// <param name="method"></param>
        /// <param name="extraHeaders"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        protected T GetResponseFromXml<T>(IDictionary<string, string> filterParams,
                    string method, IDictionary<HttpRequestHeader, string> extraHeaders = null,
                    string body = null)
        {
            ScheduleRetry = true;

            try
            {
                var url = PrepareUrl(filterParams, method);

                var request = InitilizeWebRequest(url, method, extraHeaders, body);

                var response = request.GetResponse();
                ScheduleRetry = false;
                return ProcessResponseXmlMessage<T>(response);
            }
            catch (WebException we)
            {
                ScheduleRetry = HandleException(we);
            }

            return default(T);

        }


        /// <summary>
        /// Get report data
        /// </summary>
        /// <param name="filterParams"></param>
        /// <param name="method"></param>
        /// <param name="extraHeaders"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        protected string GetReportData(IDictionary<string, string> filterParams,
                    string method, IDictionary<HttpRequestHeader, string> extraHeaders = null,
                    string body = null)
        {
            ScheduleRetry = true;

            try
            {
                var url = PrepareUrl(filterParams, method);

                var request = InitilizeWebRequest(url, method, extraHeaders, body);
                var responseBody = string.Empty;

                using (var reader = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8))
                {
                    responseBody = reader.ReadToEnd();
                }

                ScheduleRetry = false;
                return responseBody;
            }
            catch (WebException we)
            {
                ScheduleRetry = HandleException(we);
            }

            return default(string);
        }

        /// <summary>
        /// Make request to Amazon MWS API with these parameters
        /// </summary>
        /// <param name="filterParams"></param>
        /// <param name="method"></param>
        /// <param name="extraHeaders"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        protected IEnumerable<T> GetResponseFromCsv<T>(IDictionary<string, string> filterParams,
            string method,
            CsvHelper.Configuration.Configuration csvConfiguration,
            IDictionary<HttpRequestHeader, string> extraHeaders = null,
            string body = null)
        {
            ScheduleRetry = true;

            try
            {
                var url = PrepareUrl(filterParams, method);

                var request = InitilizeWebRequest(url, method, extraHeaders, body);

                IEnumerable<T> result;

                using (var reader = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8))
                using (var csv = new CsvReader(reader, csvConfiguration))
                {
                    csv.Configuration.MissingFieldFound = null;
                    csv.Configuration.HeaderValidated = null;
                    csv.Configuration.Encoding = Encoding.UTF8;
                    var rec = csv.GetRecords<T>();

                    result = rec.ToList();
                }

                ScheduleRetry = false;
                return result;
            }
            catch (WebException we)
            {
                ScheduleRetry = HandleException(we);
            }


            return default(IEnumerable<T>);

        }

        private string PrepareUrl(IDictionary<string, string> filterParams, string method)
        {
            var qParams = new Dictionary<string, string>(){
                {"AWSAccessKeyId", this.accessKey},
                {"Action", ""},
               // {"Marketplace","A21TJRUUN4KGV" },
            };

            qParams.Update(filterParams.Where(i => !string.IsNullOrEmpty(i.Value)).ToDictionary(p => p.Key, p => p.Value));

            var additionalParams = new Dictionary<string, string>() {
                { ACCOUNT_TYPE, this.accountId },
                { "SignatureMethod", "HmacSHA256"},
                { "SignatureVersion", "2"},
                { "Timestamp", this.GetTimestamp()},
                { "Version", this.version}};


            qParams.Update(additionalParams);

            //TODO add encode('utf-8')
            var requestDescription = string.Join("&",
                from param in qParams
                select
                    string.Format("{0}={1}",
                        param.Key, Uri.EscapeDataString(param.Value)));

            var signature = this.CalcSignature(method, requestDescription);

            var url = string.Format("{0}{1}?{2}&Signature={3}",
                this.domain, this.uri, requestDescription, Uri.EscapeDataString(signature));

           // Log.Debug($"Prepaired url : {url}");
            return url;
        }

        private HttpWebRequest InitilizeWebRequest(string url, string method, IDictionary<HttpRequestHeader, string> extraHeaders = null, string body = null)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = method;
            request.UserAgent = "csharp-amazon-mws/1.1.0 (Language=CSharp)";
            request.Timeout = 50000;
            request.ContentType = "application/x-www-form-urlencoded; charset=utf-8";

            if (extraHeaders != null)
                foreach (var x in extraHeaders)
                    request.Headers.Add(x.Key, x.Value);

            if (!string.IsNullOrEmpty(body))
            {
                var dataStream = request.GetRequestStream();
                var bytes = Encoding.UTF8.GetBytes(body);
                dataStream.Write(bytes, 0, body.Length);
                dataStream.Close();
            }

            return request;
        }

        private bool HandleException(WebException we)
        {
            //Log.Error(we);

            var scheduleRetry = false;
            using (HttpWebResponse httpErrorResponse = (HttpWebResponse)we.Response as HttpWebResponse)
            {
                if (httpErrorResponse == null)
                {
                    return true;
                }

                var statusCode = httpErrorResponse.StatusCode;

                var reader = new StreamReader(httpErrorResponse.GetResponseStream(), Encoding.UTF8);
                var responseBody = reader.ReadToEnd();

                //Log.Debug($"Amazon Exception : responseBody : {responseBody} ");

                //var res = ProcessResponseXmlMessage<AmazonErrorResponse>(httpErrorResponse.GetResponseStream());
                var res = ProcessResponseXmlMessage<AmazonErrorResponse>(new StringReader(responseBody));

                //Log.Debug($"Amazon Exception : Code : {res?.Error?.Code} , Type : {res?.Error?.Type} , Message : {res?.Error?.Message} ");
                scheduleRetry = (statusCode == HttpStatusCode.InternalServerError || statusCode == HttpStatusCode.ServiceUnavailable);
                // throw new AdapterException("Amazon", ExceptionCode.InvalidPayLoad, res.Error.Message);
            }

            return scheduleRetry;
        }

        private TResult ProcessResponseXmlMessage<TResult>(WebResponse response)
        {
            //if ((response.StatusCode == HttpStatusCode.Redirect) ||
            //    (response.StatusCode == HttpStatusCode.SeeOther) ||
            //    (response.StatusCode == HttpStatusCode.RedirectMethod))
            // return await GetResponseV1<TResult>();
            using (response)
            {
                var xmlSerializer = new XmlSerializer(typeof(TResult));
                return (response.ContentLength == 0)
                    ? default(TResult)
                    : (TResult)xmlSerializer.Deserialize(response.GetResponseStream());
            }

        }

        private TResult ProcessResponseXmlMessage<TResult>(Stream response)
        {
            //if ((response.StatusCode == HttpStatusCode.Redirect) ||
            //    (response.StatusCode == HttpStatusCode.SeeOther) ||
            //    (response.StatusCode == HttpStatusCode.RedirectMethod))
            // return await GetResponseV1<TResult>();
            using (response)
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("aaa", "https://mws.amazonservices.com/Orders/2013-09-01");
                ns.Add("bbb", "http://www.bbb.com");
                ns.Add("ccc", "http://www.ccc.com");

                var xmlSerializer = new XmlSerializer(typeof(TResult));
                return (TResult)xmlSerializer.Deserialize(response);
            }

        }

        private TResult ProcessResponseXmlMessage<TResult>(StringReader response)
        {
            using (response)
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("aaa", "https://mws.amazonservices.com/Orders/2013-09-01");
                ns.Add("bbb", "http://www.bbb.com");
                ns.Add("ccc", "http://www.ccc.com");

                var xmlSerializer = new XmlSerializer(typeof(TResult));
                return (TResult)xmlSerializer.Deserialize(response);
            }

        }

        /// <summary>
        /// Make request to Amazon MWS API with these parameters
        /// </summary>
        /// <param name="extraData"></param>
        /// <param name="method"></param>
        /// <param name="extraHeaders"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<string> GetResponseAsync(IDictionary<string, string> extraData,
            string method = WebRequestMethods.Http.Post, IDictionary<HttpRequestHeader, string> extraHeaders = null,
            string body = null)
        {
            var qParams = new Dictionary<string, string>(){
                {"AWSAccessKeyId", this.accessKey},
                {"Action", "GetReportList"},
               // {"Marketplace","A21TJRUUN4KGV" },
                {ACCOUNT_TYPE, this.accountId},
                {"SignatureMethod", "HmacSHA256"},
                {"SignatureVersion", "2"},
                {"Timestamp", this.GetTimestamp()},
                {"Version", this.version}

            };
            qParams.Update(extraData.Where(i => !string.IsNullOrEmpty(i.Value)).ToDictionary(p => p.Key, p => p.Value));

            //TODO add encode('utf-8')
            var requestDescription = string.Join("&",
                from param in qParams
                select
                    string.Format("{0}={1}",
                        param.Key, Uri.EscapeDataString(param.Value)));

            //  requestDescription = "AWSAccessKeyId=AKIAIJJRZU64IB3R5YQQ&Action=GetReportList&Merchant=A89M6K3D9CYQY&SignatureMethod=HmacSHA256&SignatureVersion=2&Timestamp=2018-05-07T16%3A12%3A16Z&Version=2009-01-01";
            var signature = this.CalcSignature(method, requestDescription);

            var url = string.Format("{0}{1}?{2}&Signature={3}",
                this.domain, this.uri, requestDescription, Uri.EscapeDataString(signature));


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("text/xml"))
                  ;//ACCEPT header

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "");
            if (extraHeaders != null)
                foreach (var x in extraHeaders)
                    request.Headers.Add(x.Key.ToString(), x.Value);

            var response = await client.PostAsync(url, null).ConfigureAwait(false);

            return await ProcessResponseXmlMessage<string>(response);
        }


        private async Task<TResult> ProcessResponseXmlMessage<TResult>(HttpResponseMessage response)
        {
            //if ((response.StatusCode == HttpStatusCode.Redirect) ||
            //    (response.StatusCode == HttpStatusCode.SeeOther) ||
            //    (response.StatusCode == HttpStatusCode.RedirectMethod))
            // return await GetResponseV1<TResult>();

            var readAsStreamAsync = response.Content.ReadAsStreamAsync();

            var xmlSerializer = new XmlSerializer(typeof(TResult));
            if (response.IsSuccessStatusCode)
            {
                return (response.StatusCode == HttpStatusCode.NoContent)
                    ? default(TResult)
                    : (TResult)xmlSerializer.Deserialize(await readAsStreamAsync);
            }

            var readAsStringAsync = response.Content.ReadAsStringAsync();
            throw new HttpRequestException(await readAsStringAsync);
        }

        /// <summary>
        /// It can return a GREEN, GREEN_I, YELLOW or RED status.
        /// Depending on the status/availability of the API its being called from.
        /// </summary>
        /// <returns></returns>
        public TResult GetServiceStatus<TResult>()
        {
            return this.GetResponseFromXml<TResult>(new Dictionary<string, string>() { { "Action", "GetServiceStatus" } }, WebRequestMethods.Http.Post);
        }

        /// <summary>
        /// Calculate MWS signature to interface with Amazon
        /// </summary>
        /// <param name="method"></param>
        /// <param name="requestDescription"></param>
        /// <returns></returns>
        public string CalcSignature(string method, string requestDescription)
        {
            var sigData = string.Join("\n",
                method, this.domain.Replace("https://", "").ToLower(), this.uri, requestDescription);
            var sigDataAsBytes = ASCIIEncoding.ASCII.GetBytes(sigData);
            var hmac = new HMACSHA256(ASCIIEncoding.ASCII.GetBytes(this.secretKey));
            return Convert.ToBase64String(hmac.ComputeHash(sigDataAsBytes));
        }

        /// <summary>
        /// Calculates the MD5 encryption for the given string
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string CalcMD5(string text)
        {
            return Convert.ToBase64String(
                MD5.Create().ComputeHash(ASCIIEncoding.ASCII.GetBytes(text))
            ).Trim(new char[] { '\n' });
        }

        /// <summary>
        /// Returns the current timestamp in proper format.
        /// </summary>
        /// <returns></returns>
        public string GetTimestamp()
        {
            return DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'ddTHH':'mm':'ssZ");
        }

        /// <summary>
        /// Builds a dictionary of an enumerated parameter.
        /// Takes any iterable and returns a dictionary.
        /// ie.
        /// EnumerateParam("MarketplaceIdList.Id", new int[] {123, 345, 4343})
        /// returns
        /// {
        ///     MarketplaceIdList.Id.1: 123,
        ///     MarketplaceIdList.Id.2: 345,
        ///     MarketplaceIdList.Id.3: 4343
        /// }
        /// </summary>
        /// <param name="param"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public Dictionary<string, string> EnumerateParam(string param, string[] values)
        {
            if (values == null || values.Length == 0)
                return null;

            var dict = new Dictionary<string, string>();
            if (!param.EndsWith("."))
                param = param + ".";
            for (int i = 0; i < values.Length; i++)
                dict[string.Format("{0}{1}", param, i + 1)] = values[i];
            return dict;
        }
    }
}
