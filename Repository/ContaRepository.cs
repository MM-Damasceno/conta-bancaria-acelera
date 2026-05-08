using ContaBancaria.Model;

// Interface para o repositorio de contas 
namespace ContaBancaria.Repository
{
    public interface ContaRepository
    {
        void ProcurarTodasAsContas();
        void ProcurarContaPorNumero(int numero);
        void CadastrarConta(Conta conta);
        void AtualizarConta(Conta conta);
        void DeletarConta(int numero);
        void Sacar(int numero, decimal valor);
        void Depositar(int numero, decimal valor);
        void Transferir(int numeroOrigem, int numeroDestino, decimal valor);
    }
}
