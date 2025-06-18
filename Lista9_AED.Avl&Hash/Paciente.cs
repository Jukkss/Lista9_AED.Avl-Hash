using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista9_AED.Avl_Hash
{
    internal class Paciente
    {
        private long Cpf { get; set; }
        private string Nome { get; set; }
        private string Email { get; set; }
        private string Telefone { get; set; }

        public Paciente (long cpf, string nome, string email, string telefone)
        {
            this.Cpf = cpf;
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
        }
    }  
}
