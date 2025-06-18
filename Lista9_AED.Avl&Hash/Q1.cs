using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista9_AED.Avl_Hash
{
    internal class Q1
    {
        static void MostrarMenu()
        {
            Console.WriteLine("=======================================");
            Console.WriteLine("      SISTEMA DE PACIENTES - MENU      ");
            Console.WriteLine("=======================================");
            Console.WriteLine("1 - Cadastrar um paciente");
            Console.WriteLine("2 - Remover um paciente (CPF)");
            Console.WriteLine("3 - Pesquisar paciente pelo CPF");
            Console.WriteLine("4 - Mostrar nomes (caminhamento central)");
            Console.WriteLine("5 - Mostrar CPFs (caminhamento pós-ordem)");
            Console.WriteLine("6 - Mostrar e-mails (caminhamento pré-ordem)");
            Console.WriteLine("7 - Sair");
        }
        static void Main(string[] args)
        {
            MostrarMenu();
            int op = int.Parse(Console.ReadLine());
            do
            {
                switch(op)
                {
                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 6:

                        break;
                    case 7:
                        break;
                    default:
                        Console.WriteLine("Escolha uma opção válida");
                        op = int.Parse(Console.ReadLine());
                        break;
                }
                Console.WriteLine("Escolha uma nova execução do menu:");
                op = int.Parse(Console.ReadLine());
            } while (op != 7);
        }
    }
}
