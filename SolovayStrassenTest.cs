using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Math.Gmp.Native;

namespace SignatureRSA
{
    static class SolovayStrassenTest
    {
        public static bool PrimalityTest(mpz_t number)
        {
            int numberOfRounds = 0;

            if (gmp_lib.mpz_cmp(number, "64") <= 0)
            {
                mpz_t div = "0";
                gmp_lib.mpz_fdiv_q(div, number, "3");

                numberOfRounds = (int) gmp_lib.mpz_get_ui(div) + 1;
            }
            else
                numberOfRounds = 32; // Количество раундов тестирования

            List<mpz_t> numbersForCheck = new List<mpz_t>(); // Список чисел a, которые уже использовались для проверки

            mpz_t temp = "0";
            gmp_lib.mpz_mod(temp, number, "2"); // Определяем нечетность числа
            if (!(gmp_lib.mpz_cmp(temp, "0") == 0))
            {
                gmp_lib.mpz_sub(temp, number, "1"); // Помещаем в temp значение N-1 (number-1)

                #region Настройка генератора случайных чисел
                Random random = new Random();
                int seed = random.Next();
                gmp_randstate_t state = new gmp_randstate_t();
                gmp_lib.gmp_randinit_default(state);
                gmp_lib.gmp_randseed_ui(state, (uint)seed);
                #endregion

                for (int i = 0; i < numberOfRounds; i++)
                {
                    mpz_t testNumber = "0";

                    while (true)
                    {
                        bool generateCheck = true;
                        gmp_lib.mpz_urandomm(testNumber, state, number); // Генерируем случайное число в диапазоне от 0 до N-1

                        if (gmp_lib.mpz_cmp(testNumber, "2") > 0)
                        {
                            foreach (mpz_t t in numbersForCheck) // Проверяем не совпадает ли новое число с каким-либо из тех, что у же применялись для проверки
                                if (gmp_lib.mpz_cmp(testNumber, t) == 0)
                                {
                                    generateCheck = false;
                                    break;
                                }
                        } // Если выбранное случайное число лежит в диапазоне [0;N-1], то продолжаем выполнять проверку
                        else
                            generateCheck = false;

                        if (generateCheck)
                            break;
                    } // Проверяем, что выбранное число a > 2 и раньше не использовалось для проверки

                    if (gmp_lib.mpz_cmp(Euclid.GCD(number, testNumber), "1") > 1) // Проверяем первое условие
                        return false;
                    else
                    {
                        mpz_t jacobi = "0";
                        gmp_lib.mpz_set_d(jacobi, gmp_lib.mpz_jacobi(testNumber, number)); // Рассчитываем символ Якоби
                        gmp_lib.mpz_mod(jacobi, jacobi, number); // Вычисляем значение символа Якоби по модулю N

                        mpz_t pow = "0";
                        gmp_lib.mpz_fdiv_q(pow, temp, "2"); // Рассчитываем степень (N-1)/2

                        if (!(gmp_lib.mpz_cmp(ModOperations.Pow(testNumber, pow, number), jacobi) == 0)) // Проверяем второе условие
                            return false;
                    }

                    numbersForCheck.Add(testNumber); // Добавляем число, которое только что проверили в список
                } //Выполняем указанное количество раундов
            }
            else
                return false; // Число четное => число составное
            return true;
        } // Функция выполняет тест Соловея-Штрассена на простоту числа и возвращает: false - если число гарантированно составное; true - если число простое с некоторой вероятностью
    }
}
