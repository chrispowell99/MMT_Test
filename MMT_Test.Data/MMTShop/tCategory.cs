using System;
using System.Collections.Generic;

#nullable disable

namespace MMT_Test.Data.MMTShop
{
    public partial class tCategory
    {
        public tCategory()
        {
            Products = new HashSet<tProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<tProduct> Products { get; set; }
    }
}
