using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDynamite
{
    class Hospedagem
    {
        private int id;
        private string nome;
        private string cpf;
        private int quarto;
        public Hospedagem()
        {
            id = 0;
            nome = "";
            cpf = "";
            quarto = 0;
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public int Quarto { get => quarto; set => quarto = value; }


    }
}
