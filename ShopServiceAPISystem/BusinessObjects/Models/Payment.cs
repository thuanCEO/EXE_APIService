namespace BusinessObjects.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string MethodName { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
