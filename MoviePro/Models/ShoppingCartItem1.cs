﻿using System.ComponentModel.DataAnnotations;

namespace MoviePro.Models
{
    public class ShoppingCartItem1
    {
        [Key]
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
