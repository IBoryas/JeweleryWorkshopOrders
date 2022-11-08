﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Common.Dtos.Client
{
    public class CreateClientDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        public string Patronymic { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
    }
}
