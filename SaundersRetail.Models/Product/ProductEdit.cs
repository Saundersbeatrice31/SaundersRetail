﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaundersRetail.Models.Product
{
    public class ProductEdit
    {
        public int ID { get; set; }
        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal RetailPrice { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? LastModified
        {
            get; set;
        }
    }
}