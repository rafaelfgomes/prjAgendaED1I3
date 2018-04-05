using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjAgendaED1I3
{
    class Program
    {

        static int opcao, codigo, qtdDeContatos = 0;
        static string[] email = new string[10], nome = new string[10], telefone = new string[10], sexo = new string[10];
        static char familiar;
        static DateTime[] dtNasc = new DateTime[10];
        static bool[] familia = new bool[10];
        static bool flagCodigo = false;

        static void Main(string[] args)
        {

            do
            {

                Console.Clear();

                Console.WriteLine("AGENDA\n\n");

                Console.Write("0. Finalizar\n");
                Console.Write("1. Cadastrar contato\n");
                Console.Write("2. Consultar contato\n");
                Console.Write("3. Excluir contato\n");
                Console.Write("4. Listar contatos\n\n");
                Console.Write("Sua opção: ");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 0:

                        Console.Write("\nFim do programa\nPressione qualquer tecla para fechar...");
                        Console.ReadKey();

                        break;
                    case 1:

                        qtdDeContatos++;

                        if (qtdDeContatos > 10)
                        {

                            Console.Write("\nNão é possível acrescentar mais contatos");

                            Console.ReadKey();

                        }
                        else
                        {

                            cadastrar();

                            Console.ReadKey();

                        }

                        break;

                    case 2:

                        if (qtdDeContatos == 0)
                        {

                            Console.Write("\nNão há contatos cadastrados para consulta");

                            Console.ReadKey();

                        }
                        else
                        {

                            consultar();

                            Console.ReadKey();

                        }

                        break;

                    case 3:

                        if (qtdDeContatos == 0)
                        {

                            Console.Write("\nNão há contatos cadastrados para exclusão");

                            Console.ReadKey();

                        }
                        else
                        {

                            excluir();

                            Console.ReadKey();

                        }

                        break;

                    case 4:

                        if (qtdDeContatos == 0)
                        {

                            Console.Write("\nNão há contatos cadastrados para consulta");

                            Console.ReadKey();

                        }
                        else
                        {

                            listar();

                            Console.ReadKey();

                        }

                        break;

                    default:

                        Console.Write("\nOpção inválida");
                        Console.ReadKey();

                        break;

                }

            } while (opcao != 0);

        }

        public static DateTime converteData(string data)
        {

            return DateTime.Parse(data);

        }

        public static void cadastrar()
        {

            do
            {
                Console.Write("\nInforme o código do contato: ");
                codigo = int.Parse(Console.ReadLine());

                if (codigo <= 0)
                {

                    Console.Write("Código inválido\n");

                }
                else if (codigo > 10)
                {

                    Console.Write("São válidos somente códigos de 1 a 10\n");

                }
                else if (verificaCodigo(codigo - 1))
                {

                    Console.Write("Código já cadastrado em outro contato\n");

                }
                else
                {

                    flagCodigo = true;

                }

            } while (flagCodigo == false);

            Console.Write("\nInforme o email do contato: ");
            email[codigo - 1] = Console.ReadLine();

            Console.Write("Informe o nome do contato: ");
            nome[codigo - 1] = Console.ReadLine();

            Console.Write("Informe o telefone do contato: ");
            telefone[codigo - 1] = Console.ReadLine();

            Console.Write("Informe o sexo do contato: ");
            sexo[codigo - 1] = Console.ReadLine();

            Console.Write("Informe a data de nascimento do contato (dd/mm/yyyy): ");
            dtNasc[codigo - 1] = converteData(Console.ReadLine());

            Console.Write("Contato familiar? (S/N): ");
            familiar = char.Parse(Console.ReadLine());

            if (familiar == 'S' || familiar == 's')
            {

                familia[codigo - 1] = true;

            }
            else if (familiar == 'N' || familiar == 'n')
            {

                familia[codigo - 1] = false;

            }

            Console.Write("\nContato cadastrado com sucesso...");
            flagCodigo = false;

        }

        public static void consultar()
        {

            string cp;

            Console.Write("\n---> Pesquisar por (c)ódigo ou (e)mail?: ");
            cp = criterioPesquisa();

            if (cp == "c")
            {

                int pc = pesquisaPorCodigo();

                if (!(verificaCodigo(pc - 1)))
                {

                    Console.Write("Contato não encontrado");

                }
                else
                {

                    mostrarDados(pc - 1);

                }

            }
            else if (cp == "e")
            {

                int pe = pesquisaPorEmail();

                if (pe == 0)
                {

                    Console.Write("Contato não encontrado");

                }
                else
                {

                    mostrarDados(pe);

                }

            }
            else
            {

                Console.Write("Opção inválida!!!!");

            }

        }

        public static void excluir()
        {

            string cp;

            Console.Write("\n---> Pesquisar por (c)ódigo ou (e)mail?: ");
            cp = criterioPesquisa();

            if (cp == "c")
            {

                int pc = pesquisaPorCodigo();

                if (!(verificaCodigo(pc - 1)))
                {

                    Console.Write("Contato não encontrado");

                }
                else
                {

                    excluirDados(pc - 1);

                }

            }
            else if (cp == "e")
            {

                int pe = pesquisaPorEmail();

                if (pe == 0)
                {

                    Console.Write("Contato não encontrado");

                }
                else
                {

                    excluirDados(pe);

                }

            }
            else
            {

                Console.Write("Opção inválida!!!!");

            }

        }

        public static void listar()
        {

            Console.WriteLine();

            for (int i = 0; i < 10; i++)
            {

                if (verificaCodigo(i))
                {

                    Console.Write("---------------------------------------------");
                    mostrarDados(i);

                }

            }

            Console.Write("---------------------------------------------");

        }

        public static void mostrarDados(int codigo)
        {

            Console.WriteLine();

            Console.Write("Código: {0}\n", codigo + 1);
            Console.Write("E-mail: {0}\n", email[codigo]);
            Console.Write("Nome: {0}\n", nome[codigo]);
            Console.Write("Telefone: {0}\n", telefone[codigo]);
            Console.Write("Sexo: {0}\n", sexo[codigo]);
            Console.Write("Data Nascimento: {0}\n", dtNasc[codigo].ToShortDateString());

            if (familia[codigo])
            {

                Console.Write("Família: S\n");

            }
            else
            {

                Console.Write("Família: N\n");

            }


        }

        public static void excluirDados(int codigo)
        {

            email.SetValue(null, codigo);
            nome.SetValue(null, codigo);
            telefone.SetValue(null, codigo);
            sexo.SetValue(null, codigo);
            dtNasc.SetValue(null, codigo);

            Console.Write("Contato foi excluido");

            qtdDeContatos--;

        }

        public static string criterioPesquisa()
        {

            return Console.ReadLine();

        }

        public static int pesquisaPorCodigo()
        {

            int cd;
            Console.Write("\nInforme o código do contato: ");
            cd = int.Parse(Console.ReadLine());

            return cd;

        }

        public static int pesquisaPorEmail()
        {

            string e;
            int cd = 0;

            Console.Write("\nInforme o e-mail do contato: ");
            e = Console.ReadLine();

            for (int i = 0; i < 10; i++)
            {

                if (email[i] == e)
                {

                    cd = i;

                }

            }

            return cd;

        }

        public static bool verificaCodigo(int cod)
        {

            if (email[cod] != null && nome[cod] != null && telefone[cod] != null && sexo[cod] != null && dtNasc[cod] != null)
            {

                return true;

            }
            else
            {

                return false;

            }

        }

    }//class

}//namespace
