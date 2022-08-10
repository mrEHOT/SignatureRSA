using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignatureRSA
{
    static class SHA
    {
        #region Константы и базовые методы

        // Инициализируем 5 32-битных переменных в виде HEX
        private static string varA = "67452301";
        private static string varB = "EFCDAB89";
        private static string varC = "98BADCFE";
        private static string varD = "10325476";
        private static string varE = "C3D2E1F0";

        // Инициализируем 4 32-битных константы в виде HEX
        private const string constK1 = "5A827999";
        private const string constK2 = "6ED9EBA1";
        private const string constK3 = "8F1BBCDC";
        private const string constK4 = "CA62C1D6";

        private static byte[] ConvertHexToByteArray(string hex)
        {
            byte[] bytes = new byte[4];
            long value = Convert.ToInt64(hex, 16); // Переводим hex значение в десятичный
            string str = Convert.ToString(value, 2).PadLeft(32, '0'); // Переводим в строку в двоичном виде (32 бит)

            for (int i = 0; i < str.Length / 8; i++)
            {
                string buffer = "";
                for (int j = i * 8; j < i * 8 + 8; j++)
                    buffer += str[j];

                bytes[i] = Convert.ToByte(buffer, 2);
            } // Получаем hex значение в виде массива байт

            return bytes;
        } // Переводим значение в HEX записи в массив байт

        private static byte[] ConvertBitStringToByteArray(string bitString)
        {
            byte[] bytes = new byte[bitString.Length / 8]; // Создаем массив байт для хранения данных

            for (int i = 0; i < bitString.Length / 8; i++)
            {
                string buffer = "";
                for (int j = i * 8; j < i * 8 + 8; j++)
                    buffer += bitString[j];

                bytes[i] = Convert.ToByte(buffer, 2);
            } // Заполняем массив байт

            return bytes;
        } // Переводим битовую строку в массив байт

        private static string ConvertByteArrayToBitString(byte[] bytes)
        {
            string str = "";
            foreach (byte b in bytes)
                str += Convert.ToString(b, 2).PadLeft(8, '0'); // Конвертируем массив байт в битовую строку

            return str;
        } // Переводим данные в виде массива байт в битовую строку

        private static string ConvertBitStringToHex(string bitString)
        {
            long value = Convert.ToInt64(bitString, 2); // Переводим битовую строку в десятичное число
            string str = Convert.ToString(value, 16); // Переводим десятичное число в HEX запись

            return str;
        } // Переводим битовую строку в HEX значение

        private static string ConvertHexToBitString(string hex)
        {
            long value = Convert.ToInt64(hex, 16); // Переводим hex значение в десятичный
            string str = Convert.ToString(value, 2).PadLeft(32, '0'); // Переводим в строку в двоичном виде (32 бит)

            return str;
        } // Переводим HEX значение в битовую строку

        #region Нелинейные функции

        private static byte[] NonlinearFunc1(byte[] A, byte[] B, byte[] C)
        {
            string partOne = BitString.AND(ConvertByteArrayToBitString(A), ConvertByteArrayToBitString(B)); // A && B
            string partTwo = BitString.AND(BitString.NOT(ConvertByteArrayToBitString(A)), ConvertByteArrayToBitString(C)); // не (A) && C
            string result = BitString.OR(partOne, partTwo); // partOne || partTwo

            return ConvertBitStringToByteArray(result);
        } // Нелинейная функция #1

        private static byte[] NonlinearFunc2(byte[] A, byte[] B, byte[] C)
        {
            string result = BitString.XOR(ConvertByteArrayToBitString(A), ConvertByteArrayToBitString(B)); // A xor B
            result = BitString.XOR(result, ConvertByteArrayToBitString(C)); // A xor B xor C

            return ConvertBitStringToByteArray(result);
        } // Нелинейная функция #2

        private static byte[] NonlinearFunc3(byte[] A, byte[] B, byte[] C)
        {
            string partOne = BitString.AND(ConvertByteArrayToBitString(A), ConvertByteArrayToBitString(B)); // A && B
            string partTwo = BitString.AND(ConvertByteArrayToBitString(A), ConvertByteArrayToBitString(C)); // A && C
            string partThree = BitString.AND(ConvertByteArrayToBitString(B), ConvertByteArrayToBitString(C)); // B && C

            string result = BitString.OR(partOne, partTwo); // partOne || partTwo
            result = BitString.OR(result, partThree); // partOne || partTwo || partThree

            return ConvertBitStringToByteArray(result);
        } // Нелинейная функция #3

        private static byte[] NonlinearFunc4(byte[] A, byte[] B, byte[] C)
        {
            string result = BitString.XOR(ConvertByteArrayToBitString(A), ConvertByteArrayToBitString(B)); // A xor B
            result = BitString.XOR(result, ConvertByteArrayToBitString(C)); // A xor B xor C

            return ConvertBitStringToByteArray(result);
        } // Нелинейная функция #4

        #endregion

        private static byte[] GetSubblock(byte[] A, byte[] B, byte[] C, byte[] D)
        {
            string result = BitString.XOR(ConvertByteArrayToBitString(A), ConvertByteArrayToBitString(B)); // A xor B
            result = BitString.XOR(result, ConvertByteArrayToBitString(C)); // A xor B xor C
            result = BitString.XOR(result, ConvertByteArrayToBitString(D)); // A xor B xor C xor D

            result = BitString.RSL(result, 1); // Выполняем циклический сдвиг влево на 1 бит

            return ConvertBitStringToByteArray(result); // Конвертируем в массив байт и возвращаем
        } // Расчет слов расширенного сообщения (рассчитываемые субблоки применяются на шагах 16-79 главного цикла)

        private static void MainCycle(List<byte[]> variables, List<byte[]> subblocks)
        {
            for (int i = 0; i < subblocks.Count; i++)
            {
                var temp = ConvertByteArrayToBitString(variables[0]); // Кладем в temp a

                if ((0 <= i) && (i <= 19))
                {
                    temp = BitString.RSL(temp, 5); // Выполняем циклический сдвиг влево на 5 бит
                    temp = BitString.SUM(temp, ConvertByteArrayToBitString(NonlinearFunc1(variables[1], variables[2], variables[3]))); // Выполняем сложения с f1(b,c,d)
                    temp = BitString.SUM(temp, ConvertByteArrayToBitString(variables[4])); // Выполняем сложение temp с e
                    temp = BitString.SUM(temp, ConvertByteArrayToBitString(subblocks[i])); // Выполняем сложение temp с Wi (субблок с номером i)
                    temp = BitString.SUM(temp, ConvertByteArrayToBitString(ConvertHexToByteArray(constK1))); // Выполняем сложение с K1
                } // Шаги цикла с 0 по 19

                if ((20 <= i) && (i <= 39))
                {
                    temp = BitString.RSL(temp, 5); // Выполняем циклический сдвиг влево на 5 бит
                    temp = BitString.SUM(temp, ConvertByteArrayToBitString(NonlinearFunc2(variables[1], variables[2], variables[3]))); // Выполняем сложения с f2(b,c,d)
                    temp = BitString.SUM(temp, ConvertByteArrayToBitString(variables[4])); // Выполняем сложение temp с e
                    temp = BitString.SUM(temp, ConvertByteArrayToBitString(subblocks[i])); // Выполняем сложение temp с Wi (субблок с номером i)
                    temp = BitString.SUM(temp, ConvertByteArrayToBitString(ConvertHexToByteArray(constK2))); // Выполняем сложение с K2
                } // Шаги цикла с 20 по 39

                if ((40 <= i) && (i <= 59))
                {
                    temp = BitString.RSL(temp, 5); // Выполняем циклический сдвиг влево на 5 бит
                    temp = BitString.SUM(temp, ConvertByteArrayToBitString(NonlinearFunc3(variables[1], variables[2], variables[3]))); // Выполняем сложения с f3(b,c,d)
                    temp = BitString.SUM(temp, ConvertByteArrayToBitString(variables[4])); // Выполняем сложение temp с e
                    temp = BitString.SUM(temp, ConvertByteArrayToBitString(subblocks[i])); // Выполняем сложение temp с Wi (субблок с номером i)
                    temp = BitString.SUM(temp, ConvertByteArrayToBitString(ConvertHexToByteArray(constK3))); // Выполняем сложение с K3
                } // Шаги цикла с 40 по 59

                if ((60 <= i) && (i <= 79))
                {
                    temp = BitString.RSL(temp, 5); // Выполняем циклический сдвиг влево на 5 бит
                    temp = BitString.SUM(temp, ConvertByteArrayToBitString(NonlinearFunc4(variables[1], variables[2], variables[3]))); // Выполняем сложения с f1(b,c,d)
                    temp = BitString.SUM(temp, ConvertByteArrayToBitString(variables[4])); // Выполняем сложение temp с e
                    temp = BitString.SUM(temp, ConvertByteArrayToBitString(subblocks[i])); // Выполняем сложение temp с Wi (субблок с номером i)
                    temp = BitString.SUM(temp, ConvertByteArrayToBitString(ConvertHexToByteArray(constK4))); // Выполняем сложение с K4
                } // Шаги цикла с 60 по 79

                variables[4] = variables[3]; // Кладем в e значение d
                variables[3] = variables[2]; // Кладем в d значение c
                variables[2] = ConvertBitStringToByteArray(BitString.RSL(ConvertByteArrayToBitString(variables[1]), 30)); // Кладем в c значение b << 30 (циклический сдвиг влево на 30 бит)
                variables[1] = variables[0]; // Кладем в b значение a
                variables[0] = ConvertBitStringToByteArray(temp); // Кладем в a значение temp
            } // Выполняем цикл 80 раз
        } // Метод, реализующий главный цикл хэширования SHA

        private static void ResetVariables()
        {
            varA = "67452301";
            varB = "EFCDAB89";
            varC = "98BADCFE";
            varD = "10325476";
            varE = "C3D2E1F0";
        } // Возвращаем 32-битным переменным стартовые значения

        #endregion

        #region Public методы для работы с SHA

        public static byte[] Padding(byte[] content, long length)
        {
            byte[] result = null; // Создаем массив для хранения результата

            if (content.Length * 8 % 512 != 0)
            {
                int diff = 512 - content.Length * 8; // Высчитываем насколько бит 512 длиннее, чем блок сообщения

                if (diff < 64)
                {
                    result = new byte[128]; // Создаем новый массив размером 128 байт = 1024 бит

                    for (int i = 0; i < content.Length; i++)
                        result[i] = content[i]; // Заполняем выходной массив байтами из начального блока

                    result[content.Length] = 128; // Заполняем первый байт после окончания одной 1 и 7 нулями

                    string lengthInStr = Convert.ToString(length, 2).PadLeft(64, '0'); // Преобразуем длину сообщения в бинарный вид

                    byte[] bytes = new byte[8]; // Создаем буфер для хранения двоичного представления длины иходного сообщения

                    for (int i = 0; i < lengthInStr.Length / 8; i++)
                    {
                        string buffer = "";
                        for (int j = i * 8; j < i * 8 + 8; j++)
                            buffer += lengthInStr[j];

                        bytes[i] = Convert.ToByte(buffer, 2);
                    } // Переводим представление длины в виде битовой строки в массив байт

                    int count = bytes.Length - 1; // Устанавливаем счетчик на последний байт длины сообщения
                    for (int i = result.Length - 1; i > result.Length - 9; i--)
                    {
                        result[i] = bytes[count];
                        count--;
                    } // Записываем длину в результирующий массив

                } // Если разница меньше 64 бит, то дополнение в рамках одного блока на 512 бит выполнить не можем! Тоже самое если блок составляет  512 бит, нужен еще один блок
                else
                {
                    result = new byte[64]; // Создаем новый массив на 64 байта = 512 бит

                    for (int i = 0; i < content.Length; i++)
                        result[i] = content[i]; // Заполняем выходной массив байтами из начального блока

                    result[content.Length] = 128; // Заполняем первый байт после окончания одной 1 и 7 нулями

                    string lengthInStr = Convert.ToString(length, 2).PadLeft(64, '0'); // Преобразуем длину сообщения в бинарный вид

                    byte[] bytes = new byte[8]; // Создаем буфер для хранения двоичного представления длины иходного сообщения

                    for (int i = 0; i < lengthInStr.Length / 8; i++)
                    {
                        string buffer = "";
                        for (int j = i * 8; j < i * 8 + 8; j++)
                            buffer += lengthInStr[j];

                        bytes[i] = Convert.ToByte(buffer, 2);
                    } // Переводим представление длины в виде битовой строки в массив байт

                    int count = bytes.Length - 1; // Устанавливаем счетчик на последний байт длины сообщения
                    for (int i = result.Length - 1; i > result.Length - 9; i--)
                    {
                        result[i] = bytes[count];
                        count--;
                    } // Записываем длину в результирующий массив

                } // Если разница больше 64 бит, то выполняем дополнение до блока длиной 512 бит

            } // Дополнение блока, длина которого < 512 бит
            else
            {
                if (content.Length * 8 == 512)
                {
                    result = new byte[128]; // Создаем новый массив размером 128 байт = 1024 бит

                    for (int i = 0; i < content.Length; i++)
                        result[i] = content[i]; // Заполняем выходной массив байтами из начального блока

                    result[content.Length] = 128; // Заполняем первый байт после окончания одной 1 и 7 нулями

                    string lengthInStr = Convert.ToString(length, 2).PadLeft(64, '0'); // Преобразуем длину сообщения в бинарный вид

                    byte[] bytes = new byte[8]; // Создаем буфер для хранения двоичного представления длины иходного сообщения

                    for (int i = 0; i < lengthInStr.Length / 8; i++)
                    {
                        string buffer = "";
                        for (int j = i * 8; j < i * 8 + 8; j++)
                            buffer += lengthInStr[j];

                        bytes[i] = Convert.ToByte(buffer, 2);
                    } // Переводим представление длины в виде битовой строки в массив байт

                    int count = bytes.Length - 1; // Устанавливаем счетчик на последний байт длины сообщения
                    for (int i = result.Length - 1; i > result.Length - 9; i--)
                    {
                        result[i] = bytes[count];
                        count--;
                    } // Записываем длину в результирующий массив
                }

                if (content.Length * 8 == 0)
                {
                    result = new byte[64]; // Создаем новый массив размером 64 байт = 512 бит

                    result[content.Length] = 128; // Заполняем первый байт после окончания одной 1 и 7 нулями

                    string lengthInStr = Convert.ToString(length, 2).PadLeft(64, '0'); // Преобразуем длину сообщения в бинарный вид

                    byte[] bytes = new byte[8]; // Создаем буфер для хранения двоичного представления длины иходного сообщения

                    for (int i = 0; i < lengthInStr.Length / 8; i++)
                    {
                        string buffer = "";
                        for (int j = i * 8; j < i * 8 + 8; j++)
                            buffer += lengthInStr[j];

                        bytes[i] = Convert.ToByte(buffer, 2);
                    } // Переводим представление длины в виде битовой строки в массив байт

                    int count = bytes.Length - 1; // Устанавливаем счетчик на последний байт длины сообщения
                    for (int i = result.Length - 1; i > result.Length - 9; i--)
                    {
                        result[i] = bytes[count];
                        count--;
                    } // Записываем длину в результирующий массив
                }
            } // Длина блока кратна 512 бит  (т.е. длина 512 или 0)

            return result;
        } // Дополнения последнего блока данных, длина которого <= 512 бит

        public static void CalculateHash(byte[] dataBlock)
        {
            #region ШАГ #1. Получаем текущий вид 32-битных переменных

            List<byte[]> variables = new List<byte[]>(); // Список для хранения глобальных переменных

            variables.Add(ConvertHexToByteArray(varA));
            variables.Add(ConvertHexToByteArray(varB));
            variables.Add(ConvertHexToByteArray(varC));
            variables.Add(ConvertHexToByteArray(varD));
            variables.Add(ConvertHexToByteArray(varE));

            #endregion

            #region ШАГ #2. Получаем из начального блока данных 80 субблоков по 32 бита
            List<byte[]> subblocks = new List<byte[]>(); // Инициализируем список для хранения 32-битных слов

            for (int i = 0; i < dataBlock.Length * 8 / 32; i++)
            {
                byte[] buffer = new byte[4];
                for (int j = 0; j < buffer.Length; j++)
                    buffer[j] = dataBlock[i * 4 + j]; // Заполняем буффер 32-битным словом (4 байта)

                subblocks.Add(buffer);
            } // Записываем 16 32-битных слов исходного блока

            for (int i = 16; i < 80; i++)
            {
                subblocks.Add(GetSubblock(subblocks[i - 3], subblocks[i - 8], subblocks[i - 14], subblocks[i - 16]));
            } // Получаем оставишиеся 32-битные слова, чтобы получить 80 субблоков расширенного сообщения

            #endregion

            #region ШАГ #3. Вызываем главный цикл хэширования

            MainCycle(variables, subblocks); // Результат попадает в variables
            subblocks.Clear(); // Удаляем все субблоки расширенного сообщения

            #endregion

            #region ШАГ #4. Складываем значения полученные в цикле с 32-битными переменными

            varA = ConvertBitStringToHex(BitString.SUM(ConvertHexToBitString(varA), ConvertByteArrayToBitString(variables[0])));
            varB = ConvertBitStringToHex(BitString.SUM(ConvertHexToBitString(varB), ConvertByteArrayToBitString(variables[1])));
            varC = ConvertBitStringToHex(BitString.SUM(ConvertHexToBitString(varC), ConvertByteArrayToBitString(variables[2])));
            varD = ConvertBitStringToHex(BitString.SUM(ConvertHexToBitString(varD), ConvertByteArrayToBitString(variables[3])));
            varE = ConvertBitStringToHex(BitString.SUM(ConvertHexToBitString(varE), ConvertByteArrayToBitString(variables[4])));

            variables.Clear(); // Очищаем список для хранения глобальных переменных
            #endregion
        } // Функция для рассчета хэш функции одного блока сообщения

        public static string GetResultHash()
        {
            string result = "";

            result = varA + " " + varB + " " + varC + " " + varD + " " + varE; // Получаем финальный хэш

            ResetVariables(); // Восстанавливаем начальное значение 32-битных переменных
            return result;
        } // Функция возвращает результат хэширования в виде конкатинации 32-битных переменных представленных в HEX формате

        #endregion
    }
}
