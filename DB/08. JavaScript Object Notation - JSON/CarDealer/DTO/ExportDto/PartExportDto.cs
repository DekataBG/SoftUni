using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CarDealer.DTO.ExportDto
{
    public class PartExportDto
    {
        public string Name { get; set; }

        public string Price { get; set; }
    }
}