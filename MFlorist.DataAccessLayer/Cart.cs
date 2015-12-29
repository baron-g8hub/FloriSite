using System;


namespace MFlorist.DataAccessLayer
{
    public partial class Cart
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public int ProductId { get; set; }
        public decimal Amount { get; set; }
        public Nullable<System.DateTime> DatePurchased { get; set; }
        public bool IsInCart { get; set; }

        public virtual Product Product { get; set; }
    }
}