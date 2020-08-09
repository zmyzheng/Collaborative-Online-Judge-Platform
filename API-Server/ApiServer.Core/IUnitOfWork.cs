using System;
using System.Threading.Tasks;
using ApiServer.Core.Repositories;

namespace ApiServer.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IProblemRepository Problems { get; }
        Task<int> CommitAsync();
    }
}