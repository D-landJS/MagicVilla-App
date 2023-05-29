using MagicVilla_API.Models;
using MagicVilla_API.Repositories.IRepository;

namespace MagicVilla_API.Repository.IRepository
{
    public interface IVillaRepository : IRepository<Villa>
    {
        Task<Villa> Update(Villa entity);
    }
}
