using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questão_7
{
    internal class Q7
    {
        static void MostrarMenu()
        {
            Console.WriteLine("\n======== MENU HASH (SONDAGEM LINEAR) ========");
            Console.WriteLine("1 - Inserir um número");
            Console.WriteLine("2 - Remover um número");
            Console.WriteLine("3 - Pesquisar um número");
            Console.WriteLine("4 - Sair");
            Console.Write("Escolha uma opção: ");
        }

        static void Main(string[] args)
        {
            HashLinear tabela = new HashLinear();
            int opcao;

            do
            {
                MostrarMenu();
                Console.Write("Opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("Digite o número a ser inserido: ");
                        int numInsert = int.Parse(Console.ReadLine());
                        if (tabela.Inserir(numInsert))
                            Console.WriteLine("Número inserido com sucesso.");
                        else
                            Console.WriteLine("Erro: número já existe ou tabela cheia.");
                        break;

                    case 2:
                        Console.Write("Digite o número a ser removido: ");
                        int numRemove = int.Parse(Console.ReadLine());
                        if (tabela.Remover(numRemove))
                            Console.WriteLine("Número removido.");
                        else
                            Console.WriteLine("Número não encontrado.");
                        break;

                    case 3:
                        Console.Write("Digite o número a ser pesquisado: ");
                        int numBusca = int.Parse(Console.ReadLine());
                        Console.WriteLine(tabela.Pesquisar(numBusca)
                            ? "Número encontrado na tabela."
                            : "Número não encontrado.");
                        break;

                    case 4:
                        Console.WriteLine("Encerrando...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                tabela.MostrarTabela();

            } while (opcao != 4);
        }
    }
}
