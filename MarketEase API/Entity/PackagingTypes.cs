namespace MarketEase_API.Entity
{
    public class PackagingTypes
    {
        public PackagingTypes()
        {
            IsDeleted = false;
        }

        public int Id { get; set; }
        public int Size { get; set; }
        public int Fragility { get; set; }
        public bool IsDeleted { get; set; }
        public List<Product> product { get; set; }

        public void Update(int size, int fragility)
        {
            Size = size;
            Fragility = fragility;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
