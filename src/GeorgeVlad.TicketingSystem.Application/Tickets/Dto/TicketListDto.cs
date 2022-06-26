using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace GeorgeVlad.TicketingSystem.Tickets.Dto;

public class TicketListDto : EntityDto<int>
{
    [Required]
    public string Subject { get; set; } //titlu?
    public TicketType TicketType { get; set; } // select Task, Bug,
    public string CustomerName { get; set; }
    public ServiceType ServiceType { get; set; } //design, development, api, database, devops
    
    [DefaultValue(StatusType.New)]
    public StatusType Status { get; set; }

    public DateTime TicketCreationDate { get; set; }
    public DateTime? TicketCloseDate { get; set; }
    public bool TicketClosed => TicketCloseDate.HasValue;

}