using Horas.Entities;

namespace Horas.Persistence
{
    public interface IHourRepository : IDisposable
    {
        IEnumerable<Hour> GetHours();
        Hour GetHourByID(int HourId);
        void Add(Hour hour);
        void Update(Hour hour);
        void Delete(Hour hour);
        void Save();

    }

}