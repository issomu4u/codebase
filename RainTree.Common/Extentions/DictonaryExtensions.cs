using System.Collections.Generic;

namespace RainTree.Common.Extentions
{
    public static class DictonaryExtensions
    {
        public static void Update<TKey, TValue>(this IDictionary<TKey, TValue> dist, IDictionary<TKey, TValue> src)
        {
            if (src == null || src.Count == 0)
                return;

            foreach (var pair in src)
                if (dist.ContainsKey(pair.Key))
                    dist[pair.Key] = pair.Value;
                else
                    dist.Add(pair.Key, pair.Value);
        }
    }
}
