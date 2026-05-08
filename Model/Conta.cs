namespace ContaBancaria.Model
{
    public abstract class Conta
    {
        private static int _contadorNumero = 1;

        public int Numero { get; set; }
        public int Agencia { get; set; }
        public int TipoConta { get; set; } // 1 = Corrente, 2 = Poupança
        public string Titular { get; set; }
        public decimal Saldo { get; protected set; }

        public Conta(int agencia, int tipoConta, string titular, decimal saldoInicial)
        {
            Numero = _contadorNumero++;
            Agencia = agencia;
            TipoConta = tipoConta;
            Titular = titular;
            Saldo = saldoInicial;
        }

        public virtual bool Sacar(decimal valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("\n\033[31mErro: O valor do saque deve ser positivo.\033[0m");
                return false;
            }
            if (valor > Saldo)
            {
                Console.WriteLine("\n\033[31mErro: Saldo insuficiente para realizar o saque.\033[0m");
                return false;
            }
            Saldo -= valor;
            return true;
        }

        public virtual void Depositar(decimal valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("\n\033[31mErro: O valor do depósito deve ser positivo.\033[0m");
                return;
            }
            Saldo += valor;
        }

        public override string ToString()
        {
            string tipo = TipoConta == 1 ? "Conta Corrente" : "Conta Poupança";
            return $"\n\033[36m========== Dados da Conta ==========\033[0m\n" +
                   $" Número da Conta : {Numero}\n" +
                   $" Agência         : {Agencia}\n" +
                   $" Tipo            : {tipo}\n" +
                   $" Titular         : {Titular}\n" +
                   $" Saldo           : R$ {Saldo:F2}\n" +
                   $"\033[36m====================================\033[0m";
        }
    }
}
