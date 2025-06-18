using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questão_2
{
    internal class No_Avl
    {
        public Estudante Estudante { get; set; }
        public No_Avl Proximo { get; set; }

        public No_Avl(Estudante estudante)
        {
            Estudante = estudante;
            Proximo = null;
        }
    }
    internal class Lista
    {
        private No_Avl primeiro;

        public Lista()
        {
            primeiro = null;
        }

        public void Inserir(Estudante estudante)
        {
            No_Avl novo = new No_Avl(estudante);
            novo.Proximo = primeiro;
            primeiro = novo;
        }

        public bool Remover(int matricula)
        {
            No_Avl atual = primeiro;
            No_Avl anterior = null;

            while (atual != null)
            {
                if (atual.Estudante.Matricula == matricula)
                {
                    if (anterior == null)
                        primeiro = atual.Proximo;
                    else
                        anterior.Proximo = atual.Proximo;

                    return true;
                }

                anterior = atual;
                atual = atual.Proximo;
            }

            return false;
        }

        public Estudante Pesquisar(int matricula)
        {
            No_Avl atual = primeiro;
            while (atual != null)
            {
                if (atual.Estudante.Matricula == matricula)
                    return atual.Estudante;
                atual = atual.Proximo;
            }
            return null;
        }
    }
}
