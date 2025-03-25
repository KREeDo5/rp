using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StackExchange.Redis;

namespace Valuator.Pages;

public partial class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IConnectionMultiplexer _redis;
    
    public IndexModel(ILogger<IndexModel> logger, IConnectionMultiplexer redis)
    {
        _logger = logger;
        _redis = redis;
    }

    public void OnGet()
    {

    }

    public IActionResult OnPost(string text)
    {
        _logger.LogDebug(text);

        string id = Guid.NewGuid().ToString();
        
        var redisDatabase = _redis.GetDatabase();

        string textKey = "TEXT-" + id;
        // TODO: (pa1) сохранить в БД (Redis) text по ключу textKey
        redisDatabase.StringSet(textKey, text);

        string rankKey = "RANK-" + id;
        // TODO: (pa1) посчитать rank и сохранить в БД (Redis) по ключу rankKey
        double rank = CalculateRank(text);
        redisDatabase.StringSet(rankKey, rank);

        string similarityKey = "SIMILARITY-" + id;
        // TODO: (pa1) посчитать similarity и сохранить в БД (Redis) по ключу similarityKey
        int similarity = CalculateSimilarity(text, textKey);
        redisDatabase.StringSet(similarityKey, similarity);

        return Redirect($"summary?id={id}");
    }
    
    // Результат оценки содержания - число rank в диапазоне [0..1],
    // равное доле неалфавитных символов в тексте.
    // Алфавитными считаются символы строчных и прописных букв латинского и русского алфавитов.
    private static double CalculateRank(string text)
    {   

        var nonAlphabeticCount = MyRegex().Matches(text).Count;
        double rank = (double)nonAlphabeticCount / text.Length;
        return Math.Round(rank, 3);
    }
    
    // Проверка на похожесть делается на основе поиска дубликата текста среди ранее обработанных.
    // Если найден дубликат, то similarity = 1, иначе 0.
    private int CalculateSimilarity(string text, string currentKey)
    {   
        var redisDatabase = _redis.GetDatabase();
        var server = _redis.GetServer(_redis.GetEndPoints().First());
        var keys = server.Keys(pattern: "TEXT-*");
        
        foreach (var key in keys)
        {   
            if (key == currentKey)
            {
                continue;
            }
            
            string storedText = redisDatabase.StringGet(key);
            if (storedText == text)
            {
                return 1;
            }
        }
        
        return 0; 
    }

    [System.Text.RegularExpressions.GeneratedRegex(@"[^a-zA-Zа-яА-Я]")]
    private static partial System.Text.RegularExpressions.Regex MyRegex();
}
