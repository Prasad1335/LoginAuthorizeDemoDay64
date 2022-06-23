using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LoginDemoDay64.Models
{
    public partial class Nationality
    {
        public Nationality()
        {
            Employees = new HashSet<Employee>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string Text { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string Continent { get; set; }
        public int CountryPopulation { get; set; }

        [InverseProperty(nameof(Employee.NationalityRef))]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
