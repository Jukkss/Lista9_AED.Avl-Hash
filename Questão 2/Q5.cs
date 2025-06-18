using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questão_2
{
    internal class Q5
    {
        static void MostrarMenu()
        {
            Console.WriteLine("\n========== MENU ==========");
            Console.WriteLine("1 - Inserir um estudante");
            Console.WriteLine("2 - Remover um estudante");
            Console.WriteLine("3 - Pesquisar um estudante");
            Console.WriteLine("4 - Sair");
            Console.Write("Escolha uma opção: ");
        }

        static void Main(string[] args)
        {
            Hash tabela = new Hash();
            int opcao;

            do
            {
                MostrarMenu();
                Console.Write("Opção: ");
                opcao = int.Parse(Console.ReadLine()); 
                    
                switch (opcao)
                    {
                        case 1:
                            Console.Write("Matrícula: ");
                            int mat = int.Parse(Console.ReadLine());
                            Console.Write("Nome: ");
                            string nome = Console.ReadLine();
                            Console.Write("Curso: ");
                            string curso = Console.ReadLine();
                            tabela.Inserir(new Estudante(mat, nome, curso));
                            Console.WriteLine("Estudante inserido com sucesso!");
                            break;

                        case 2:
                            Console.Write("Matrícula do estudante a remover: ");
                            int matRem = int.Parse(Console.ReadLine());
                            bool removido = tabela.Remover(matRem);
                            Console.WriteLine(removido ? "Estudante removido." : "Estudante não encontrado.");
                            break;

                        case 3:
                            Console.Write("Matrícula do estudante a pesquisar: ");
                            int matPesq = int.Parse(Console.ReadLine());
                            Estudante e = tabela.Pesquisar(matPesq);
                            Console.WriteLine(e != null ? e.ToString() : "Estudante não cadastrado.");
                            break;

                        case 4:
                            Console.WriteLine("Encerrando o programa...");
                            break;

                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }

            } while (opcao != 4);
        }
    }
}
