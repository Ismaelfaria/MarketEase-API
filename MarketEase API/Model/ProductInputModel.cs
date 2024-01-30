using MarketEase_API.Entity;

namespace MarketEase_API.Mapper
{
    public class ProductInputModel
    {
        public string Name { get; set; }
        public float Value { get; set; }
        public int Quantity { get; set; }
        public int PackagingTypesId { get; set; }
        public DateTime Validity { get; set; }
    }

    public class PackInputModel()
    {
        public int Size { get; set; }
        public int Fragility { get; set; }
    }
}
