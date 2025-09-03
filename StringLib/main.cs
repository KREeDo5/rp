using StringLib;

class MyClass
{
    static void Main(string[] args)
    {
        // Пример строки для тестирования
        string text = "Пример текста для проверки методов.";
        //
        // // Тестируем метод SplitIntoWords
        // List<string> words = TextUtil.SplitIntoWords(text);
        // Console.WriteLine("Результат SplitIntoWords:");
        // Console.WriteLine(string.Join(", ", words));

        // Тестируем метод ReverseWords
        string reversedText = TextUtil.ReverseWords(text);
        Console.WriteLine("Результат ReverseWords:");
        Console.WriteLine(reversedText);
    }
}