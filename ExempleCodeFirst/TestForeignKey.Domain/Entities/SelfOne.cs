using ImprovedApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestCodeFirst.Domain.Entities
{
    public class SelfOne : ImprovedEntity
    {
        protected SelfOne() { }
        public SelfOne(SelfOne self, Many many, string property01)
        {
            BaseSelfOne = self;
            Property01 = property01;
            Many = many;
        }

        public int SelfOneID { get; private set; }

        public string Property01 { get; private set; }
        public string Property02 { get; private set; }
        public string Property03 { get; private set; }
        public string Property04 { get; private set; }

        public long? ManyID { get; private set; }
        public int? BaseSelfOneID { get; private set; }
        public SelfOne BaseSelfOne { get; private set; }
        public Many Many { get; private set; }
    }
}
