using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZaropaMVC.Entities
{

    public enum  Genders{
        Men=1,
        Women=2,
        Other=3
    }

    public class Product
    {

        

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public string BuyButton { get; set; }
        public string ImageUrl { get; set; }
        public string Tier { get; set; }
        public string RetailPrice { get; set; }
        public string Gender { get; set; }
        public Genders? Genders { get; set; }
       public int ShoesId { get; set; }
        public virtual Shoes Shoes { get; set; }
       
    }
}