using System.ComponentModel.DataAnnotations;

namespace GeorgeVlad.TicketingSystem.Tickets;

public enum PriorityType
{
    [Display(Name = "Low")]
    Low = 0,
    [Display(Name = "Medium")]
    Medium = 1,
    [Display(Name = "High")]
    High = 2
}