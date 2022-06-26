$(function ($) {
    var _service = abp.services.app.ticket,
        l = abp.localization.getSource('TicketingSystem'),
        _$modal = $('#TicketCreateModal'),
        _$form = _$modal.find('form'),
        $ticketsTable = $('#TicketsTable');

    var dTable = $ticketsTable.DataTable({
        paging: true,
        retrieve: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            abp.ui.setBusy($ticketsTable);
            _service.getTicketList().done(function (result) {
                callback({
                    recordsTotal: result.totalCount,
                    recordsFiltered: result.totalCount,
                    data: result.items
                });
            }).always(function () {
                abp.ui.clearBusy($ticketsTable);
            });
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: function () {
                    return dTable.draw(false);
                }
            }
        ],
        responsive: {
            details: {
                type: "column"
            }
        },
        columnDefs: [
            {
                targets: 0,
                className: "control",
                defaultContent: ""
            },
            {
                targets: 1,
                sortable: false,
                render: function (data, type, row, meta) {
                    return row.subject;

                }
            },
            {
                targets: 2,
                sortable: false,
                render: function (data, type, row, meta) {
                    if (row.ticketType == 0) {
                        return "Task";
                    }
                    else
                        return "Bug";
                }
            },
            {
                targets: 3,
                sortable: false,
                render: function (data, type, row, meta) {
                    return row.customerName;
                }
            },
            {
                targets: 4,
                sortable: false,
                render: function (data, type, row, meta) {
                    if (row.serviceType == 0) {
                        return "Design";
                    } else if (row.serviceType == 1) {
                        return "Development";
                    } else if (row.serviceType == 2) {
                        return "Api";
                    } else if (row.serviceType == 3) {
                        return "Database";
                    } else {
                        return "Devops";
                    }
                }
            },
            {
                targets: 5,
                sortable: false,
                render: function (data, type, row, meta) {
                    if (row.status == 0) {
                        return "New";
                    } else if (row.status == 1) {
                        return "Active";
                    } else {
                        return "Closed";
                    }
                }
            },
            {
                targets: 6,
                sortable: false,
                className: "text-center",
                render: function (data, type, row, meta) {
                    return [
                        `   <button type="button" class="btn btn-sm bg-primary edit-ticket mb-sm-1" data-id="${row.id}" data-toggle="modal" data-target="#TicketEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-ticket mb-sm-1" data-id="${row.id}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-secondary change-status mb-sm-1" data-id="${row.id}">`,
                        `       <i class="fas fa-retweet"></i> ${l('ChangeStatus')}`,
                        '   </button>',
                    ].join('');
                }
            }
        ]
    });

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var ticket = _$form.serializeFormToObject();
        abp.ui.setBusy(_$modal);
        _service
            .createTicket(ticket)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                dTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });

    abp.event.on('ticket.edited', () => {
        dTable.ajax.reload();
    });


    function deleteTicket(Id) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                "the ticket"),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _service.deleteTicket(Id).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        dTable.ajax.reload();
                    });
                }
            }
        );
    }

    $(document)
        .on('click',
            '.edit-ticket',
            function (e) {
                const $that = $(e.currentTarget);
                const id = $that.attr("data-id");

                e.preventDefault();
                abp.ajax({
                    url: abp.appPath + 'Home/EditTicketModal/' + id,
                    type: 'POST',
                    dataType: 'html',
                    success: function (content) {
                        $('#TicketEditModal div.modal-content').html(content);
                    },
                    error: function (e) {
                    }
                });
            })
        .on('click', '.delete-ticket', function (e) {
            const $that = $(e.currentTarget);
            const id = $that.attr("data-id");

            deleteTicket(id);
        })
        .on('click', '.change-status', function (e) {
            const $that = $(e.currentTarget);
            const id = $that.attr("data-id");

            swal({
                title: "Please select the new status",
                buttons: {
                    Cancel: {
                        text: "Cancel",
                        value: 0,
                        className: "bg-secondary",
                    },
                    Active: {
                        text: "Active",
                        value: 1,
                        className: "bg-primary",
                    },
                    Closed: {
                        text: "Closed",
                        value: 2,
                        className: "bg-danger",
                    },
                },
            })
                .then((value) => {
                    if (value == 0 || value == null) {
                        swal.close();
                    } else {
                        _service.changeStatus(id, value).done(() => {
                            dTable.ajax.reload();
                        });
                        swal("Status changed successfully", {
                            icon: "success",
                        });

                    }
                });
        });
});
