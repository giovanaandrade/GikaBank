using GikaBank.Enumns;
using System;
using System.Collections.Generic;
using System.Text;

namespace GikaBank.Classes
{
    class Conta
    {
        public TipoConta TipoConta { get; private set; }
        public string Titular { get; private set; }
        public double Saldo { get; private set; }
        public int Agencia { get; private set; }
        public int Numero { get; private set; }
        public static List<Conta> ListaContas = new List<Conta>();

        public Conta(TipoConta tipoConta, string titular, int agencia, int numero)
        {
            TipoConta = tipoConta;
            Titular = titular;
            Agencia = agencia;
            Numero = numero;

        }

        public static Conta EncontrarConta(int numero, int agencia)
        {
            foreach (Conta conta in ListaContas)
            {
                if (conta.Numero == numero && conta.Agencia == agencia)
                {
                    return conta;

                }
            }
            throw new Exception("Conta inexistente");
           
        }

        public bool Sacar(double valor)
        {
               if (valor > Saldo)
                {
                    throw new Exception("Saldo insuficiente");
                }
                else
                {
                    Saldo -= valor;
                    return true;
                }
     
        }

        public void Depositar(double valor)
        {
            Saldo += valor;
        }

        public bool Transferir(double valor, Conta contaDestino)
        {
           if(Sacar(valor))
            {
                contaDestino.Depositar(valor);
                return true;
            } else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return "Tipo de conta: " + TipoConta + Environment.NewLine
                    + "Titular: " + Titular + Environment.NewLine
                    + "Agencia: " + Agencia + Environment.NewLine
                    + "Número: " + Numero + Environment.NewLine
                    + "Saldo: " + Saldo;
        }

        public static void CadastrarConta(Conta conta)
        {
            ListaContas.Add(conta);

        }
    }
}
