using Microsoft.VisualBasic;
using System.Security.AccessControl;

namespace MarketEase_API.Entity
{
    public class Product
    {
        public Product()
        {
            IsDeleted = false;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }
        public int Quantity { get; set; }
        public bool IsDeleted { get; set; }
        public int PackagingTypesId { get; set; }
        public DateTime Validity { get; set; }

        public void Update(string name, float value, int quantity, DateTime validity)
        {
            Name = name;
            Value = value;
            Quantity = quantity;
            Validity = validity;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
