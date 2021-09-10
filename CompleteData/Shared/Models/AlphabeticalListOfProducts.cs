using System;
using System.Collections.Generic;
 using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

namespace CompleteData.Shared.Models
{
    public partial class AlphabeticalListOfProducts
    {

        [Key]
        [Column(Order = 0)]
        public int ProductId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool Discontinued { get; set; }

        [Key]
        [Column(Order = 3)]
        public string CategoryName { get; set; }
    }
}
