using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDynamite
{
    class Program
    {

        //Chamando classe Lista
        public static Menu lista = new Menu();
        //inicialização de variáveis
        private static Stack<int> ListQuarto = new Stack<int>(40);
        private static List<Hospedagem> hospedagem = new List<Hospedagem>();
        private static Queue<Servicos> Servicos = new Queue<Servicos>();

        static void Main(string[] args)
        {
            //adicionando a quantidade de quartos disponíveis
            for (int i = 40; i >= 1; i--)
            {
                ListQuarto.Push(i);
            }
            //direcnando para menu principal
            Menu();
        }
        //menu principal
        static void Menu()
        {
            Console.Clear();
            //
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Hotel Dynamite");
            Console.ResetColor();

            //opções do menu
            string[] menu = new string[4] { "1 - Hospedagem", "2 - Serviços", "3 - Sobre", "0 - Sair" };
            lista.Opcao(menu);

            Console.Write("Escolha uma opção:");
            //variavel opção
            if (int.TryParse(Console.ReadLine(), out int opc))
            {
                Console.Clear();
                //direcionando para a opção que o usuário digitou
                switch (opc)
                {
                    case 0:
                        return;
                    case 1:
                        Hospedagem();
                        break;
                    case 2:
                        MenuServicos();
                        break;
                    case 3:
                        Sobre();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Você digitou uma opção inexistente, Tente Novamente!");
                        Console.ReadKey();
                        Menu();
                        break;
                }
            }
            Menu();


        }
        //menu hospedagem
        static void Hospedagem()
        {
            Console.Clear();
            Console.WriteLine("Hospedagem");
            //opções do menu
            string[] menu = new string[4] { "1 - Inserir hospedagem", "2 - Listar hospedagem", "3 - Remover hospedagem", "0 - Voltar" };
            lista.Opcao(menu);
            Console.Write("Escolha uma opção:");
            //variavel opção
            if (int.TryParse(Console.ReadLine(), out int opc))
            {

                switch (opc)
                {
                    case 0:
                        Menu();
                        break;
                    case 1:
                        InserirHosp();
                        break;
                    case 2:
                        ListarHosp();
                        break;
                    case 3:
                        RemoverHosp();
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Você digitou uma opção inexistente, Tente Novamente!");
            }

            Hospedagem();
        }
        static void MenuServicos()
        {
            Console.Clear();
            Console.WriteLine("Serviço");
            string[] menu = new string[4] { "1 - Inserir Serviço", "2 - Serviços pendentes", "3 - Finalizar Serviço", "0 - Voltar" };
            lista.Opcao(menu);
            Console.Write("Escolha uma opção:");
            if (int.TryParse(Console.ReadLine(), out int opc))
            {
                switch (opc)
                {
                    case 0:
                        Menu();
                        break;
                    case 1:
                        InserirServ();
                        break;
                    case 2:
                        ListarServ();
                        break;
                    case 3:
                        FinalizarServ();
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Você digitou uma opção inexistente, Tente Novamente!");
            }
            Console.Clear();
            MenuServicos();
        }

        static void InserirServ()
        {
        InserirServ:
            Console.Write("Digite a descrição do Serviço:");
            string desc_servico = Console.ReadLine();

            int quarto;
            do
            {
                Console.Write("\nDigite o quarto do Serviço:");
            } while (int.TryParse(Console.ReadLine(), out quarto) == false);
            char conf;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nDeseja confirmar?(s/n)");
                Console.ResetColor();
                conf = char.Parse(Console.ReadLine().ToLower());
            } while ((conf == 's' || conf == 'n') == false);
            if (conf == 's')
            {
                Servicos servico = new Servicos();
                servico.Desc_servico = desc_servico;
                servico.Quarto = quarto;
                Servicos.Enqueue(servico);
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Serviço criado com sucesso!");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }
            goto InserirServ;
        }
        static void ListarServ()
        {
            if (Servicos.Count > 0)
            {
                foreach (var n in Servicos)
                {
                    if (n != null)
                    {
                        Console.WriteLine(n.Desc_servico);
                        Console.WriteLine(n.Quarto);
                        Console.WriteLine("---------------------");
                    }
                    else
                    {
                        Console.WriteLine("Nenhum serviço encontrado!");
                    }
                }
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Não há serviços disponíveis!");
            Console.ReadKey();
        }
        static void FinalizarServ()
        {
            List<Servicos> servicos_deq = new List<Servicos>();
            int servrealizado;
            do
            {
                Console.WriteLine("Digite o quarto do serviço realizado:");
            } while (int.TryParse(Console.ReadLine().Trim(), out servrealizado) == false);

            while (Servicos.Count > 0)
            {
                if (Servicos.Peek().Quarto.Equals(servrealizado))
                {
                    Console.WriteLine($"Descrição Serviço: {Servicos.Peek().Desc_servico}");
                    Servicos.Dequeue();
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Serviço Finalizado com sucesso!");
                    Console.ResetColor();
                    break;
                }
                servicos_deq.Add(Servicos.Dequeue());
            }

            while (servicos_deq.Count > 0)
            {
                Servicos.Enqueue(servicos_deq.Last());
                servicos_deq.Remove(servicos_deq.Last());
            }
            servicos_deq.Clear();
            Console.ReadKey();
        }
        static void Sobre()
        {
            Console.WriteLine("Sobre o Hotel Dynamite\nBem - vindo ao Hotel Dynamite, onde sua estadia será uma explosão de conforto e alegria! Mais do que um simples hotel,\nsomos a sua base para uma experiência memorável.");
            Console.ReadKey();
            Console.Clear();
        }
        static void InserirHosp()
        {
            //Mostrar os quartos disponíveis do hotel
            Console.Write("Quartos disponíveis: ");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (int numeros in ListQuarto)
            {
                Console.Write($"| {numeros} |");
            }
            Console.ResetColor();
            //Add nome hospede
            Console.Write("\nDigite o nome do hospede: ");
            string nome = Console.ReadLine();
            //Add cpf hospede
            string cpf;
            do
            {
                Console.Write("\nDigite o CPF do hospede(11 caracteres): ");
                cpf = Console.ReadLine();

            } while (lista.Validacao(cpf) == false);
            //Add quarto hospede
            int quarto = -1;
            do
            {
                Console.Write("\nQuarto desejado: ");
                if (int.TryParse(Console.ReadLine(), out quarto) == false)
                {
                    Console.WriteLine("\nErro de dígito, tente novamente!");
                    Console.Beep();
                };
            } while (quarto < 0 || quarto > 40);
            string conf;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nDeseja confirmar?(s/n)");
                Console.ResetColor();
                conf = Console.ReadLine().ToLower();

            } while (conf != "s" && conf != "n");
            if (conf == "s")
            {
                Stack<int> guardavar = new Stack<int>();
                Hospedagem hospede = new Hospedagem();
                hospede.Id = hospedagem.Count + 1;
                hospede.Nome = nome;
                hospede.Cpf = cpf;
                hospede.Quarto = quarto;
                bool valido = false;
                do
                {
                    if (ListQuarto.Count > 0)
                    {
                        if (ListQuarto.Peek() == quarto)
                        {
                            hospedagem.Add(hospede);
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("Hospedagem criada com sucesso!");
                            Console.ResetColor();
                            Console.ReadKey();
                            ListQuarto.Pop();
                            valido = true;
                        }
                        else
                        {
                            guardavar.Push(ListQuarto.Pop());
                        }
                    }
                    else
                    {
                        valido = true;
                        Console.WriteLine("Esse quarto não está disponível!");
                        Console.ReadKey();
                    }
                } while (valido == false);
                while (guardavar.Count() > 0)
                {
                    ListQuarto.Push(guardavar.Pop());
                }
            }
        }
        static void ListarHosp()
        {
            if (hospedagem.Count > 0)
            {
                foreach (Hospedagem n in hospedagem)
                {
                    if (n != null)
                    {
                        Console.WriteLine($"Identificação: {n.Id}");
                        Console.WriteLine($"Nome: {n.Nome}");
                        Console.WriteLine($"CPF: {n.Cpf}");
                        Console.WriteLine($"Quarto: {n.Quarto}");
                        Console.WriteLine("\n---------------------");
                    }
                }
            }
            else
            {
                Console.WriteLine("Nenhuma hospedagem no momento!");
            }
            Console.ReadKey();
        }
        static void RemoverHosp()
        {
            string cpf;
            do
            {
                Console.WriteLine("Digite o CPF do hospede que você quer Remover: ");
                cpf = Console.ReadLine();
            } while (lista.Validacao(cpf) == false);

            foreach (Hospedagem n in hospedagem)
            {
                if (n != null)
                {
                    if (cpf == n.Cpf)
                    {
                        Console.WriteLine($"Identificação: {n.Id}");
                        Console.WriteLine($"Nome: { n.Nome}");
                        Console.WriteLine($"CPF: { n.Cpf}");
                        Console.WriteLine($"Quarto: { n.Quarto}");

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Quer realmente excluir?(s/n)");
                        Console.ResetColor();

                        char opc = char.Parse(Console.ReadLine().ToLower());
                        if (opc.Equals('s'))
                        {
                            if (hospedagem.Remove(n))
                            {
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("Hospedagem removida com sucesso!");
                                Console.ResetColor();
                            }
                        }
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum hospede cadastrado!");
                }
            }
            Console.ReadKey();
        }
    }
}