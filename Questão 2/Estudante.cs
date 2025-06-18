using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questão_2
{
    internal class Estudante
    {
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Curso { get; set; }

        public Estudante(int matricula, string nome, string curso)
        {
            Matricula = matricula;
            Nome = nome;
            Curso = curso;
        }

        public override string ToString()
        {
            return $"Matrícula: {Matricula} | Nome: {Nome} | Curso: {Curso}";
        }
    }
}
