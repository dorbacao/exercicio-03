using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio05
{
    internal class Hospital
    {
        internal string nome;
        internal string endereco;
        internal string telefone;

        public Hospital(string nome, string telefone)
        {
            this.nome = nome;
            this.telefone = telefone;
        }

        internal Atendimento Atender(Cliente cliente)
        {
            if (cliente.nome == string.Empty)
            {
                Console.WriteLine("O nome do cliente é obrigatório");
            }

            if (cliente.rg == string.Empty)
            {
                Console.WriteLine("O RG do cliente é obrigatório");
            }

            DateTime dataAtendimento = DateTime.Now;

            Atendimento atendimento = new Atendimento(cliente, this, dataAtendimento);

            return atendimento;
        }
    }
}
