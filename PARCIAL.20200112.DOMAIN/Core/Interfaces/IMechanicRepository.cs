
using PARCIAL._20200112.DOMAIN.Infrastructure.Data;

namespace PARCIAL._20200112.DOMAIN.Core.Interfaces
{
    public interface IMechanicRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Mechanic>> GetMechanic();
        Task<Mechanic> GetMechanicById(int id);
        Task<int> Insert(Mechanic mechanic);
        Task<bool> Update(Mechanic mechanic);
    }
}