using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CarDealer.DTO.ExportDto
{
    public class SupplierExportDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PartsCount { get; set; }
    }
}