namespace Cars.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Manufacturer
    {
        public int Id { get; set; }
        
        [Required]
        [Index(IsUnique = true)]
        [MaxLength(10)]
        public string Name { get; set; }
    }
}
