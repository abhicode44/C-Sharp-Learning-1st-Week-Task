using Demo_API.Models;
using MediatR;

namespace Demo_API.Features.Players.GetPlayerById
{
   public record GetPlayerByIdQuery(int Id) : IRequest<Player>;
}
