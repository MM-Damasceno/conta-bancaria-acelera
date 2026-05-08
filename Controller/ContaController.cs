using ContaBancaria.Model;
using ContaBancaria.Repository;

namespace ContaBancaria.Controller
{
    // Controller para gerenciar as operações de conta, implementando a interface do repositório
    public class ContaController : ContaRepository
    {
        private List<Conta> _listaContas = new List<Conta>();

        public void CadastrarConta(Conta conta)
        {
            _listaContas.Add(conta);
            Console.WriteLine($"\n\033[32mConta número {conta.Numero} cadastrada com sucesso!\033[0m");
        }

        public void ProcurarTodasAsContas()
        {
            if (_listaContas.Count == 0)
            {
                Console.WriteLine("\n\033[33mNenhuma conta cadastrada.\033[0m");
                return;
            }
            foreach (var conta in _listaContas)
                Console.WriteLine(conta);
        }

        public void ProcurarContaPorNumero(int numero)
        {
            var conta = BuscarConta(numero);
            if (conta != null)
                Console.WriteLine(conta);
        }
            // Atualizar conta: substitui a conta existente pela nova versão (mesmo número)
        public void AtualizarConta(Conta contaAtualizada)
        {
            var conta = BuscarConta(contaAtualizada.Numero);
            if (conta != null)
            {
                int index = _listaContas.IndexOf(conta);
                _listaContas[index] = contaAtualizada;
                Console.WriteLine($"\n\033[32mConta número {contaAtualizada.Numero} atualizada com sucesso!\033[0m");
            }
        }

        public void DeletarConta(int numero)
        {
            var conta = BuscarConta(numero);
            if (conta != null)
            {
                _listaContas.Remove(conta);
                Console.WriteLine($"\n\033[32mConta número {numero} deletada com sucesso!\033[0m");
            }
        }

        public void Sacar(int numero, decimal valor)
        {
            var conta = BuscarConta(numero);
            if (conta != null)
            {
                if (conta.Sacar(valor))
                    Console.WriteLine($"\n\033[32mSaque de R$ {valor:F2} realizado com sucesso!\033[0m\n Novo saldo: R$ {conta.Saldo:F2}");
            }
        }

        public void Depositar(int numero, decimal valor)
        {
            var conta = BuscarConta(numero);
            if (conta != null)
            {
                conta.Depositar(valor);
                Console.WriteLine($"\n\033[32mDepósito de R$ {valor:F2} realizado com sucesso!\033[0m\n Novo saldo: R$ {conta.Saldo:F2}");
            }
        }

        public void Transferir(int numeroOrigem, int numeroDestino, decimal valor)
        {
            var origem = BuscarConta(numeroOrigem);
            var destino = BuscarConta(numeroDestino);

            if (origem == null || destino == null)
                return;

            if (origem.Sacar(valor))
            {
                destino.Depositar(valor);
                Console.WriteLine($"\n\033[32mTransferência de R$ {valor:F2} realizada com sucesso!\033[0m");
                Console.WriteLine($" Conta {numeroOrigem} - Novo saldo: R$ {origem.Saldo:F2}");
                Console.WriteLine($" Conta {numeroDestino} - Novo saldo: R$ {destino.Saldo:F2}");
            }
        }

        // Método auxiliar interno
        private Conta? BuscarConta(int numero)
        {
            var conta = _listaContas.FirstOrDefault(c => c.Numero == numero);
            if (conta == null)
                Console.WriteLine($"\n\033[31mErro: Conta número {numero} não encontrada.\033[0m");
            return conta;
        }
    }
}
