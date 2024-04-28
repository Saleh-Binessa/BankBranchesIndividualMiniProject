using System.ComponentModel.DataAnnotations;

namespace BankBranchesIndividualMiniProject.Models
{
    public class BankBranch
    {
        [Key]
        public int BranchId { get; set; }

        [Required(ErrorMessageResourceType = typeof(BankBranch), ErrorMessageResourceName = "BranchNameRequired")]
        [Display(Name = nameof(BankBranch.Name), ResourceType = typeof(BankBranch))]
        public string Name { get; set; }

        [Url]
        public string Location { get; set; }

        [Required]
        public string BranchManager { get; set; }

        [Range(1, 100)]
        public int EmployeeCount { get; set; }
        [Required]
        public List<Employee> Employees { get; set; }
    }
}
