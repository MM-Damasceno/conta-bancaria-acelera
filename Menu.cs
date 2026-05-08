using ContaBancaria.Controller;
using ContaBancaria.Model;
using ContaBancaria.Util;

namespace ContaBancaria
{
    class Menu
    {
        static ContaController controller = new ContaController();

        static void Main(string[] args)
        {
            int opcao = 0;

            while (opcao != 9)
            {
                Cores.Titulo("SISTEMA BANCÁRIO - CONTA BANCÁRIA");

                Console.WriteLine(" 1 - Criar Conta");
                Console.WriteLine(" 2 - Listar todas as Contas");
                Console.WriteLine(" 3 - Buscar Conta por Número");
                Console.WriteLine(" 4 - Atualizar Dados da Conta");
                Console.WriteLine(" 5 - Apagar Conta");
                Console.WriteLine(" 6 - Sacar");
                Console.WriteLine(" 7 - Depositar");
                Console.WriteLine(" 8 - Transferir valores entre Contas");
                Console.WriteLine(" 9 - Sair");
                Console.Write("\n Digite a opção desejada: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Cores.Erro("Opção inválida! Digite um número.");
                    Pausar();
                    continue;
                }

                switch (opcao)
                {
                    case 1: CriarConta(); break;
                    case 2: controller.ProcurarTodasAsContas(); break;
                    case 3: BuscarConta(); break;
                    case 4: AtualizarConta(); break;
                    case 5: DeletarConta(); break;
                    case 6: Sacar(); break;
                    case 7: Depositar(); break;
                    case 8: Transferir(); break;
                    case 9:
                        Cores.Sucesso("Obrigado por usar o Sistema Bancário. Até logo!");
                        break;
                    default:
                        Cores.Erro("Opção inválida!");
                        break;
                }

                if (opcao != 9) Pausar();
            }
        }

        // ─── Métodos auxiliares de menu ────────────────────────────────────

        static void CriarConta()
        {
            Cores.Titulo("CRIAR CONTA");

            int tipo = LerInteiro("Tipo de Conta (1 = Corrente / 2 = Poupança): ");
            if (tipo != 1 && tipo != 2) { Cores.Erro("Tipo inválido."); return; }

            int agencia = LerInteiro("Agência: ");
            Console.Write("Titular: ");
            string titular = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrEmpty(titular)) { Cores.Erro("Titular inválido."); return; }

            decimal saldo = LerDecimal("Saldo inicial (R$): ");

            if (tipo == 1)
            {
                decimal limite = LerDecimal("Limite de Crédito (R$): ");
                controller.CadastrarConta(new ContaCorrente(agencia, titular, saldo, limite));
            }
            else
            {
                int aniversario = LerInteiro("Dia do aniversário da conta (1-28): ");
                controller.CadastrarConta(new ContaPoupanca(agencia, titular, saldo, aniversario));
            }
        }

        static void BuscarConta()
        {
            Cores.Titulo("BUSCAR CONTA");
            int numero = LerInteiro("Número da Conta: ");
            controller.ProcurarContaPorNumero(numero);
        }

        static void AtualizarConta()
        {
            Cores.Titulo("ATUALIZAR CONTA");
            int numero = LerInteiro("Número da Conta a atualizar: ");

            // Para simplificar, solicita novo titular e saldo
            Console.Write("Novo Titular: ");
            string titular = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrEmpty(titular)) { Cores.Erro("Titular inválido."); return; }

            int agencia = LerInteiro("Nova Agência: ");
            decimal saldo = LerDecimal("Novo Saldo Inicial (R$): ");

            int tipo = LerInteiro("Tipo (1 = Corrente / 2 = Poupança): ");

            Conta contaAtualizada;
            if (tipo == 1)
            {
                decimal limite = LerDecimal("Limite de Crédito (R$): ");
                contaAtualizada = new ContaCorrente(agencia, titular, saldo, limite);
            }
            else
            {
                int aniversario = LerInteiro("Dia do aniversário (1-28): ");
                contaAtualizada = new ContaPoupanca(agencia, titular, saldo, aniversario);
            }

            // Força o número da conta a ser mantido
            contaAtualizada.Numero = numero;

            controller.AtualizarConta(contaAtualizada);
        }

        static void DeletarConta()
        {
            Cores.Titulo("APAGAR CONTA");
            int numero = LerInteiro("Número da Conta a apagar: ");
            controller.DeletarConta(numero);
        }

        static void Sacar()
        {
            Cores.Titulo("SAQUE");
            int numero = LerInteiro("Número da Conta: ");
            decimal valor = LerDecimal("Valor do Saque (R$): ");
            controller.Sacar(numero, valor);
        }

        static void Depositar()
        {
            Cores.Titulo("DEPÓSITO");
            int numero = LerInteiro("Número da Conta: ");
            decimal valor = LerDecimal("Valor do Depósito (R$): ");
            controller.Depositar(numero, valor);
        }

        static void Transferir()
        {
            Cores.Titulo("TRANSFERÊNCIA");
            int origem = LerInteiro("Conta de Origem: ");
            int destino = LerInteiro("Conta de Destino: ");
            decimal valor = LerDecimal("Valor da Transferência (R$): ");
            controller.Transferir(origem, destino, valor);
        }

        // ─── Helpers de leitura segura ─────────────────────────────────────

        static int LerInteiro(string prompt)
        {
            int valor;
            do
            {
                Console.Write(prompt);
            } while (!int.TryParse(Console.ReadLine(), out valor));
            return valor;
        }

        static decimal LerDecimal(string prompt)
        {
            decimal valor;
            do
            {
                Console.Write(prompt);
            } while (!decimal.TryParse(Console.ReadLine(), out valor));
            return valor;
        }

        static void Pausar()
        {
            Console.WriteLine($"\n{Cores.Amarelo}Pressione Enter para continuar...{Cores.Reset}");
            Console.ReadLine();
        }
    }
}
