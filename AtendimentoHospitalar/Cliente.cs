using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace exercicio05
{
    public class Cliente
    {
        public Cliente(string nome, string cpf, bool possuiPlano)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.possuiPlanoDeSaude = possuiPlano;
        }

        public Cliente()
        {
                
        }

        public string nome;
        public string telefone;
        public string rg;
        public string cpf;
        public string endereco;
        public bool possuiPlanoDeSaude;
    }
}
