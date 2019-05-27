using ImprovedApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestForeignKey.Domain.Entities
{
    public class ToOne : ImprovedEntity
    {
        protected ToOne() { }
        public ToOne(Many many, string property01)
        {
            Many = many;
            Property01 = property01;
        }

        public int ToOneID { get; private set; }

        public string Property01 { get; private set; }
        public string Property02 { get; private set; }
        public string Property03 { get; private set; }
        public string Property04 { get; private set; }

        public long? ManyID { get; private set; }
        public Many Many { get; private set; }

    }
}
