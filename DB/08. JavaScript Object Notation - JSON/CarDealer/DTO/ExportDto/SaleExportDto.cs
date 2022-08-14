using CarDealer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CarDealer.DTO.ExportDto
{
    [JsonObject]
    public class SaleExportDto
    {
        [JsonProperty("car")]
        public CarExportDto Car { get; set; }

        [JsonProperty("customerName")]
        public string CustomerName { get; set; }

        [JsonProperty("Discount")]
        public string Discount { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("priceWithDiscount")]
        public string PriceWithDiscount
            => (decimal.Parse(this.Price) - decimal.Parse(this.Price) * decimal.Parse(this.Discount) / 100).ToString("f2");
    }
}