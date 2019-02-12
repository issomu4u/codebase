namespace RainTree.ServiceBroker.Services.Amazon
{
    public class AmazonMwsBase
    {
        /// <summary>
        /// This is used to post/get to the different uris used by amazon per api
        /// /// ie. /Orders/2011-01-01
        /// </summary>
        public virtual string URI { get { return "/"; } }

        /// <summary>
        /// The API version varies in most amazon APIs
        /// </summary>
        public virtual string VERSION { get { return "2009-01-01"; } }

        /// <summary>
        /// There seem to be some xml namespace issues. therefore every api subclass
        /// is recommended to public its namespace, so that it can be referenced
        /// like so AmazonAPISubclass.NS.
        /// For more information see http://stackoverflow.com/a/8719461/389453
        /// </summary>
        public virtual string NS { get { return ""; } }

        /// <summary>
        /// # Some APIs are available only to either a "Merchant" or "Seller"
        /// the type of account needs to be sent in every call to the amazon MWS.
        /// This constant the exact name of the parameter Amazon expects
        /// for the specific API being used.
        /// All subclasses need to public class this if they require another account type
        /// like "Merchant" in which case you public class it like so.
        /// ACCOUNT_TYPE = "Merchant"
        /// Which is the name of the parameter for that specific account type.
        /// </summary>
        public virtual string ACCOUNT_TYPE { get { return "SellerId"; } }

        private readonly string _accessKey;
        private readonly string _secretKey;
        private readonly string _accountId;
        private readonly string _domain;
        private readonly string _uri;
        private readonly string _version;

        public AmazonMwsBase(string accessKey, string secretKey, string accountId,
           string domain = null, string uri = null, string version = null)
        {
            _accessKey = accessKey;
            _secretKey = secretKey;
            _accountId = accountId;
            _domain = domain ?? "https://mws.amazonservices.in";
            _uri = uri ?? URI;
            _version = version ?? VERSION;
        }



    }
}
