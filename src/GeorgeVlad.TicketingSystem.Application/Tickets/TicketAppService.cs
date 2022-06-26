using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using GeorgeVlad.TicketingSystem.Dto;
using GeorgeVlad.TicketingSystem.Tickets.Dto;

namespace GeorgeVlad.TicketingSystem.Tickets;

[AbpAuthorize]
public class TicketAppService : TicketingSystemAppServiceBase, ITicketAppService
{
    private readonly IRepository<Ticket> _ticketRepository;

    public TicketAppService(IRepository<Ticket> ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<PagedResultDto<TicketListDto>> GetTicketListAsync()
    {
        var ticketListQuery = _ticketRepository
            .GetAll()
            .Where(t=>t.Status != StatusType.Closed)
            .Select(t => new TicketListDto
            {
                Id = t.Id,
                Subject = t.Subject,
                TicketType = t.TicketType,
                CustomerName = t.CustomerName,
                ServiceType = t.ServiceType,
                Status = t.Status,
                TicketCreationDate = t.CreationTime,
                TicketCloseDate = t.TicketCloseDate
            });

        var result = new PagedResultQueryableDto<TicketListDto>(ticketListQuery);
        return await result.GetAsync();
    }

    public async Task CreateTicketAsync(CreateTicketDto input)
    {

        var userId = AbpSession.UserId;
        if (!userId.HasValue) throw new UserFriendlyException(L("NotAuthorized"));

        var model = new Ticket
        {
            TicketType = input.TicketType,
            CustomerName = input.CustomerName,
            ServiceType = input.ServiceType,
            Priority = input.Priority,
            Subject = input.Subject,
            Description = input.Description,
            Status = StatusType.New,
            CreationTime = DateTime.Now
        };

        await _ticketRepository.InsertAsync(model);
    }

    public async Task UpdateTicketAsync(EditTicketDto input)
    {
        var userId = AbpSession.UserId;
        if (!userId.HasValue) throw new UserFriendlyException(L("NotAuthorized"));

        var ticket = await _ticketRepository.FirstOrDefaultAsync(input.Id);
        
        if (ticket == null)
            throw new UserFriendlyException(L("CannotFindTicket"));

        ticket.TicketType = input.TicketType;
        ticket.CustomerName = input.CustomerName;
        ticket.ServiceType = input.ServiceType;
        ticket.Priority = input.Priority;
        ticket.Subject = input.Subject;
        ticket.Description = input.Description;
        ticket.Status = input.Status;
        await _ticketRepository.UpdateAsync(ticket);
    }

    public async Task DeleteTicketAsync(int id)
    {
        var userId = AbpSession.UserId;
        if (!userId.HasValue) throw new UserFriendlyException(L("NotAuthorized"));

        var ticket = await _ticketRepository.FirstOrDefaultAsync(id);

        if (ticket == null)
            throw new UserFriendlyException(L("CannotFindTicket"));

        await _ticketRepository.DeleteAsync(id);
    }

    public async Task<TicketDto> GetTicketAsync(int id)
    {
        var ticket = await _ticketRepository.GetAsync(id);
        //daca nu exista da eroare direct ca e PK

        var model = new TicketDto
        {
            Id = ticket.Id,
            TicketType = ticket.TicketType,
            CustomerName = ticket.CustomerName,
            ServiceType = ticket.ServiceType,
            Priority = ticket.Priority,
            Subject = ticket.Subject,
            Description = ticket.Description,
            Status = ticket.Status,
            TicketCreationDate = ticket.CreationTime,
            TicketCloseDate = ticket.TicketCloseDate
        };
        return model;
    }

    public async Task ChangeStatusAsync(int id, StatusType status)
    {
        var userId = AbpSession.UserId;

        if (!userId.HasValue) throw new UserFriendlyException(L("NotAuthorized"));

        var ticket = await _ticketRepository.FirstOrDefaultAsync(id);

        if (ticket == null)
            throw new UserFriendlyException(L("CannotFindTicket"));

        //un task deja inchis, nu mai poate fi modificat
        if (ticket.Status == StatusType.Closed)
            throw new UserFriendlyException(L("NotAuthorized"));

        //doar taskul activ poate fi doar inchis
        if (ticket.Status == StatusType.Active && status != StatusType.Closed)
            throw new UserFriendlyException(L("The ticket status is already Active"));

        if (status == StatusType.Closed)
        {
            ticket.Status = StatusType.Closed;
            ticket.TicketCloseDate = DateTime.Now;
        }
        else
        {
            ticket.Status = StatusType.Active;
        }
        await _ticketRepository.UpdateAsync(ticket);
    }
}