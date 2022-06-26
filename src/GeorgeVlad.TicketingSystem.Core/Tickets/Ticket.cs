using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace GeorgeVlad.TicketingSystem.Tickets;

[Table("Tickets", Schema = "vsm")]
public class Ticket : Entity, IHasCreationTime
{
    public const int MaxSubjectLength = 50;
    public const int MaxNameLength = 50;
    public const int MaxDescriptionLength = 1000;

    [Key]
    [Required]
    [Column("IdTicket")]
    public override int Id { get; set; }
    public TicketType TicketType { get; set; }

    [StringLength(MaxNameLength)]
    public string CustomerName { get; set; }
    public ServiceType ServiceType { get; set; }
    public PriorityType Priority { get; set; }
    [Required]
    [StringLength(MaxSubjectLength)]
    public string Subject { get; set; }
    [Required]
    [StringLength(MaxDescriptionLength)]
    public string Description { get; set; }
    public StatusType Status { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime? TicketCloseDate { get; set; }

}