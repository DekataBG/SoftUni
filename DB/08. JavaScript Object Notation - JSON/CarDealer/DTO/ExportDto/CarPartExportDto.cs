using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CarDealer.DTO.ExportDto
{
    public class CarPartExportDto
    {
        public CarExportDto car { get; set; }

        public IEnumerable<PartExportDto> parts { get; set; }
    }
}