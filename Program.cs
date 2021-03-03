using GikaBank.Classes;
using GikaBank.Enumns;
using System;

namespace GikaBank
{
    class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("============GikaBank===============");
                Console.WriteLine("Digite a opção desejada: ");
                Console.WriteLine("1 - Cadastrar Conta | " +
                                         "2- Sacar | " +
                                         "3 - Depositar | " +
                                         "4 - Transferir | " +
                                         "5 - Visualizar conta");

                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarConta();
                        break;
                    case 2:
                        Sacar();
                        break;
                    case 3:
                        Depositar();
                        break;
                    case 4:
                        Transferir();
                        break;
                    case 5:
                        VisualizarConta();
                        break;
                    default:
                        break;
                }
            }
        }

        public static void CadastrarConta()
        {
            Console.WriteLine("Digite o tipo de conta: ");
            int tipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titular da conta: ");
            string titular = Console.ReadLine();

            Console.WriteLine("Digite a agência da conta: ");
            int agencia = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta: ");
            int numero= int.Parse(Console.ReadLine());

            Conta conta = new Conta((TipoConta)tipoConta, titular, agencia, numero);

            Conta.CadastrarConta(conta);

            Console.WriteLine("Conta cadastrada!");

        }

        public static void Sacar()
        {
            Console.WriteLine("Digite a agência da conta a ser sacada: ");
            int agencia = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta a ser sacada: ");
            int numero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado: ");
            double valor = double.Parse(Console.ReadLine());

            try
            {
                Conta conta = Conta.EncontrarConta(numero, agencia);

                if (conta.Sacar(valor))
                {
                    Console.WriteLine("Saque de R${0:0.00} realizado.", valor);

                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }

        public static void Depositar()
        {
            Console.WriteLine("Digite a agência da conta a ser depositada: ");
            int agencia = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta a ser depositada: ");
            int numero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser depositado: ");
            double valor = double.Parse(Console.ReadLine());

            try
            {
                Conta conta = Conta.EncontrarConta(numero, agencia);

                conta.Depositar(valor);
                Console.WriteLine("Depósito de R${0:0.00} realizado.", valor);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }

        public static void Transferir()
        {
            Console.WriteLine("Digite a agência da conta de origem: ");
            int agenciaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta de origem: ");
            int numeroOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a agência da conta a ser transferida: ");
            int agenciaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta a ser transferida: ");
            int numeroDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido: ");
            double valor = double.Parse(Console.ReadLine());

            try
            {
                Conta contaOrigem = Conta.EncontrarConta(numeroOrigem, agenciaOrigem);
                Conta contaDestino = Conta.EncontrarConta(numeroDestino, agenciaDestino);

                contaOrigem.Transferir(valor, contaDestino);
                Console.WriteLine("Transferência de R${0:0.00} realizada.", valor);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public static void VisualizarConta()
        {
            Console.WriteLine("Digite a agência da conta: ");
            int agencia = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta: ");
            int numero = int.Parse(Console.ReadLine());

            try
            {
                Conta conta = Conta.EncontrarConta(numero, agencia);

                Console.WriteLine(conta);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

    }
}
