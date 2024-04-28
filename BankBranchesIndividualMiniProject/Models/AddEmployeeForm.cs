using System.ComponentModel.DataAnnotations;

namespace BankBranchesIndividualMiniProject.Models
{
    public class AddEmployeeForm
    {
        public int BranchId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CivilId { get; set; }
        [Required]
        public string Position { get; set; }
    }
}
