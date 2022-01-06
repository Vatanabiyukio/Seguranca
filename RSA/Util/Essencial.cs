using System.Numerics;

namespace RSA.Util;

public static class Essencial
{
    private static readonly HashSet<int> LowPrimes = new HashSet<int>()
    {
        2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61,
        67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151,
        157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241,
        251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317, 331, 337, 347, 349,
        353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449,
        457, 461, 463, 467, 479, 487, 491, 499, 503, 509, 521, 523, 541, 547, 557, 563, 569,
        571, 577, 587, 593, 599, 601, 607, 613, 617, 619, 631, 641, 643, 647, 653, 659, 661,
        673, 677, 683, 691, 701, 709, 719, 727, 733, 739, 743, 751, 757, 761, 769, 773, 787,
        797, 809, 811, 821, 823, 827, 829, 839, 853, 857, 859, 863, 877, 881, 883, 887, 907,
        911, 919, 929, 937, 941, 947, 953, 967, 971, 977, 983, 991, 997
    };

    private static int Phi(int n)
    {
        var result = 1;
        for (var i = 2; i < n; i++)
            if (BigInteger.GreatestCommonDivisor(i, n) == 1)
                result++;
        return result;
    }

    public static int? InversoModular(int a, int m)
    {
        if (BigInteger.GreatestCommonDivisor(a, m) != 1)
        {
            return null;
        }

        return (int)BigInteger.ModPow(a, Phi(m) - 1, m);
    }

    private static bool RabinMiller(int num)
    {
        var s = num - 1;
        var t = 0;

        while (s % 2 == 0)
        {
            s = (int)Math.Floor(s / new decimal(2));
            t += 1;
        }

        foreach (var trials in Enumerable.Range(0, 5))
        {
            var a = new Random().Next(2, num - 1);
            var v = (int)BigInteger.ModPow(a, s, num);
            if (v == 1) continue;
            var i = 0;
            while (v != (num - 1))
            {
                if (i == t - 1)
                {
                    return false;
                }

                i += 1;
                v = (int)Math.Pow(v, 2) % num;
            }
        }

        return true;
    }

    private static bool IsPrime(int num)
    {
        if (num >= 10) return LowPrimes.All(prime => num % prime != 0) && RabinMiller(num);
        return num >= 2 && Enumerable.Range(2, 10).All(numero => num % numero != 0 || num == numero);
    }

    public static int GenerateLargePrime(int tam = 11)
    {
        while (true)
        {
            var num = new Random().Next((int)Math.Pow(2, tam - 1), (int)Math.Pow(2, tam));
            if (IsPrime(num))
            {
                return num;
            }
        }
    }
}