namespace ContaBancaria.Model
{
    public class ContaPoupanca : Conta
    {
        public int AniversarioConta { get; private set; } // dia do mês para rendimento

    // Conta Poupança: tipo 2, sem limite de crédito, com aniversário para rendimento mensal, ate dia 28 para evitar problemas com meses menores
        public ContaPoupanca(int agencia, string titular, decimal saldoInicial, int aniversario = 1)
            : base(agencia, 2, titular, saldoInicial)
        {
            AniversarioConta = (aniversario >= 1 && aniversario <= 28) ? aniversario : 1;
        }

        // Poupança não possui cheque especial — saque limitado ao saldo
        public override bool Sacar(decimal valor)
        {
            return base.Sacar(valor);
        }

        public override string ToString()
        {
            return base.ToString().Replace(
                "\033[36m====================================\033[0m",
                $" Aniversário     : Dia {AniversarioConta}\n\033[36m====================================\033[0m"
            );
        }
    }
}
