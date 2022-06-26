using System.ComponentModel.DataAnnotations;

namespace GeorgeVlad.TicketingSystem.Tickets;

public enum ServiceType
{
    [Display(Name = "Design")]
    Design = 0,
    [Display(Name = "Development")]
    Development = 1,
    [Display(Name = "Api")]
    Api = 2,    
    [Display(Name = "Database")]
    Database = 3,
    [Display(Name = "Devops")]
    Devops = 4
}