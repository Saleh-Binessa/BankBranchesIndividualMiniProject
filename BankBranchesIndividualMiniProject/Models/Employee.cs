using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankBranchesIndividualMiniProject.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CivilId { get; set; }
        [Required]
        public string Position { get; set; }

        //[ForeignKey("BranchId")]
        public int WorkplaceId { get; set; }
        public BankBranch Workplace { get; set; }
    }
}

