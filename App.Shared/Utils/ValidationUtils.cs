using System;

namespace App.Shared.Utils
{
    public class ValidationUtils
    {
        public const string OBRIGATORIO = "CampoObrigatorio";
        public const string MAIOR_QUE = "MaiorQue";
        
        public static bool Preenchido(string texto)
        {
            return !string.IsNullOrEmpty(texto);
        }
        
        public static bool Preenchido(Guid id)
        {
            return true;
        }
    }
}