using System.ComponentModel.DataAnnotations;

namespace GeorgeVlad.TicketingSystem.Tickets;

public enum StatusType
{
    [Display(Name = "New")]
    New = 0,
    [Display(Name = "Active")]
    Active = 1,
    [Display(Name = "Closed")]
    Closed = 2
}