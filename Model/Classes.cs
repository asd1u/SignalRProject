using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
    public enum tAvialability
    {
        Доступна,
        Недоступна
    }
    public class Car
    {
        public Guid Id { get; set; }
        public Brand Brand { get; set; }
        public string Description { get; set; }
        public tAvialability Avialability { get; set; }
    }

    public class Brand
    {
        public Guid Id { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
    }
}
