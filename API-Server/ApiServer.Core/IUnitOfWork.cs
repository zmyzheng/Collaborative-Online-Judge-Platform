using System;
using System.Threading.Tasks;
using ApiServer.Core.Repositories;

namespace ApiServer.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IProblemRepository ProblemRepository { get; }
        Task<int> CommitAsync();
    }
}