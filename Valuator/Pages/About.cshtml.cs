using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System.Text;

namespace Valuator.Pages
{
    public class AboutModel : PageModel
    {
        private readonly ILogger<AboutModel> _logger;
        private readonly IConnectionMultiplexer _redis;
        
        public string? Name { get; private set; }
        public string? Group { get; private set; }

        public AboutModel(ILogger<AboutModel> logger, IConnectionMultiplexer redis)
        {
            _logger = logger;
            _redis = redis;
        }

        public void OnGet()
        {
            var redisDatabase = _redis.GetDatabase();
            Name = redisDatabase.StringGet("studentName");
            Group = redisDatabase.StringGet("groupName");
            
            Name = !string.IsNullOrEmpty(Name) ? Encoding.UTF8.GetString(Encoding.Default.GetBytes(Name)) : "Имя не указано";

            Group = !string.IsNullOrEmpty(Group) ? Group : "Группа не указана";
        }
    }
}
