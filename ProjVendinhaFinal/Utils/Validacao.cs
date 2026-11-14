using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendinha.Desktop.Utils
{
    public static class Validacao
    {
        public static string SomenteNumeros(string valor)
        {
            return new string(valor.Where(char.IsDigit).ToArray());
        }

        public static bool ValidarCpf(string cpf)
        {
            cpf = SomenteNumeros(cpf);
            if (cpf.Length != 11) return false;
            if (cpf.Distinct().Count() == 1) return false;

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (cpf[i] - '0') * (10 - i);

            int resto = soma % 11;
            int primeiroDigito = resto < 2 ? 0 : 11 - resto;
            if (primeiroDigito != cpf[9] - '0') return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (cpf[i] - '0') * (11 - i);

            resto = soma % 11;
            int segundoDigito = resto < 2 ? 0 : 11 - resto;
            return segundoDigito == cpf[10] - '0';
        }

        public static bool ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return true;
            return System.Text.RegularExpressions.Regex.IsMatch(
                email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$");
        }
    }
}
