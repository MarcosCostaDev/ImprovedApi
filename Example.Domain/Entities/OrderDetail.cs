using ImprovedApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Domain.Entities
{
    public class OrderDetail : Entity
    {
       
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
