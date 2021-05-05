using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZaropaMVC.Entities
{

 

    public class Tiers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Genders? Genders { get; set; }
        public virtual ICollection<Shoes> Shoes { get; set; }
    }
}