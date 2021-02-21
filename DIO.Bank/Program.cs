using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            //Conta minhaConta = new Conta(TipoConta.PessoaFisica, 0, 0,"Gabriela");
            
            //este objeto é uma nova instância da minha classe Conta
            //minhaConta.Nome = "Gabriela";
            //Console.WriteLine(minhaConta.ToString());
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                    ListarConta();break;
                    case "2":
                    InserirConta();break;
                    case "3":
                    Transferir();break;
                    case "4":
                    Sacar();break;
                    case "5":
                    Depositar();break;
                    case "C":
                    Console.Clear();break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
                                                         //listContas está indexado com indiceContaDestino
        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorDeposito);
            
        }

        private static void ListarConta()
        {
            Console.WriteLine("Listar contas");
            if(listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }
            for(int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];//criação de um novo objeto, já populado com essa lista
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);//executa aquele override string ToString() criado no Conta.cs 
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para Conta Física ou 2 para Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do Cliente: ");
            string entradaNome =  Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo =  double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            //instanciando a classe com a criação deste objeto, que se chama novaConta
            //passando os parâmetros
            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                                //conversão explícita para enum
                                 saldo: entradaSaldo, credito: entradaCredito,
                                 nome: entradaNome);
            listContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!\n");

            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair\n");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
        
            return opcaoUsuario;
        }
    }
}