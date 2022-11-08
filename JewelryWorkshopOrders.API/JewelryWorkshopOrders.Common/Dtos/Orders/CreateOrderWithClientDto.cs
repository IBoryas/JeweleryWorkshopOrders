using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Common.Dtos.Orders
{
    public class CreateOrderWithClientDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Patronymic { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        
        [Required]
        public int ProductId { get; set; }
        
        [Required]
        public int MaterialId { get; set; }
        
        [Required]
        public double TakenWeight { get; set; }
        
        [Required]
        public double Price { get; set; }

        public string Notes { get; set; }
    }
}
