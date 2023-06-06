using backend.Model;

namespace backend.Repositories.Interfaces
{
    public interface IRepositoryPessoaFisica
    {
        Task<List<PessoaFisica>> ObterTodasAsPessoasFisicas();
        Task<PessoaFisica?> ObterPessoaFisica(string cpf);
        Task<PessoaFisica> AdicionarPessoaFisica(PessoaFisica pessoaFisica);
        Task<PessoaFisica?> EditarPessoaFisica(PessoaFisica pessoaFisica);
        Task<PessoaFisica?> ExcluirPessoaFisica(int id);
    }
}
