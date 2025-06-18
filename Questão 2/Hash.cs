using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questão_2
{
    internal class Hash
    {
        private Lista[] tabela;
        private int m = 101;

        public Hash()
        {
            tabela = new Lista[m];
            for (int i = 0; i < m; i++)
                tabela[i] = new Lista();
        }

        private int HashFunc(int matricula)
        {
            return matricula % m;
        }

        public void Inserir(Estudante estudante)
        {
            int pos = HashFunc(estudante.Matricula);
            tabela[pos].Inserir(estudante);
        }

        public bool Remover(int matricula)
        {
            int pos = HashFunc(matricula);
            return tabela[pos].Remover(matricula);
        }

        public Estudante Pesquisar(int matricula)
        {
            int pos = HashFunc(matricula);
            return tabela[pos].Pesquisar(matricula);
        }
    }
}
