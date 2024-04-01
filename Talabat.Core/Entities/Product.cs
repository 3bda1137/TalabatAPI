namespace Talabat.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }

        public int BrandId { get; set; }//foregin Key  -->ProductBrand

        public ProductBrand Brand { get; set; }//navigation Proparty one

        public int CategoryId { get; set; }//foregin Key  -->ProductCategory
        public ProductCategory Category { get; set; }//navigation Proparty one
    }
}
