using MagicVilla_API.Models;
using MagicVilla_API.Repositories.IRepository;

namespace MagicVilla_API.Repository.IRepository
{
    public interface IVillaNumberRepository : IRepository<VillaNumber>
    {
        Task<VillaNumber> Update(VillaNumber entity);
    }
}
