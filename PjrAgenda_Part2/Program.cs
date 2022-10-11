using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PjrAgenda_Part2.Controllers;
using PjrAgenda_Part2.Models;

namespace PjrAgenda_Part2
{
    internal class Program
    {

        #region INSERT
        public static void InsertContato()
        {
            Contact cont = new Contact();

            Console.Write(" Digite o nome: ");
            cont.Name = Console.ReadLine();

            bool check = ContactController.CheckContact(cont.Name);
            if (check)
            {
                Console.WriteLine("\nPressione ENTER para continuar");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {

                Console.Write(" Digite o apelido: ");
                cont.Surname = Console.ReadLine();
                Console.Write(" Digite o email: ");
                cont.Email = Console.ReadLine();


                //cont.Name = "Luciano";

                //cont.Surname = "Juliano";

                //cont.Email = "Junior@gmail.com";



                // Console.WriteLine(" Agora informa os numeros telefonicos");
                Telephone tel = new Telephone();

                tel.Name = cont.Name;

                Console.Write(" Digite o numero de telefone: ");
                tel.Phone = Console.ReadLine();
                Console.Write(" Digite o numero de celular: ");
                tel.Mobile = Console.ReadLine();


                //tel.Phone = "32531045";

                //tel.Mobile = "16996373631";

                Console.WriteLine(" Aguarde um momento . . . \n Estamos salvando as informações . . . ");
                ContactController.InsertContact(cont);

                TelephoneController.InsertTelephone(tel);
                Console.Clear();

                Console.WriteLine(" Informações foram salvas com sucesso !!!\n");
                Console.WriteLine(cont.ToString());
                Console.WriteLine(tel.ToString());

                Console.WriteLine("\nPressione ENTER para continuar");
                Console.ReadKey();
                Console.Clear();
            }
        }
        #endregion

        #region PRINT LIST
        public static void PrintListContact()
        {
            Console.WriteLine(" Lista de contatos");
             ContactController.PrintListContact();

            Console.WriteLine("\nPressione ENTER para continuar");
            Console.ReadKey();
            Console.Clear();
        }
        public static void PrintListTelephone()
        {
            Console.WriteLine(" Lista de telephones");
            TelephoneController.PrintListTelephone();

            Console.WriteLine("\nPressione ENTER para continuar");
            Console.ReadKey();
            Console.Clear();
        }
        #endregion

        #region SELECT
        public static void SelectContact()
        {
            Console.Write(" Digite o nome para ver suas informações: ");
            string nome = Console.ReadLine();
            var contact = ContactController.SelectContact(nome);
           // Console.WriteLine(contact.ToString());

            Console.WriteLine("\nPressione ENTER para continuar");
            Console.ReadKey();
            Console.Clear();
        }
        public static void SelectTelephone()
        {
            Console.Write(" Digite o nome  para ver os numero de telefones: ");
            string nome = Console.ReadLine();
            var telephone = TelephoneController.SelectTelephone(nome);
           // Console.WriteLine(telephone.ToString());

            Console.WriteLine("\nPressione ENTER para continuar");
            Console.ReadKey();
            Console.Clear();
        }
        #endregion

        #region UPDATE
        public static void UpdateContact()
        {
            
            Console.Write(" Informe o nome que será atualizado: ");
            string nome = Console.ReadLine();

            int opc = 0;
            Console.WriteLine(" Oque você deseja ataulizar?");
            Console.WriteLine("\n   Opção 1: Informações pessoais ");
            Console.WriteLine("   Opção 2: Telefones ");

            Console.Write("\n Informe a opção: ");
            try
            {
                opc = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
            }

            switch (opc)
            {


                case 1:
                    UpContact();
                    break;
                case 2:
                    UpTelephone();
                    break;
                default:
                    Console.WriteLine(" Opção invalida\n Pressione ENTER ");
                    Console.ReadKey();
                    break;
            }

            void UpContact()
            {
                var cont = ContactController.SelectContact(nome);
                //Console.WriteLine(cont.ToString());
                if (cont != null)             
                {
                    Console.WriteLine("");
                    Console.WriteLine("\n   Opção 1: Atualizar Apelido ");
                    Console.WriteLine("   Opção 2: Atualizar Email ");

                    Console.Write("\n Informe a opção: ");
                    try
                    {
                        opc = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                    }

                    switch (opc)
                    {


                        case 1:
                            Console.Write("Novo apelido: ");
                            cont.Surname = Console.ReadLine();
                            break;
                        case 2:
                            Console.Write("Novo email:");
                            cont.Email = Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine(" Digite uma opção valida!!!\n Pressione ENTER para digitar novamente");
                            break;
                    }
                    ContactController.UpdateContact(cont);

                    Console.WriteLine(cont.ToString());
                }

                Console.WriteLine("\nPressione ENTER para continuar");
                Console.ReadKey();
                Console.Clear();
            }

            void UpTelephone()
            {
                var tel = TelephoneController.SelectTelephone(nome);
                //Console.WriteLine(tel.ToString());
                if (tel != null)
                {
                    Console.WriteLine("");
                    Console.WriteLine("\n   Opção 1: Atualizar telefone ");
                    Console.WriteLine("   Opção 2: Atualizar celular ");

                    Console.Write("\n Informe a opção: ");
                    try
                    {
                        opc = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                    }

                    switch (opc)
                    {


                        case 1:
                            Console.Write("Novo telefone: ");
                            tel.Phone = Console.ReadLine();
                            break;
                        case 2:
                            Console.Write("Novo celular:");
                            tel.Mobile = Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine(" Digite uma opção valida!!!\n Pressione ENTER para digitar novamente");
                            break;
                    }
                    TelephoneController.UpdateTelephone(tel);

                    Console.WriteLine(tel.ToString());

                }
                Console.WriteLine("\nPressione ENTER para continuar");
                Console.ReadKey();
                Console.Clear();

            }

        }
        #endregion

        #region REMOVE
        public static void RemoveContacts()
        {
            int opc = 0;
            Console.Write(" Informe o nome que será excluído do contato que será excluido: ");
            string nome = Console.ReadLine();
            var contact = ContactController.SelectContact(nome);
            var telephone = TelephoneController.SelectTelephone(nome);

            Console.WriteLine("\n Deseja remover esse contato?");
            Console.WriteLine(" 1 - SIM");
            Console.WriteLine(" 2 - NÂO");

            Console.Write("\n Informe a opção: ");
            try
            {
                opc = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
            }

            switch (opc)
            {


                case 1:
                    TelephoneController.RemoveTelephone(telephone);
                    ContactController.RemoveContact(contact);
                    Console.WriteLine(" Contato excluido!!!");


                    Console.WriteLine("\nPressione ENTER para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2:
                    Console.WriteLine(" Contato não excluido");


                    Console.WriteLine("\nPressione ENTER para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine(" Opção invalida\n Pressione ENTER para continuar");
                    Console.ReadKey();
                    break;
            }

        }
       
        #endregion

        static void Main(string[] args)
        {
            //InsertContato();

            do
            {
                int opc = 10;
                Console.Clear();
                Console.WriteLine(" Agenda de contatos");
                Console.WriteLine("\n    Opção 1: Cadastrar contato ");
                Console.WriteLine("    Opção 2: Listar contatos ");
                Console.WriteLine("    Opção 3: Listar telefones ");
                Console.WriteLine("    Opção 4: Selecionar contato ");
                Console.WriteLine("    Opção 5: Selecionar telefones de contato ");
                Console.WriteLine("    Opção 6: Editar informações de contato ");
                Console.WriteLine("    Opção 7: Excluir contato ");
                Console.WriteLine("    Opção 0: Fechar programa ");

                Console.Write("\n Informe a opção: ");
                try
                {
                    opc = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                }

                switch (opc)
                {
                    case 0:
                        Console.Clear();
                        Environment.Exit(0);
                        break;

                    case 1:
                        Console.Clear();
                        InsertContato();
                        break;
                    case 2:
                        Console.Clear();
                        PrintListContact();
                        break;

                    case 3:
                        Console.Clear();
                        PrintListTelephone();
                        break;

                    case 4:
                        Console.Clear();
                        SelectContact();
                        break;

                    case 5:
                        Console.Clear();
                        SelectTelephone();
                        break;

                    case 6:
                        Console.Clear();
                        UpdateContact();
                        break;
                    case 7:
                        Console.Clear();
                        RemoveContacts();
                        break;
                   
                    default:
                        Console.Write("\n Opcao Inválida!\n Digite novamente: ");
                        break;
                }

            } while (true);

        }
    }
}
