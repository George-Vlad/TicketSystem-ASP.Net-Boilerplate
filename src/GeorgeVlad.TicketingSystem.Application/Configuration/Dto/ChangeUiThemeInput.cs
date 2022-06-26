using System.ComponentModel.DataAnnotations;

namespace GeorgeVlad.TicketingSystem.Configuration.Dto
{
    public class ChangeUiThemeInput
    {
        [Required]
        [StringLength(32)]
        public string Theme { get; set; }
    }
}
