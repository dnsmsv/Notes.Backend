using MediatR;
using System;

namespace Notes.Application.Notes.Commands.DeleteCommand
{
    public class DeleteNoteCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
