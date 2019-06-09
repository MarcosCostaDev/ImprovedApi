using ImprovedApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestCodeFirst.Domain.Entities
{
    public class One : ImprovedEntity
    {
        protected One() { }
        public One(string oneProperty01)
        {
            OneProperty01 = oneProperty01;
        }

        public int OneID { get; private set; }

        public string OneProperty01 { get; private set; }
        public string OneProperty02 { get; private set; }
        public string OneProperty03 { get; private set; }
        public string OneProperty04 { get; private set; }

        public IEnumerable<Many> Many { get; private set; }

    }
}
