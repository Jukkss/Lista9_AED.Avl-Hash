using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questão_7
{
    internal class HashLinear
    {
        private int?[] tabela;
        private int m = 13;

        public HashLinear()
        {
            tabela = new int?[m];
        }

        private int FuncaoHash(int valor)
        {
            return valor % m;
        }

        public bool Inserir(int valor)
        {
            int pos = FuncaoHash(valor);
            int tentativas = 0;

            while (tentativas < m)
            {
                int index = (pos + tentativas) % m;
                if (tabela[index] == null || tabela[index] == int.MinValue)
                {
                    tabela[index] = valor;
                    return true;
                }
                else if (tabela[index] == valor)
                {
                    return false; 
                }
                tentativas++;
            }

            return false; 
        }

        public bool Remover(int valor)
        {
            int pos = FuncaoHash(valor);
            int tentativas = 0;

            while (tentativas < m)
            {
                int index = (pos + tentativas) % m;
                if (tabela[index] == null)
                    return false;

                if (tabela[index] == valor)
                {
                    tabela[index] = int.MinValue; 
                    return true;
                }

                tentativas++;
            }

            return false;
        }

        public bool Pesquisar(int valor)
        {
            int pos = FuncaoHash(valor);
            int tentativas = 0;

            while (tentativas < m)
            {
                int index = (pos + tentativas) % m;
                if (tabela[index] == null)
                    return false;

                if (tabela[index] == valor)
                    return true;

                tentativas++;
            }

            return false;
        }

        public void MostrarTabela()
        {
            Console.WriteLine("\nTabela atual:");
            for (int i = 0; i < m; i++)
            {
                Console.WriteLine($"[{i}] => {(tabela[i] == null ? "vazio" : tabela[i] == int.MinValue ? "removido" : tabela[i].ToString())}");
            }
        }
    }
}
