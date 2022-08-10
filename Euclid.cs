using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Math.Gmp.Native;

namespace SignatureRSA
{
    static class Euclid
    {
        static public mpz_t GCD(mpz_t dividend, mpz_t divisor)
        {
            if (gmp_lib.mpz_cmp_d(divisor, 0) == 0)
                return dividend;

            mpz_t mod = "0";
            gmp_lib.mpz_mod(mod, dividend, divisor);
            return GCD(divisor, mod);

        } // Алгоритм Евклида

        static public (mpz_t, mpz_t, mpz_t) GCDExt(mpz_t dividend, mpz_t divisor)
        {
            (mpz_t, mpz_t, mpz_t) vectorU = (dividend, "1", "0");
            (mpz_t, mpz_t, mpz_t) vectorV = (divisor, "0", "1");

            while (gmp_lib.mpz_cmp_d(vectorV.Item1, 0) != 0)
            {
                (mpz_t, mpz_t, mpz_t) vectorT = ("0", "0", "0");
                mpz_t div = "0"; // Целая часть от деления

                gmp_lib.mpz_fdiv_q(div, vectorU.Item1, vectorV.Item1); // Рассчитываем целую часть от деления

                gmp_lib.mpz_mod(vectorT.Item1, vectorU.Item1, vectorV.Item1); // Размещаем остаток от деления в первом компоненте строки temp

                gmp_lib.mpz_mul(vectorT.Item2, div, vectorV.Item2);
                gmp_lib.mpz_sub(vectorT.Item2, vectorU.Item2, vectorT.Item2); // Размещаем результат рассчета выражения u2 - q*v2 во второй компоненте строки temp

                gmp_lib.mpz_mul(vectorT.Item3, div, vectorV.Item3);
                gmp_lib.mpz_sub(vectorT.Item3, vectorU.Item3, vectorT.Item3); // Размещаем результат рассчета выражения u3 - q*v3 в третьей компоненте строки temp

                vectorU = vectorV;
                vectorV = vectorT;
            }

            return vectorU;
        } // Расширенный алгоритм Евклида

        static public mpz_t Inversion(mpz_t modulo, mpz_t number)
        {
            mpz_t inversion = "0"; // Объявляем переменную для хранения инверсии
            mpz_t currentNum = "0";
            gmp_lib.mpz_mod(currentNum, number, modulo); // Вычисляем значение числа по модулю

            (mpz_t, mpz_t, mpz_t) vector = GCDExt(modulo, currentNum); // Используем расширенный алгоритм Евклида

            inversion = vector.Item3; // Извлекаем значение инверсии
            gmp_lib.mpz_mod(inversion, inversion, modulo); // Определяем значение инверсии по модулю (положительное)

            return inversion; // Возвращаем инверсию
        } // Инверсия
    }
}
