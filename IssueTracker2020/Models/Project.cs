using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IssueTracker2020.Models

{
    public class Project

    {
        public Project()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Project Name")]
        public string Name { get; set; }

        public string ImagePath { get; set; }

        public byte[] Imagedata { get; set; }

        public List<ProjectUser> ProjectUsers { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}