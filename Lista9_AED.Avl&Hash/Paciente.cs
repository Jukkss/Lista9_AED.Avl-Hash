using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista9_AED.Avl_Hash
{
    internal class Paciente
    {
        public long Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public Paciente (long cpf, string nome, string email, string telefone)
        {
            this.Cpf = cpf;
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
        }
        public override string ToString()
        {
            return $"CPF: {Cpf} | Nome: {Nome} | Email: {Email} | Telefone: {Telefone}";
        }
    }  
}
