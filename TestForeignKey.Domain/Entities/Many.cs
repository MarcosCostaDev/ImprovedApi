using ImprovedApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestForeignKey.Domain.Entities
{
    public class Many : ImprovedEntity
    {
        protected Many() { }
        public Many(One one, string manyProperty01)
        {
            One = one;
            ManyProperty01 = manyProperty01;
        }

        public long ManyID { get; private set; }
        public int OneID { get; private set; }       
        public string ManyProperty01 { get; private set; }
        public string ManyProperty02 { get; private set; }
        public string ManyProperty03 { get; private set; }
        public string ManyProperty04 { get; private set; }

        public One One { get; private set; }
        public ToOne ToOne { get; private set; }
        public IEnumerable<SelfOne> SelfOne { get; private set; }


    }
}
