using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Math.Gmp.Native;

namespace SignatureRSA
{
    static class ModOperations
    {
        static public mpz_t Pow(mpz_t number, mpz_t pow, mpz_t modulo)
        {
            mpz_t currentNum = "0";
            gmp_lib.mpz_mod(currentNum, number, modulo); // Вычисляем значение числа по модулю
            mpz_t result = "1"; // Переменная для хранения результата возведения в степень по модулю
            mpz_t stepResult = currentNum; // Результат для конкретного шага
            mp_bitcnt_t bitcnt; // Счетчик бит в степени
            size_t size = gmp_lib.mpz_sizeinbase(pow, 2); // Количество бит в числе
            

            for (bitcnt = 0; bitcnt < size; bitcnt++)
            {
                if (gmp_lib.mpz_tstbit(pow, bitcnt) == 1)
                {
                    gmp_lib.mpz_mul(result, result, stepResult);
                    gmp_lib.mpz_mod(result, result, modulo); //
                }
                gmp_lib.mpz_mul(stepResult, stepResult, stepResult);
                gmp_lib.mpz_mod(stepResult, stepResult, modulo);
            }

            return result;
        } // Возведение в степень по модулю
    }
}
