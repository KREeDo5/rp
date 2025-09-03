using System.Text.RegularExpressions;

namespace StringLib;

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
        // TODO: text - это строка
        // TODO: Разбиваем text на слова методом SplitIntoWords
        // TODO: Каждую строку из массива переворачиваем Reverse().ToString()
        // TODO: Далее каждую обработанную строку массива схлопываем в единую строку

        // Console.WriteLine("text");
        return text.Reverse().ToString() ?? text;
    }
}