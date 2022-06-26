using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GeorgeVlad.TicketingSystem.Tickets.Dto;

public class CreateTicketDto
{
    public CreateTicketDto()
    {
        TicketCreationDate = DateTime.Now;
    }
    public TicketType TicketType { get; set; } // un select cu ceva gen Epic Story, Task, Bug?

    public string CustomerName { get; set; }
    public ServiceType ServiceType { get; set; }

    [DefaultValue(PriorityType.Low)]
    public PriorityType Priority { get; set; }

    [Required]
    public string Subject { get; set; } //titlu?
    [StringLength(1000)]
    public string Description { get; set; }
    public DateTime TicketCreationDate { get; set; }
    public DateTime? TicketCloseDate { get; set; }
}