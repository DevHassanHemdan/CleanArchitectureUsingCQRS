using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Product : BaseClass
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        public Guid ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        public Guid ProductBrandId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public Guid CategoriesId { get; set; }
        public Categories Categories { get; set; }
    }
}