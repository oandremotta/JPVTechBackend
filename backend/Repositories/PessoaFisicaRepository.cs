using backend.Data;
using backend.Model;
using backend.Repositories.Interfaces;
using backend.Services.Validators;
using Microsoft.EntityFrameworkCore;
using static backend.Services.Exceptions.CpfExceptions;

namespace backend.Repositories
{
    public class PessoaFisicaRepository : IRepositoryPessoaFisica
    {
        private readonly BackendDataContext _context;

        public PessoaFisicaRepository(BackendDataContext context)
        {
            _context = context;
        }

        public async Task<List<PessoaFisica>> ObterTodasAsPessoasFisicas()
        {
            return await _context.PessoasFisicas.ToListAsync();
        }

        public async Task<PessoaFisica?> ObterPessoaFisica(string cpf)
        {
            var pessoaExistente = await _context.PessoasFisicas.FirstOrDefaultAsync(p => p.Cpf == cpf);

            if (pessoaExistente == null)
                return null;

            return pessoaExistente;
        }

        public async Task<PessoaFisica> AdicionarPessoaFisica(PessoaFisica pessoaFisica)
        {
            if (!ValidatorUtils.IsCpf(pessoaFisica.Cpf))
            {
                throw new CpfInvalidoException("CPF inválido.");
            }

            var pessoaExistente = await _context.PessoasFisicas.FirstOrDefaultAsync(p => p.Cpf == pessoaFisica.Cpf);
            if (pessoaExistente != null)
            {
                throw new CpfDuplicadoException("CPF já cadastrado.");
            }

            _context.Add(pessoaFisica);
            await _context.SaveChangesAsync();
            return pessoaFisica;
        }

        public async Task<PessoaFisica?> EditarPessoaFisica(PessoaFisica pessoaFisica)
        {
            var pessoaExistente = await _context.PessoasFisicas.FindAsync(pessoaFisica.Id);
            if (pessoaExistente == null)
                return null;

            pessoaExistente.NomeCompleto = pessoaFisica.NomeCompleto;
            pessoaExistente.DataDeNascimento = pessoaFisica.DataDeNascimento;
            pessoaExistente.ValorDaRenda = pessoaFisica.ValorDaRenda;

            await _context.SaveChangesAsync();

            return pessoaExistente;
        }

        public async Task<PessoaFisica?> ExcluirPessoaFisica(int id)
        {
            var pessoaExistente = await _context.PessoasFisicas.FindAsync(id);
            if (pessoaExistente == null)
                return null;

            _context.PessoasFisicas.Remove(pessoaExistente);
            await _context.SaveChangesAsync();

            return pessoaExistente;
        }     
    }
}
