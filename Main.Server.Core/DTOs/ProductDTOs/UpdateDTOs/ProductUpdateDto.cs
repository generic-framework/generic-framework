﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Server.Core.DTOs.ProductDTOs.UpdateDTOs
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
    }
}