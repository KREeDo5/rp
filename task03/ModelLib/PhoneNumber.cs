using System.Text.RegularExpressions;

namespace ModelLib;

public class PhoneNumber
{
    // Спроектируйте и реализуйте класс PhoneNumber, представляющий телефонный номер в международном формате:
    //
    
    //     Метод ToString(), возвращающий строку номера телефона с символом + в начале
    // Пример: +78362450272 — когда нет добавочного номера
    // Пример: +12345678901x1234 — когда есть добавочный номер
    
    
    
    public PhoneNumber(string text)
    {   
        // Допускаются номера с символом + в начале и без него, например:
        // +7 (8362) 45-02-72 → номер +78362450272
        // 7 (8362) 45-02-72 → номер +78362450272
        // 8 (8362) 45-02-72 → номер +88362450272
        // Допускаются номера с добавочным (внутренним) номером после x, например:
        // 1-234-567-8901 x1234 → номер +12345678901, добавочный 1234
        // В классе PhoneNumber должны быть:
        //
        // Конструктор PhoneNumber(string text), создающий номер телефона из текстового представления
        // удаляет символы , -, (, ) (пробелы, дефисы, круглые скобки)
        //     проверяет оставшиеся символы на соответствие формату
        //     сохраняет отдельно основной номер и добавочный номер
        
        // TODO: инициализация класса с разбиением на основной и добавочный номера
        // if (radius <= 0)
        // {
        //     throw new ArgumentOutOfRangeException(nameof(radius), "Радиус должен быть положительным.");
        // }
        string[] parts = text.Split(Separator, 2);
        MainNumber = int.Parse(Regex.Match(parts[0], @"\d+").Value);
        if (parts.Length != 2)
        {
            return;
        }

        String resultAdditionalNumber = Regex.Match(parts[1], @"\d+").Value;
        if (resultAdditionalNumber != "")
        {
            AdditionalNumber = int.Parse(resultAdditionalNumber);
        }
    }
    
    private const Char Separator = 'x';
    
    private int MainNumber { get; }
    private int? AdditionalNumber { get; }
    
    // Свойство string Number, возвращающее строку номера телефона с символом + в начале, но без добавочного номера
    public String Number => "+" + MainNumber ;
    
    // Свойство string Ext, возвращающее добавочный номер либо пустую строку
    public String Ext => AdditionalNumber?.ToString() ?? "" ;
}