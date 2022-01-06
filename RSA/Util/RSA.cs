using RSA.Modelos;

namespace RSA.Util;

public static class RSA
{
    // public static byte Criptografar(Mensagem mensagem)
    // {
    //     return Convert.ToByte(Math.Pow(mensagem.MsgByte, mensagem.ChavePublica.E) % mensagem.ChavePublica.N);
    // }
    //
    // public static byte? Descriptografar(Mensagem mensagem)
    // {
    //     return mensagem.Criptografada.Equals(true) && mensagem.ChavesParValida.Equals(true) ? Convert.ToByte(Math.Pow(mensagem.MsgByte, mensagem.ChavePrivada.D) % mensagem.ChavePrivada.N) : null;
    // }
}