﻿namespace Durgerking.Api.Dtos
{
    public class CreateProductDto
    {
        public  string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
