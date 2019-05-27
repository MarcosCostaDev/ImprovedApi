using ImprovedApi.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestForeignKey.Domain.ViewModels
{
    public class ManyQueryViewModel : ImprovedQueryViewModel
    {

        public int OneID { get; set; }
        public long ManyID { get; set; }
        public string CustomProperty { get; set; }
        public string OneOneProperty01 { get; set; }
        public string OneOneProperty02 { get; set; }
        public string OneOneProperty03 { get; set; }
        public string OneOneProperty04 { get; set; }
        public string ManyProperty01 { get; set; }
        public string ManyProperty02 { get; set; }
        public string ManyProperty03 { get; set; }
        public string ManyProperty04 { get; set; }

        public int QuantitySelfElement { get; set; }

    }
}
