using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace GeorgeVlad.TicketingSystem.Tickets.Dto;

public class TicketDto : EntityDto<int>
{
    public TicketType TicketType { get; set; } // un select cu ceva gen Epic Story, Task, Bug?

    public string CustomerName { get; set; }
    public ServiceType ServiceType { get; set; }
    public PriorityType Priority { get; set; }
    public string Subject { get; set; } //titlu?
    public string Description { get; set; }
    public StatusType Status { get; set; }

    public DateTime TicketCreationDate { get; set; }
    public DateTime? TicketCloseDate { get; set; }
}