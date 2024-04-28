using System.ComponentModel.DataAnnotations;

namespace BankBranchesIndividualMiniProject.Models
{
    public class EditBranch
    {
        [Key]
        public int BranchId { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Url)]
        public string Location { get; set; }

        [Required]
        public string BranchManager { get; set; }

        [Range(1, 100)]
        public int EmployeeCount { get; set; }
    }
}
