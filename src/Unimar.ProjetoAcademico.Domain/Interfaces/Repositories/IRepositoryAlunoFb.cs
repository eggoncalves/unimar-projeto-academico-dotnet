using Unimar.ProjetoAcademico.Domain.Entities;

namespace Unimar.ProjetoAcademico.Domain.Interfaces.Repositories;

public interface IRepositoryAlunoFb
{
    Task<AlunoFb?> GetByIdAsync(string id);
    Task<IList<AlunoFb>> ListAsync();
    Task<IList<AlunoFb>> ListByNomeAsync(string nome);
    Task<string> AddAsync(AlunoFb aluno);
    Task UpdateAsync(string id, AlunoFb aluno);
    Task DeleteAsync(string id);
    Task<IList<AlunoFb>> ListWhereEqualsAsync(string nome);
    Task<IList<AlunoFb>> ListWhereNotEqualsAsync(string nome);
    Task<IList<AlunoFb>> ListWhereGreaterThan_WhereLessThanOrEqualToAsync(int idade01, int idade02);
    Task<IList<AlunoFb>> ListWhereInAsync(int idade01, int idade02);
    Task<IList<AlunoFb>> ListWhereNotInAsync(int idade01, int idade02);
    Task<IList<AlunoFb>> ListWhereArrayContainsAsync(string nome01, string nome02);
    Task<IList<AlunoFb>> ListWhereArrayContainsAnyAsync(string nome01, string nome02);
    Task<IList<AlunoFb>> ListOrderAsync();
    Task<IList<AlunoFb>> ListOrderDescAsync();
    Task<IList<AlunoFb>> ListLimitAsync();
    Task<IList<AlunoFb>> ListLimitAndOrderAsync();
}