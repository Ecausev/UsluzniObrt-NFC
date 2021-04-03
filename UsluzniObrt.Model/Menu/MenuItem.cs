namespace UsluzniObrt.Model
{
    /// <summary>
    /// Tablica za proizvod
    /// </summary>
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public MenuItemStatus Status { get; set; }

        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
