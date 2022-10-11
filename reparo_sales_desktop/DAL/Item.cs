using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemCode { get; set; }
        public int ItemTypeId { get; set; }
        public string ItemType { get; set; }
        public string ItemName { get; set; }
        public decimal Cost { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal DiscountPrcentsge { get; set; }
        public bool IsActive { get; set; }
        public string LastModified { get; set; }
        public int ModifiedUserId { get; set; }
        public string ModifiedBy { get; set; }
    }
}
