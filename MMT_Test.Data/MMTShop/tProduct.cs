using System;
using System.Collections.Generic;

#nullable disable

namespace MMT_Test.Data.MMTShop
{
    public partial class tProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public decimal? Price { get; set; }
        public bool Featured { get; set; }
        public int? CategoryId { get; set; }

        public virtual tCategory Category { get; set; }
    }
}
