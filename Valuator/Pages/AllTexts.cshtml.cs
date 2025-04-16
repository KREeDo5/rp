using Microsoft.AspNetCore.Mvc.RazorPages;
using StackExchange.Redis;
using System.Collections.Generic;

namespace Valuator.Pages
{
    public class AllTextsModel : PageModel
    {
        private readonly IConnectionMultiplexer _redis;

        public AllTextsModel(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        public Dictionary<string, string> Texts { get; private set; }

        public void OnGet()
        {
            var redisDatabase = _redis.GetDatabase();
            var server = _redis.GetServer(_redis.GetEndPoints().First());
            var keys = server.Keys(pattern: "TEXT-*");

            Texts = new Dictionary<string, string>();
            foreach (var key in keys)
            {
                string text = redisDatabase.StringGet(key);
                if (text != null) Texts.Add(key!, text);
            }
        }
    }
}