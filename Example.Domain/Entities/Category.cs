using ImprovedApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Domain.Entities
{
    public class Category : Entity
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
