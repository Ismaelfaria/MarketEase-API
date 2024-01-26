namespace MarketEase_API.Entity
{
    public class PackagingTypes
    {
        public int Id { get; set; }
        public int Size { get; set; }
        public int fragility { get; set; }
        public List<Product> product { get; set; }
    }
}
