using ImprovedApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Domain.Entities
{
    public class Supplier : Entity
    {
        public int SupplierID { get; set; }
        
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
     //  public AddressDetails AddressDetails { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string HomePage { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public Supplier()
        {
            //this.AddressDetails = new AddressDetails();
        }
    }
}
