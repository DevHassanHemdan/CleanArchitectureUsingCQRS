using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Product : BaseClass
    {
        public float Price { get; set; }
        public string Description { get; set; }
        [ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }
        public Categories Categories { get; set; }
    }
}