using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignatureRSA
{
    static class BitString
    {
        public static string NOT(string str)
        {
            string result = ""; // Строка для формирования результата

            for (int i = 0; i < str.Length; i++)
                if (str[i] == '1')
                    result += "0"; // Если на позиции i в строке встречаем 1 => 0 в результирующей
                else
                    result += "1"; // Встретили 0 на позиции i => 1 в результирующей

            return result;
        } // Вычисляем инверсию битовой строки ("логическое не/отрицание")

        public static string AND(string str1, string str2)
        {
            string result = ""; // Строка для формирования результата

            for (int i = 0; i < str1.Length; i++)
                if (str1[i] == '1' && str2[i] == '1')
                    result += "1"; // Если в обоих строках символ равен 1 => 1 в результирующей
                else
                    result += "0"; // Если хоть в одной из строк не 1 на позиции i => 0 в результирующей

            return result;
        } // Выполняем AND ("логическое и") для битовых строк

        public static string OR(string str1, string str2)
        {
            string result = ""; // Строка для формирования результата

            for (int i = 0; i < str1.Length; i++)
                if (str1[i] == '1' || str2[i] == '1')
                    result += "1"; // Если хоть в одной из строк символ равен 1 => 1 в результирующей
                else
                    result += "0"; // 0 в обоих строках на позиции i => 0 в результирующей

            return result;
        } // Выполняем OR ("логическое или") для битовых строк

        public static string XOR(string str1, string str2)
        {
            string result = ""; // Строка для формирования результата

            for (int i = 0; i < str1.Length; i++)
                if (str1[i] == str2[i])
                    result += "0"; // Если символы на одной позиции в двух строках совпадают => результат их сложения по модулю два = 0
                else
                    result += "1"; // Результат сложения по модулю два = 1

            return result;
        } // Выполняем XOR (сложение по модулю два) для битовых строк

        public static string RSL(string str, int shift)
        {
            string result = ""; // Строка для формирования результата

            result = str.Substring(shift, str.Length - shift) + str.Substring(0, shift); // Выполняем циклический сдвиг влево на указанное количество бит

            return result;
        } // Циклический сдвиг влево на shift бит

        public static string SUM(string str1, string str2)
        {
            long sum = Convert.ToInt64(str1, 2) + Convert.ToInt64(str2, 2); // Рассчитываем сумму двух целых чисел
            string result = Convert.ToString(sum, 2); // Переводим результат в двоичную систему счисления
            if (result.Length <= 32)
                return result.PadLeft(32, '0'); // Добиваем длину до 32 бит и возвращаем
            else
                return result.Substring(1); // Возвращаем 32 бита отбрасывая 33-ий бит
        } // Сложение беззнаковых 32-битных целых чисел с отбрасыванием избытка (33-го бита)
    }
}
