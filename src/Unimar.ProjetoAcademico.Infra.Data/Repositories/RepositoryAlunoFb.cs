using Google.Cloud.Firestore;
using Unimar.ProjetoAcademico.Domain.Entities;
using Unimar.ProjetoAcademico.Domain.Interfaces.Repositories;

namespace Unimar.ProjetoAcademico.Infra.Data.Repositories;
public class RepositoryAlunoFb(FirestoreDb firestoreDb) : IRepositoryAlunoFb
{
    private const string Collection = "alunos";

    public async Task<AlunoFb?> GetByIdAsync(string id)
    {
        var snap = await firestoreDb.Collection(Collection).Document(id).GetSnapshotAsync();
        if (!snap.Exists)
            return null;

        return new AlunoFb
        {
            Id = snap.Id,
            Nome = snap.GetValue<string>("nome"),
            Email = snap.GetValue<string>("email"),
            Idade = snap.GetValue<int>("idade")
        };
    }

    public async Task<IList<AlunoFb>> ListAsync()
    {
        var snap = await firestoreDb.Collection(Collection).GetSnapshotAsync();

        return snap.Documents.Select(d => new AlunoFb
        {
            Id = d.Id,
            Nome = d.GetValue<string>("nome"),
            Email = d.GetValue<string>("email"),
            Idade = d.GetValue<int>("idade")
        }).ToList();
    }

    public async Task<IList<AlunoFb>> ListByNomeAsync(string nome)
    {
        var query = firestoreDb.Collection(Collection)
            .WhereGreaterThanOrEqualTo("nome", nome)
            .WhereLessThanOrEqualTo("nome", nome + "\uf8ff");

        var snap = await query.GetSnapshotAsync();

        return snap.Documents.Select(d => new AlunoFb
        {
            Id = d.Id,
            Nome = d.GetValue<string>("nome"),
            Email = d.GetValue<string>("email"),
            Idade = d.GetValue<int>("idade")
        }).ToList();
    }

    public async Task<string> AddAsync(AlunoFb aluno)
    {
        var docRef = await firestoreDb.Collection(Collection).AddAsync(new
        {
            nome = aluno.Nome,
            email = aluno.Email,
            idade = aluno.Idade,
            criadoEm = Timestamp.FromDateTime(DateTime.UtcNow)
        });

        return docRef.Id;
    }

    public async Task UpdateAsync(string id, AlunoFb aluno)
    {
        await firestoreDb.Collection(Collection).Document(id).SetAsync(new
        {
            nome = aluno.Nome,
            email = aluno.Email,
            idade = aluno.Idade,
        }, SetOptions.MergeAll);
    }

    public async Task DeleteAsync(string id)
    {
        await firestoreDb.Collection(Collection).Document(id).DeleteAsync();
    }

    public async Task<IList<AlunoFb>> ListWhereEqualsAsync(string nome)
    {
        var query = firestoreDb.Collection(Collection)
            .WhereEqualTo("nome", nome);

        var snap = await query.GetSnapshotAsync();

        return snap.Documents.Select(d => new AlunoFb
        {
            Id = d.Id,
            Nome = d.GetValue<string>("nome"),
            Email = d.GetValue<string>("email"),
            Idade = d.GetValue<int>("idade")
        }).ToList();
    }

    public async Task<IList<AlunoFb>> ListWhereNotEqualsAsync(string nome)
    {
        var query = firestoreDb.Collection(Collection)
            .WhereNotEqualTo("nome", nome);

        var snap = await query.GetSnapshotAsync();

        return snap.Documents.Select(d => new AlunoFb
        {
            Id = d.Id,
            Nome = d.GetValue<string>("nome"),
            Email = d.GetValue<string>("email"),
            Idade = d.GetValue<int>("idade")
        }).ToList();
    }

    public async Task<IList<AlunoFb>> ListWhereGreaterThan_WhereLessThanOrEqualToAsync(int idade01, int idade02)
    {
        var query = firestoreDb.Collection(Collection)
            .WhereGreaterThan("idade", idade01)
            .WhereLessThanOrEqualTo("idade", idade02);

        var snap = await query.GetSnapshotAsync();

        return snap.Documents.Select(d => new AlunoFb
        {
            Id = d.Id,
            Nome = d.GetValue<string>("nome"),
            Email = d.GetValue<string>("email"),
            Idade = d.GetValue<int>("idade")
        }).ToList();
    }

