using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZaropaMVC.Entities
{

    public enum Employees{
        Lizade = 1,
        Arietty, 
        Ty,
        Christopher,
        John,
        Danish,
        Shelby,
        Harpreet,
        Emily,
        Saimun,
        Lindsay,
        Sean,
        Other = 9995
    }

   public enum SaleStatus
    {
        Contacted = 1,
        Negotiation, 
        ProcessingSale,
        CompletedSale,
        Rejected

    }

    
    public class Sales
    {
        public int Id { get; set; }
        public Employees? Employees { get; set; }
        [Display(Name ="Firm Name")]
        public string FirmName { get; set; }
        [Display(Name = "Firm Email")]
        public string FirmEmail { get; set; }
        [Display(Name ="Firm Phone Number")]
        public string FirmPhoneNumber { get; set; }
        public DateTime DateTime { get; set; }
        [Display(Name ="Sale Status")]
        public SaleStatus SaleStatus { get; set; }
        public int Profit { get; set; }
    }

}