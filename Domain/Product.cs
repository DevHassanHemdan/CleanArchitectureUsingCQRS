using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Product : BaseClass
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        
        [ForeignKey("ProductTypeId")]
        public ProductType ProductType { get; set; }
        
        [ForeignKey("ProductBrandId")]
        public ProductBrand ProductBrand { get; set; }

        [ForeignKey("CategoryId")]
        public Categories Categories { get; set; }
    }
}