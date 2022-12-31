using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class BaseClass
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public BaseClass()
        {
            Id = Guid.NewGuid(); 
        }
    }
}