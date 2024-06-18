﻿using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrderingApp.Models
{
    [Table("Ordered addons")]
    public class OrderAddon
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int AddonId { get; set; }
        public Addon Addon { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
