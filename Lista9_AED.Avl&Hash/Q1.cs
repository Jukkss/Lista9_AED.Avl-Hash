using System;

namespace Lista9_AED.Avl_Hash
{
    internal class Q1
    {
        static void MostrarMenu()
        {
            Console.WriteLine("\n=======================================");
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
            Avl avl = new Avl();
            int op;

            do
            {
                MostrarMenu();
                Console.Write("Opção: ");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        Console.Write("CPF: ");
                        long cpf = long.Parse(Console.ReadLine());
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();
                        Console.Write("Email: ");
                        string email = Console.ReadLine();
                        Console.Write("Telefone: ");
                        string telefone = Console.ReadLine();
                        avl.Inserir(new Paciente(cpf, nome, email, telefone));
                        break;

                    case 2:
                        Console.Write("Informe o CPF a ser removido: ");
                        long cpfRemover = long.Parse(Console.ReadLine());
                        avl.Remover(cpfRemover);
                        break;

                    case 3:
                        Console.Write("Informe o CPF para busca: ");
                        long cpfBuscar = long.Parse(Console.ReadLine());
                        var paciente = avl.Pesquisar(cpfBuscar);
                        if (paciente == null)
                            Console.WriteLine("Paciente não cadastrado.");
                        else
                            Console.WriteLine(paciente);
                        break;

                    case 4:
                        Console.WriteLine("Nomes (central):");
                        avl.CaminharCentral();
                        break;

                    case 5:
                        Console.WriteLine("CPFs (pós-ordem):");
                        avl.CaminharPos();
                        break;

                    case 6:
                        Console.WriteLine("E-mails (pré-ordem):");
                        avl.CaminharPre();
                        break;

                    case 7:
                        Console.WriteLine("Encerrando...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            } while (op != 7);
        }
    }
}

