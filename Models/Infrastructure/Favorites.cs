﻿namespace RuralCourtyard.Models.Infrastructure
{
    public class Favorites
    {
        public int Id { get; set; }
        public User User { get; set; }
        public List<Product> Products { get; set; }
    }
}