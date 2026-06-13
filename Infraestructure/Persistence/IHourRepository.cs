using Horas.Domain.Entities;

namespace Horas.Infraestructure.Persistence
{
    public interface IHourRepository : IDisposable
    {
        IEnumerable<Hour> GetHours();
        Hour GetHourByID(int HourId);
        void Create(Hour hour);
        Hour Update(Hour hour);
        void Delete(Hour hour);
        void Save();

    }

}