using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZaropaMVC.Entities
{

    public class Shoes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tier { get; set; }
      public virtual ICollection<Product> Products { get; set; }
        public int TiersId { get; set; }
        public Genders? Genders { get; set; }
        public virtual Tiers Tiers { get; set; }
    }
}