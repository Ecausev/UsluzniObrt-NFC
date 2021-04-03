using System.Collections.Generic;

namespace UsluzniObrt.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MenuItem> MenuItems { get; set; }
    }
}
