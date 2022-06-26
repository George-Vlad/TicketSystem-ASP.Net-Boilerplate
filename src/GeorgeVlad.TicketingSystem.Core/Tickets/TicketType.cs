using System.ComponentModel.DataAnnotations;

namespace GeorgeVlad.TicketingSystem.Tickets;

public enum TicketType
{
    [Display(Name = "Task")]
    Task = 0,
    [Display(Name = "Bug")]
    Bug = 1,

}