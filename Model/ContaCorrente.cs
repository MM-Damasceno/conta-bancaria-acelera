namespace ContaBancaria.Model
{
    // class para conta corrente. Herda classe base Conta 
    public class ContaCorrente : Conta
    {
        public decimal LimiteCredito { get; private set; }

        public ContaCorrente(int agencia, string titular, decimal saldoInicial, decimal limiteCredito = 0)
            : base(agencia, 1, titular, saldoInicial)
        {
            LimiteCredito = limiteCredito;
        }

        // Conta Corrente pode sacar até o limite do cheque especial
        public override bool Sacar(decimal valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("\n\033[31mErro: O valor do saque deve ser positivo.\033[0m");
                return false;
            }
            if (valor > Saldo + LimiteCredito)
            {
                Console.WriteLine("\n\033[31mErro: Saldo insuficiente (incluindo limite de crédito).\033[0m");
                return false;
            }
            Saldo -= valor;
            return true;
        }

        public override string ToString()
        {
            return base.ToString().Replace(
                "\033[36m====================================\033[0m",
                $" Limite Crédito  : R$ {LimiteCredito:F2}\n\033[36m====================================\033[0m"
            );
        }
    }
}
