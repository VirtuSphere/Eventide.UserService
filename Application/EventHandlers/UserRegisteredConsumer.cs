using Eventide.AuthService.Contracts.Events;
using Eventide.UserService.Application.Commands.CreateProfile;
using MassTransit;
using MediatR;

namespace Eventide.UserService.Application.EventHandlers;

public class UserRegisteredConsumer : IConsumer<UserRegisteredEvent>
{
    private readonly IMediator _mediator;

    public UserRegisteredConsumer(IMediator mediator) => _mediator = mediator;

    public async Task Consume(ConsumeContext<UserRegisteredEvent> context)
    {
        var message = context.Message;
        
        await _mediator.Send(new CreateProfileCommand
        {
            AuthUserId = message.UserId,
            Username = message.Username,
            DisplayName = message.Username
        });
    }
}