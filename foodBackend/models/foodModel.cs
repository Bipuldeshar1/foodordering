﻿using System.ComponentModel.DataAnnotations.Schema;

namespace foodBackend.models
{
    public class foodModel
    {
        public string Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string imageUrl { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public string address { get; set; }
        public bool outOfStock { get; set; }

        [ForeignKey("UserModel")]
        public string authorId { get; set; }

        public UserModel userModel { get; set; }
        [ForeignKey("CategoryModel")]
        public string categoryId { get; set; }
        public CategoryModel category { get; set; }


    }
}
