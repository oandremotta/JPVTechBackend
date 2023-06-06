using backend.Model;
using backend.Repositories.Interfaces;
using backend.ViewModel;
using Microsoft.AspNetCore.Mvc;
using static backend.Services.Exceptions.CpfExceptions;

namespace backend.Controllers
{
    [Route("/api/")]
    [ApiController]
    public class PessoaFisicaController : ControllerBase
    {
        private IRepositoryPessoaFisica _repositoryPessoaFisica;
        public PessoaFisicaController(IRepositoryPessoaFisica repositoryPessoaFisica)
        {
            this._repositoryPessoaFisica = repositoryPessoaFisica;
        }

        [HttpGet("v1/pessoa-fisica")]
        public async Task<IActionResult> GetAll()
        {
            var pessoasFisicas = await this._repositoryPessoaFisica.ObterTodasAsPessoasFisicas();
            return Ok(new ResultViewModel<List<PessoaFisica>>(pessoasFisicas));
        }

        [HttpGet("v1/pessoa-fisica/{cpf}")]
        public async Task<IActionResult> GetPessoaFisica(string cpf)
        {
            try
            {
                var pessoaFisica = await this._repositoryPessoaFisica.ObterPessoaFisica(cpf);
                if (pessoaFisica == null)
                {
                    return StatusCode(404, new ResultViewModel<List<PessoaFisica>>("Pessoa Física não encontrada."));
                }
                return Ok(new ResultViewModel<PessoaFisica>(pessoaFisica));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<PessoaFisica>>("Falha interna."));
            }
        }

        [HttpPost("v1/pessoa-fisica")]
        public async Task<IActionResult> AddPessoaFisica(PessoaFisica pessoaFisica)
        {
            try
            {
                var pessoaAdicionada = await _repositoryPessoaFisica.AdicionarPessoaFisica(pessoaFisica);
                return Ok(new ResultViewModel<PessoaFisica>(pessoaAdicionada));
            }
            catch (CpfInvalidoException)
            {
                return BadRequest(new ResultViewModel<string>("CPF inválido."));
            }
            catch (CpfDuplicadoException)
            {
                return Conflict(new ResultViewModel<string>("CPF já cadastrado."));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<string>("Falha interna."));
            }
        }

        [HttpPut("v1/pessoa-fisica/{cpf}")]
        public async Task<IActionResult> EditarPessoaFisica(PessoaFisica pessoaFisica)
        {
            try
            {
                var pessoaAlterada = await this._repositoryPessoaFisica.EditarPessoaFisica(pessoaFisica);
                if(pessoaAlterada == null) {
                    return StatusCode(404, new ResultViewModel<List<PessoaFisica>>("Pessoa Física não encontrada."));
                }
                return Ok(new ResultViewModel<PessoaFisica>(pessoaAlterada));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<PessoaFisica>>("Falha interna."));
            }
        }

        [HttpDelete("v1/pessoa-fisica/{id}")]
        public async Task<IActionResult> ExcluirPessoaFisica(int id)
        {
            try
            {
                var pessoaExcluida = await this._repositoryPessoaFisica.ExcluirPessoaFisica(id);
                if (pessoaExcluida == null)
                {
                    return StatusCode(404, new ResultViewModel<List<PessoaFisica>>("Pessoa Física não encontrada."));
                }
                return Ok(new ResultViewModel<PessoaFisica>(pessoaExcluida));

            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<PessoaFisica>>("Falha interna."));
            }
        }
    }
}
