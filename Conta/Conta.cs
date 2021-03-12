using System;

namespace DIO_Bank_POO
{
    public class Conta
    {

        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public Conta()
        {
        }

        public bool Sacar(double valorSaque)
        {
            if(this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente.");
                return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine();
            Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");
            
            if(this.Saldo < 0)
            {
                double creditoUtilizado = Math.Abs(this.Saldo)/this.Credito * 100;
                Console.WriteLine($"Você utilizou {creditoUtilizado}% do seu crédito");
            }
            
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            return $"TipoConta: {this.TipoConta} | " +
                   $"Nome: {this.Nome} | " +
                   $"Saldo: {this.Saldo} | " +
                   $"Crédito: {this.Credito}";
        }

    }
}