using Horas.Persistence;
using Horas.Entities;

namespace Horas.Services
{
  
    public class HourService(IHourRepository hourRepository)
    {
        //inyectar
        private readonly IHourRepository HourRepository = hourRepository;

        public Hour Sum(HourRequest request)
        {
            var h = request.H1 + request.H2;
            var m = request.M1 + request.M2;
            var s = request.S1 + request.S2;
            //persistencia
            var hour =new Hour(h,m,s);
            HourRepository.Add(hour);
            HourRepository.Save();
            return hour;
        }
        //public void Del(){}
    }

}