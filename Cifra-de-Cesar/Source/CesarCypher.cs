using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        public string Crypt(string message)
        {

            var caracs = new Regex(@"[^A-Za-z0-9_ ]");
            string resultado = "", alpha = "abcdefghijklmnopqrstuvwxyz";
            
            if (message is null)
            {
                throw new ArgumentNullException();
            }
            else if (message.Length is 0)
            {
                return String.Empty;
            }
            else if (caracs.IsMatch(message))
            {
                throw new ArgumentOutOfRangeException();
            }
            message = message.ToLower();
            foreach (var elemento in message)
            {
                if (alpha.Contains(elemento))
                {

                    int indice = alpha.IndexOf(elemento);

                    if ((indice + 3) > 25)
                    {
                        indice = (indice + 3) - 26;
                    }
                    else indice += 3;
                    resultado += alpha[indice];

                }

                else resultado += elemento;
            }
            return resultado;

        }

        public string Decrypt(string cryptedMessage)
        {
            var caracs = new Regex(@"[^A-Za-z0-9_ ]");
            string resultado = "", alpha = "abcdefghijklmnopqrstuvwxyz";
            bool vazio = string.IsNullOrEmpty(cryptedMessage);

            if (cryptedMessage is null)
            {
                throw new ArgumentNullException();
            }
            else if (cryptedMessage.Length is 0)
            {
                return String.Empty;
            }
            else if (caracs.IsMatch(cryptedMessage))
            {
                throw new ArgumentOutOfRangeException();
            }
            cryptedMessage = cryptedMessage.ToLower();
            foreach (var elemento in cryptedMessage)
            {
                if (alpha.Contains(elemento))
                {
                    int indice = alpha.IndexOf(elemento);

                    if ((indice - 3) < 0)
                    {
                        indice = (25 - 2) + indice;
                    }
                    else indice = indice - 3;

                    resultado += alpha[indice];
                }

                else resultado += elemento;

            }
            return resultado;

        }
    }
}
