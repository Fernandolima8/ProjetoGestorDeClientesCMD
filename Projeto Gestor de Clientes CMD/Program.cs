using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Projeto_Gestor_de_Clientes_CMD
{
    internal class Program
    {
        [System.Serializable]
        struct Cliente {
            public string Nome;
            public string Email;
            public string CPF;
        
        
        }
        static List<Cliente> Clientes = new List<Cliente>();

        enum Menu {Listagem = 1, Adicionar, Remover, Sair}
        
        
        
        static void Main(string[] args)
        {
            bool escolheuSair = false;
            Carregar();
            while (!escolheuSair) {
                Console.WriteLine("Sistemas de Clientes - Bem vindo!");
                Console.WriteLine("1-Listagem");
                Console.WriteLine("2-Adicionar");
                Console.WriteLine("3-Remover");
                Console.WriteLine("4-Sair");
                int intOp = int.Parse(Console.ReadLine());
                Menu opcao = (Menu)intOp;

                switch (opcao)
                {
                    case Menu.Adicionar:
                        Adicionar();
                        break;

                    case Menu.Listagem:
                        Listagem();
                        break;

                    case Menu.Remover:
                        Remover();
                        break;
                    case Menu.Sair:
                        escolheuSair = true;
                        break;


                }
                Console.Clear();


            }
            


        }
        static void Adicionar() { 
        Cliente cliente = new Cliente();
            Console.Write("Cadastro de Cliente: ");
            Console.Write("Nome do cliente: ");
            cliente.Nome = Console.ReadLine();
            Console.Write("Email do Cliente: ");
            cliente.Email = Console.ReadLine();
            Console.Write("CPF do cliente: ");
            cliente.Email = Console.ReadLine();

            Clientes.Add(cliente);
            Salvar();
            Console.Write("Cadastro Concluido, Aperte ENTER para sair.");
            Console.ReadLine();
        
        
        }
        static void Listagem() {

            if (Clientes.Count > 0)
            {
                Console.WriteLine("Lista de Clientes:");
                int i = 0;
                foreach (Cliente cliente in Clientes)
                {
                    Console.WriteLine($"ID: {i}");
                    Console.WriteLine($"Nome: {cliente.Nome}");
                    Console.WriteLine($"E-mail: {cliente.Email}");
                    Console.WriteLine($"CPF: {cliente.CPF}");
                    Console.WriteLine("=============================");
                    i++;

                }


            }
            else 
            {

                Console.WriteLine("Nenhum cliente cadastrado");
            }
            Console.WriteLine("Aperte ENTER para sair.");
            Console.ReadLine();
        
        
        }
        static void Remover() 
        {
            Listagem();
            Console.Write("Digite o ID que deseja remover:");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < Clientes.Count)
            {
                Clientes.RemoveAt(id);
                Salvar();


            }
            else {
                Console.WriteLine("Id Invalido !!");
                Console.ReadLine();
            
            
            }
        
        
        
        }
        
        
        
        
        static void Salvar() {
            FileStream Stream = new FileStream("Clientes.dat",FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter(); 
            
            encoder.Serialize(Stream, Clientes);
            Stream.Close();
        
        
        
        
        
        }
        static void Carregar()
        {
            FileStream Stream = new FileStream("Clientes.dat", FileMode.OpenOrCreate);
            try
            {
                BinaryFormatter encoder = new BinaryFormatter();

                Clientes = (List<Cliente>)encoder.Deserialize(Stream);
                if (Clientes == null) { 
                 Clientes = new List<Cliente>();
                
                }
                
            }
            catch (Exception e) 
            { 
            
            Clientes = new List<Cliente>();
            
            }
            Stream.Close();
        }
    }
}
