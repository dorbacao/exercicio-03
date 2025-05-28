using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio05
{
    internal class Atendimento
    {
        public Atendimento(Cliente cliente, Hospital hospital, DateTime dataAtendimento)
        {
            this.cliente = cliente;
            this.hospital = hospital;
            this.dataAtendimento = dataAtendimento;
        }
        internal Cliente cliente;
        internal Hospital hospital;
        internal DateTime dataAtendimento;
    }
}
