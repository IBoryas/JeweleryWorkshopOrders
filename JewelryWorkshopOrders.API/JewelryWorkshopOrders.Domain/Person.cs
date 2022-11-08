using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Domain
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public string FullName()
        {
            var result = $"{LastName} {FirstName[0]}.";
            if (Patronymic!=null)
                result+=$"{Patronymic[0]}.";
            return result;
        }
    }
}
