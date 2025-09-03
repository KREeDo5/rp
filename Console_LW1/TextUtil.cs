namespace Console_LW1;

using System.Text.RegularExpressions;

public static class TextUtil
{
    public static List<string> SplitIntoWords(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return [];
        }

        // Регулярное выражение для поиска слов:
        // - Слово начинается и заканчивается на букву.
        // - Может содержать апострофы и дефисы внутри.
        // - Не содержит чисел или знаков препинания.
        const string pattern = @"\p{L}+(?:[\-\']\p{L}+)*";
        Regex regex = new(pattern, RegexOptions.Compiled);

        return regex.Matches(text)
            .Select(match => match.Value)
            .ToList();
    }

    public static string ReverseWords(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return "";
        }
        // Регулярное выражение для поиска слов, которые можно перевернуть:
        // - Слово содержит только буквы A-Z, a-z, а-я, А-Я, ё, Ё.
        // - Имеет длину не менее двух символов.
        const string pattern = @"[A-Za-zА-Яа-яЁё]{2,}";
        return Regex.Replace(
            text,
            pattern,
            match => ReverseString(match.Value)
        );
    }

    private static string ReverseString(string str) => new string(str.Reverse().ToArray());
}