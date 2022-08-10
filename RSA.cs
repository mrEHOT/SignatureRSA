using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Math.Gmp.Native;

namespace SignatureRSA
{
    static class RSA
    {
        private static bool ready = false; // Статическая перемееная для определения состояния готовности шифра
        private static mpz_t pPrime = "0"; // Статическая переменная для хранения простого числа P
        private static mpz_t qPrime = "0"; // Статическая переменная для хранения простого числа Q
        private static mpz_t modulo = "0"; // Статическая переменная для хранения модуля N = P * Q
        private static mpz_t publicKey = "0"; // Статическая переменная для хранения применяемого в данный момент открытого ключа
        private static mpz_t privateKey = "0"; // Статическая переменная для хранения применяемого в данный момент секретного ключа

        public static bool CheckCipherSetup()
        {
            return ready;
        } // Если функция вернула "true" - то шифр готов к использованию, если "false" - значит шифр не готов к использованию

        public static void RSAReset()
        {
            ready = false;
            pPrime = "0";
            qPrime = "0";
            modulo = "0";
            publicKey = "0";
            privateKey = "0";
        } // Сброс шифра в начальное состояние

        public static (string, string, string, string, string) GetCipherParameters()
        {
            (string, string, string, string, string) result = ("", "", "", "", "");

            result.Item1 = pPrime.ToString();
            result.Item2 = qPrime.ToString();
            result.Item3 = modulo.ToString();
            result.Item4 = publicKey.ToString();
            result.Item5 = privateKey.ToString();

            return result;
        } // Функция возвращает текущие параметры шифра RSA

        public static string GenerateKeys()
        {
            string result = "Ошибка генерации ключей!";
            pPrime = "0";
            qPrime = "0";

            #region Настройка генератора случайных чисел
            Random random = new Random();
            int seed = random.Next();
            gmp_randstate_t state = new gmp_randstate_t();
            gmp_lib.gmp_randinit_default(state);
            gmp_lib.gmp_randseed_ui(state, (uint)seed);
            #endregion

            while (true)
            {
                gmp_lib.mpz_urandomb(pPrime, state, 300);
                if (gmp_lib.mpz_sizeinbase(pPrime, 10) >= 50)
                    gmp_lib.mpz_nextprime(pPrime, pPrime);


                gmp_lib.mpz_urandomb(qPrime, state, 300);
                if (gmp_lib.mpz_sizeinbase(qPrime, 10) >= 50)
                    gmp_lib.mpz_nextprime(qPrime, qPrime);

                if (GenerateKeys(pPrime, qPrime).Item1)
                {
                    result = "Ключи были сгенерированы!";
                    break;
                }
            }

            return result;
        } // Генерация ключей шифрования без параметров

        public static (bool, string) GenerateKeys(mpz_t pPrime, mpz_t qPrime)
        {
            (bool, string) result = (false, "Ошибка генерации ключей!");

            if ((gmp_lib.mpz_cmp(pPrime, "10") > 0) && (gmp_lib.mpz_cmp(qPrime, "10") > 0))
            {
                if (SolovayStrassenTest.PrimalityTest(pPrime) && SolovayStrassenTest.PrimalityTest(qPrime))
                {
                    gmp_lib.mpz_mul(RSA.modulo, pPrime, qPrime); // Вычисляем значение модуля N

                    if (gmp_lib.mpz_cmp(RSA.modulo, "255") > 0)
                    {
                        mpz_t eulerFunc = "0"; // Переменная для хранения результата функции Эйлера для N
                        gmp_lib.mpz_sub(eulerFunc, qPrime, "1"); // eulerFunc = Q-1
                        mpz_t buffer = "0";
                        gmp_lib.mpz_sub(buffer, pPrime, "1"); // buffer = P-1
                        gmp_lib.mpz_mul(eulerFunc, eulerFunc, buffer); // Вычисляем значение функции Эйлера = (P-1)*(Q-1)

                        mpz_t key = "0"; // Переменная для хранения генерируемых ключей

                        #region Настройка генератора случайных чисел
                        Random random = new Random();
                        int seed = random.Next();
                        gmp_randstate_t state = new gmp_randstate_t();
                        gmp_lib.gmp_randinit_default(state);
                        gmp_lib.gmp_randseed_ui(state, (uint)seed);
                        #endregion

                        while (true)
                        {
                            gmp_lib.mpz_urandomm(key, state, eulerFunc); // Генерируем случайное число в диапазоне от 0 до N-1
                            if (gmp_lib.mpz_cmp(key, "1") > 0)
                            {
                                if (gmp_lib.mpz_cmp(Euclid.GCD(eulerFunc, key), "1") == 0)
                                {
                                    mpz_t pKey = Euclid.Inversion(eulerFunc, key); // Вычисляем инверсию открытого ключа по модулю (P-1)*(Q-1) => узнаем секретный ключ
                                    if (gmp_lib.mpz_cmp(Euclid.GCD(pKey, key), "1") == 0)
                                    {
                                        publicKey = key;
                                        privateKey = pKey;
                                        result.Item1 = true;
                                        result.Item2 = "Ключи были сгенерированы!";
                                        break;
                                    } // Если открытый и секретный ключи взаимно простые, то они подходят для шифрования => формирование ключей закончено
                                }
                            } // Выполняем последующие проверки если key > 1
                        } // Выбираем открытый ключ
                    } // Выполняется в случае если произведение простых чисел > 255 (т.е. можем шифровать любой байт)
                    else
                    {
                        result.Item2 = "Ошибка генерации ключей! Недостаточный размер модуля N = P * Q! Произведение P и Q должно быть больше 255!";
                        RSA.modulo = "0";
                        return result;
                    }

                } // Выполняется в случае если оба числа простые
                else
                {
                    result.Item2 = "Ошибка генерации ключей! Не все введенные числа являются простыми!";
                    return result;
                }
            }
            else
            {
                result.Item2 = "Ошибка генерации ключей! Введите числа большего размера!";
                return result;
            }

            RSA.pPrime = pPrime;
            RSA.qPrime = qPrime;
            RSA.ready = true;
            return result;
        } // Генерация ключей шифрования на основании пользовательских данных

        public static mpz_t TextEncoding(mpz_t content)
        {
            content = ModOperations.Pow(content, publicKey, modulo);
            return content;
        } // Шифрование данных алгоритмом RSA

        public static mpz_t TextDecoding(mpz_t content)
        {
            content = ModOperations.Pow(content, privateKey, modulo); // Выполняем расшифрование одного символа
            return content;
        } // Расшифрование данных алгоритмом RSA
    }
}
