using System.Security.Cryptography;
using System.Text;

public static class Criptografia
{

    public static string GerarHash(string texto)

    {
        SHA256 sha256 = SHA256.Create();
        byte[] textoBytes = Encoding.UTF8.GetBytes(texto);
        byte[] hashByes = sha256.ComputeHash(textoBytes);
        StringBuilder resultado = new StringBuilder();
        foreach (byte b in hashByes)
        {
            resultado.Append(b.ToString("x2"));//transforma em hexadecimal
        }
        return resultado.ToString();

    }



}

