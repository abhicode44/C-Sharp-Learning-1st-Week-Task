using MediatR;

namespace Demo_API.Features.Players.CreatePlayer
{
    public record CreatePlayerCommand(string Name , int Level ) : IRequest<int>;
}
