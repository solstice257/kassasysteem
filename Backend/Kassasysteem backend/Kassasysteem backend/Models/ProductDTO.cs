﻿namespace Kassasysteem_backend.Models
{
    public class ProductDTO
    {
        public long productId { get; set; }
        public string productName { get; set; }
        public int userPin { get; set; }
        public float productPrice { get; set; }
        public float taxAmount { get; set; }
    }
}