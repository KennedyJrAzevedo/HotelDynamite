using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDynamite
{
    class Menu
    {
        public void Opcao(string[] menu)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            foreach (string opcoes in menu)
            {
                Console.Write($"{opcoes}\n");
            }
            Console.ResetColor();
        }
        public bool Validacao(string cpf)
        {
            bool validacao = false;
            if (cpf.Length == 11)
            {
                validacao = true;
            }
            return validacao;
        }
    }
}
