namespace Cars.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Dealer
    {
        public int Id { get; set; }

        private ICollection<City> cities;

        public Dealer()
        {
            this.cities = new HashSet<City>();
        }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<City> Cities 
        {
            get 
            {
                return this.cities;
            }
            set
            {
                this.cities = value;
            }
        }
    }
}
