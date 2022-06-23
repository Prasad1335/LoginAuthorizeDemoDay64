using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LoginDemoDay64.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string Name { get; set; }
        [StringLength(500)]
        [Unicode(false)]
        public string Description { get; set; }

        [InverseProperty(nameof(Employee.DepartmentRef))]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
