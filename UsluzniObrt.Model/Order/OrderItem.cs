using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsluzniObrt.Model
{
    /// <summary>
    /// tablica za "Shopping cart"
    /// </summary>
    public class OrderItem
    {
        [Key]
        [Column(Order = 0)]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        [Key]
        [Column(Order = 1)]
        public int MenuItemId { get; set; }
        public virtual MenuItem MenuItem { get; set; }

        [Column(Order = 2)]
        public int Quantity { get; set; }
    }
}
