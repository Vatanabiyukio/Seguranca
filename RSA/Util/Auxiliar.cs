using System.Numerics;
using RSA.Modelos.Chaves;

namespace RSA.Util;

public class Auxiliar
{
    // public static (Publica publicKey, Privada privateKey) GerarChaves(int keySize=1024)
    // {
    //     int n, e;
    //     int? d;
    //     
    //     while (true)
    //     {
    //         var p = Essencial.GenerateLargePrime(keySize);
    //         var q = Essencial.GenerateLargePrime(keySize);
    //         n = p * q;
    //
    //         while (true)
    //         {
    //             e = new Random().Next((int)Math.Pow(2, keySize - 1), (int)Math.Pow(2, keySize));
    //             if (BigInteger.GreatestCommonDivisor(e, (p - 1) * (q - 1)) == 1)
    //             {
    //                 break;
    //             }
    //         }
    //
    //         d = Essencial.InversoModular(e, (p - 1) * (q - 1));
    //         if (d.HasValue) break;
    //     }
    //
    //     var publicKey = new Publica(n, e);
    //     var privateKey = new Privada(n, (int)d);
    //     return (publicKey, privateKey);
    // }
}