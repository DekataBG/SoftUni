﻿namespace Trucks.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ClientTruck
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int TruckId { get; set; }
        public Truck Truck { get; set; }
    }
}

//ClientTruck
//⦁	ClientId – integer, Primary Key, foreign key (required)
//⦁	Client – Client
//⦁	TruckId – integer, Primary Key, foreign key (required)
//⦁	Truck – Truck


