using System;
namespace DIO.Bank
{
    public class Conta
    {
        //atributos de Conta
        private string Nome {get; set; }
        private double Credito {get; set; }
        private double Saldo {get; set; }
        private TipoConta TipoConta{get; set; }//enum - valores pre-definidos
        //atributos encapsulados para ter restrição de acesso
        //para mudar estes atributos deverá ser criado um método
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
            //este método será chamado no momento em que Conta for instanciada
            //o this é para que a alteração ocorra apenas nesta instância criada
                   //sem intereferir nas outras
        }

        public bool Sacar(double valorSaque)
        {
            //validação de saldo sufuciente
            if(this.Saldo - valorSaque < this.Credito *-1)
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;//volta para quem chamou este método
            }
            this.Saldo -= valorSaque; //this.Saldo = this.Saldo - valorSaque;            

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome,this.Saldo);
                                                                            //argumentos
            return true; //consegui fazer o  saque
        }
        public void Depositar(double valorDeposito)
        {
            //função para receber depósitos
            this.Saldo += valorDeposito;
            Console.WriteLine("{0}, seu saldo atual é {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
                //reúso dos métodos Sacar e Depositar
            }
        }

        public override string ToString()
        //método público que retorna uma string
        //override sobrescreve a definição de ToString que já possui na classe mãe Object
        {
            string retorno = "";
            retorno += "TipoConta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo + " | ";
            retorno += "Credito: " + this.Credito + " | ";
            return retorno;

        }

    }
}