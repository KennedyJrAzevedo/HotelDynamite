using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDynamite
{
    class Servicos
    {
        private string desc_servico;
        private int quarto;

        public Servicos()
        {
            desc_servico = "";
            quarto = 0;
        }

        public string Desc_servico { get => desc_servico; set => desc_servico = value; }
        public int Quarto { get => quarto; set => quarto = value; }
    }
}
