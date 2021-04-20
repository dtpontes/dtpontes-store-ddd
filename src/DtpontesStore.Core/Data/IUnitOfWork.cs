using System.Threading.Tasks;

namespace DtpontesStore.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
