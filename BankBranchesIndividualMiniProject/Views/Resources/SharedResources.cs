using System.ComponentModel.DataAnnotations;

namespace BankBranchesIndividualMiniProject.Views.Resources
{
    public class SharedResources
    {
        [Required(ErrorMessageResourceType = typeof(SharedResources),
          ErrorMessageResourceName = "BranchNameRequired")]
        [Display(Name = nameof(SharedResources.Name), ResourceType = typeof(SharedResources))]
        public string Name { get; set; }

    }
}