    public async Task<IList<AlunoFb>> ListWhereInAsync(int idade01, int idade02)
    {
        var query = firestoreDb.Collection(Collection)
            .WhereIn("nome", new object[] { idade01, idade02 });

        var snap = await query.GetSnapshotAsync();

        return snap.Documents.Select(d => new AlunoFb
        {
            Id = d.Id,
            Nome = d.GetValue<string>("nome"),
            Email = d.GetValue<string>("email"),
            Idade = d.GetValue<int>("idade")
        }).ToList();
    }

    public async Task<IList<AlunoFb>> ListWhereNotInAsync(int idade01, int idade02)
    {
        var query = firestoreDb.Collection(Collection)
            .WhereNotIn("nome", new object[] { idade01, idade02 });

        var snap = await query.GetSnapshotAsync();

        return snap.Documents.Select(d => new AlunoFb
        {
            Id = d.Id,
            Nome = d.GetValue<string>("nome"),
            Email = d.GetValue<string>("email"),
            Idade = d.GetValue<int>("idade")
        }).ToList();
    }

    //Where - Array Contains (NÃO VAI FUNCIONAR, POIS EM NOSSO EXEMPLO NÃO TEMOS UM CAMPO DO TIPO ARRAY)
    public async Task<IList<AlunoFb>> ListWhereArrayContainsAsync(string nome01, string nome02)
    {
        var query = firestoreDb.Collection(Collection)
            .WhereArrayContains("contatos", new object[] { nome01, nome02 });

        var snap = await query.GetSnapshotAsync();

        return snap.Documents.Select(d => new AlunoFb
        {
            Id = d.Id,
            Nome = d.GetValue<string>("nome"),
            Email = d.GetValue<string>("email"),
            Idade = d.GetValue<int>("idade")
        }).ToList();
    }

    //Where - Array Contains qualquer (OR dentro do array) (NÃO VAI FUNCIONAR, POIS EM NOSSO EXEMPLO NÃO TEMOS UM CAMPO DO TIPO ARRAY)
    public async Task<IList<AlunoFb>> ListWhereArrayContainsAnyAsync(string nome01, string nome02)
    {
        var query = firestoreDb.Collection(Collection)
            .WhereArrayContainsAny("contatos", new object[] { nome01, nome02 });

        var snap = await query.GetSnapshotAsync();

        return snap.Documents.Select(d => new AlunoFb
        {
            Id = d.Id,
            Nome = d.GetValue<string>("nome"),
            Email = d.GetValue<string>("email"),
            Idade = d.GetValue<int>("idade")
        }).ToList();
    }

    public async Task<IList<AlunoFb>> ListOrderAsync()
    {
        var query = firestoreDb.Collection(Collection)
            .OrderBy("nome");

        var snap = await query.GetSnapshotAsync();

        return snap.Documents.Select(d => new AlunoFb
        {
            Id = d.Id,
            Nome = d.GetValue<string>("nome"),
            Email = d.GetValue<string>("email"),
            Idade = d.GetValue<int>("idade")
        }).ToList();
    }

    public async Task<IList<AlunoFb>> ListOrderDescAsync()
    {
        var query = firestoreDb.Collection(Collection)
            .OrderByDescending("nome");

        var snap = await query.GetSnapshotAsync();

        return snap.Documents.Select(d => new AlunoFb
        {
            Id = d.Id,
            Nome = d.GetValue<string>("nome"),
            Email = d.GetValue<string>("email"),
            Idade = d.GetValue<int>("idade")
        }).ToList();
    }

    public async Task<IList<AlunoFb>> ListLimitAsync()
    {
        var query = firestoreDb.Collection(Collection)
            .Limit(5);

        var snap = await query.GetSnapshotAsync();

        return snap.Documents.Select(d => new AlunoFb
        {
            Id = d.Id,
            Nome = d.GetValue<string>("nome"),
            Email = d.GetValue<string>("email"),
            Idade = d.GetValue<int>("idade")
        }).ToList();
    }

    public async Task<IList<AlunoFb>> ListLimitAndOrderAsync()
    {
        var query = firestoreDb.Collection(Collection)
            .OrderBy("nome")
            .Limit(10);

        var snap = await query.GetSnapshotAsync();

        return snap.Documents.Select(d => new AlunoFb
        {
            Id = d.Id,
            Nome = d.GetValue<string>("nome"),
            Email = d.GetValue<string>("email"),
            Idade = d.GetValue<int>("idade")
        }).ToList();
    }
}
