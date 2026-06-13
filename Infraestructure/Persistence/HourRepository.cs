using Horas.Domain.Entities;
namespace Horas.Infraestructure.Persistence
{

    public class HourRepository(HourContext hourContext) : IHourRepository, IDisposable
    {
        private readonly HourContext _hourContext = hourContext;

        public IEnumerable<Hour> GetHours()
        {
            return _hourContext.Hours.ToList();
        }


        public void Create(Hour hour)
        {
            _hourContext.Hours.Add(hour);
        }
        ///<summary>Returns the hour if its found.
        /// Throws an exception if the hour is not found</summary>
        public Hour GetHourByID(int HourId)
        {
            return _hourContext.Hours.FirstOrDefault(h => h.Id == HourId);
        }
        public Hour Update(Hour hour)
        {
            var h = GetHourByID(hour.Id);
            _hourContext.Entry(h).CurrentValues.SetValues(hour);
            Save();
            return h;            
        }
        public void Delete(Hour hour)
        {
            var h = GetHourByID(hour.Id);
            _hourContext.Hours.Remove(h);
        }
        public void Save()
        {
            _hourContext.SaveChanges();
        }

        private bool disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _hourContext.Dispose();
                }
            }
            disposed = true;
        }
         public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}