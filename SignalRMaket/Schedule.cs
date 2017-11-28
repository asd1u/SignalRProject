

namespace SignalRMaket
{
    using ORM;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;

    public static class Schedule 
    {
        private static Timer timer = new Timer();
        private static List<Tuple<Guid, DateTime>> rentedCars = new List<Tuple<Guid, DateTime>>();
        public static void RentCar(Guid guid, int hours)
        {
            rentedCars.Add(new Tuple<Guid, DateTime>(guid, DateTime.Now.AddHours(hours)));
        }
        public static void ScheduleInit()
        {
            // 
            // timer
            // 
            timer.Tick += TimerTick;
            //раз в 10 секунд
            timer.Interval = 10000;
        }

        private static void TimerTick(object sender, EventArgs e)
        {
            foreach (var rentedCar in rentedCars)
            {
                if(rentedCar.Item2 < DateTime.Now)
                {
                    var conn = new DBConnectionString();
                    var car = conn.Автомобиль.FirstOrDefault(x => x.id == rentedCar.Item1);
                    if(car != null)
                    {
                        car.Доступность = true;
                    }
                    rentedCars.Remove(rentedCar);
                    conn.SaveChangesAsync();
                }
            }
        }
    }
}