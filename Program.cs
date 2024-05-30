using System;
using System.Collections.Generic;
using System.Threading;

namespace RegistroDeClientes
{
    internal class Program
    {
        enum Opcao { Adicionar = 1, Deletar, Verificar };

        static List<string> nomes = new List<string>();
        static List<string> emails = new List<string>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Olá, seja bem-vindo!\nO que gostaria de fazer?");
                Thread.Sleep(1500);
                Console.WriteLine("========================================================");
                Console.WriteLine("1 - Adicionar Cliente\n2 - Deletar Cliente\n3 - Verificar Cliente\n4 - Sair");
                Console.Write("Selecione uma opção: ");
                int selecao = 0;
                int.TryParse(Console.ReadLine(), out selecao);
                Opcao opcaoSelecionada = (Opcao)selecao;

                switch (opcaoSelecionada)
                {
                    case Opcao.Adicionar:
                        AdicionarCliente();
                        break;
                    case Opcao.Deletar:
                        DeletarCliente();
                        break;
                    case Opcao.Verificar:
                        VerificarClientes();
                        break;
                    default:
                        Console.WriteLine("Saindo do programa...");
                        return;
                }
            }
        }

        static void AdicionarCliente()
        {
            Console.Clear();
            Console.WriteLine("Digite o nome e email do cliente");
            Console.Write("Nome: ");
            string nomeCliente = Console.ReadLine();
            Console.Write("Email: ");
            string emailCliente = Console.ReadLine();

            nomes.Add(nomeCliente);
            emails.Add(emailCliente);

            Console.WriteLine("Cliente adicionado com sucesso!");
            Thread.Sleep(1500);
        }

        static void DeletarCliente()
        {
            Console.Clear();
            Console.WriteLine("Digite o nome do cliente a ser deletado:");
            string nomeCliente = Console.ReadLine();

            int index = nomes.IndexOf(nomeCliente);

            if (index != -1)
            {
                nomes.RemoveAt(index);
                emails.RemoveAt(index);
                Console.WriteLine("Cliente deletado com sucesso!");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }

            Thread.Sleep(1500);
        }

        static void VerificarClientes()
        {
            Console.Clear();
            Console.WriteLine("Clientes registrados:");
            if (nomes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente registrado ainda.");
            }
            else
            {
                for (int i = 0; i < nomes.Count; i++)
                {
                    Console.WriteLine($"Nome: {nomes[i]}, Email: {emails[i]}");
                }
            }

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }
    }
}
