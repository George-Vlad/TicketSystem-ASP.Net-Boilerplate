using System.ComponentModel.DataAnnotations;

namespace GeorgeVlad.TicketingSystem.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}