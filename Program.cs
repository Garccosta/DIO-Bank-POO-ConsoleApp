using System;
using System.Collections.Generic;
using System.Globalization;

namespace DIO_Bank_POO
{
    class Program
    {   
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Por favor selecione uma opção abaixo: ");
                        break;
                }

                opcaoUsuario = ObterOpcaoUsuario();
            } 

                Console.WriteLine("Obrigado por utilizar nossos serviços! Volte sempre! :)");
                Console.ReadLine(); // prevents the console to automatically close
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void ListarContas()
        {
            Console.WriteLine("##Listar Contas##");

            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }
        
        private static void Sacar()
        {
            Conta conta = new Conta();

            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            
            try{
                conta = listaContas[indiceConta];

                Console.Write("Digite o valor a ser sacado: ");
                double valorSaque = double.Parse(Console.ReadLine());
                conta.Sacar(valorSaque);

            } catch {
                Console.WriteLine("Não existe esse número de conta.");
            };
        
        }
        private static void InserirConta()
        {
            Console.WriteLine("##Inserir nova conta##");

            Console.Write("Digite 1 para Conta Física ou 2 para Conta Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Deigite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);
            listaContas.Add(novaConta);

            Console.WriteLine();
            Console.WriteLine("Conta criada com sucesso!\n\n" +
                              "Detalhes da conta: \n" +
                              $"Número da conta: {listaContas.Count - 1} \n" +
                              novaConta.ToString());
        }

        private static void Depositar()
        {
            Conta conta = new Conta();
            try{
                Console.Write("Digite o número da conta: ");
                int indiceConta = int.Parse(Console.ReadLine());

                conta = listaContas[indiceConta];

                Console.Write("Digite o valor a ser depositado: ");
                double valorDepositado = double.Parse(Console.ReadLine());

                conta.Depositar(valorDepositado);

            } catch {
                Console.WriteLine("Não existe esse número de conta.");
            }
        }

        private static void Transferir()
        {
            Conta contaOrigem = new Conta();
            Conta contaDestino = new Conta();
            try {
                Console.Write("Digite o número da conta de origem: ");
                int indiceContaOrigem = int.Parse(Console.ReadLine());
                contaOrigem = listaContas[indiceContaOrigem];

                   try {
                        Console.Write("Digite o número da conta de destino: ");
                        int indiceContaDestino = int.Parse(Console.ReadLine());

                        contaDestino = listaContas[indiceContaDestino];

                         Console.Write("Digite o valor a ser transferido: ");
                        double valorTransferencia = double.Parse(Console.ReadLine());

                        contaOrigem.Transferir(valorTransferencia, contaDestino);

                    } catch {
                        Console.WriteLine();
                        Console.WriteLine("Número da conta de destino inexistente!");
                    }
            
            } catch {
                Console.WriteLine();
                Console.WriteLine("Número da conta de origem inexistente!");
            }
        }
    }
}
