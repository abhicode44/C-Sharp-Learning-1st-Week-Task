using Demo_API.Data;
using Demo_API.Models;
using MediatR;

namespace Demo_API.Features.Players.GetPlayerById
{
    public class GetByIdQueryHandler : IRequestHandler<GetPlayerByIdQuery, Player>
    {
        private readonly MyContext _context;
    
        public async Task<Player> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
        {
            var player = await _context.Players.FindAsync(request.Id);
            return player;
        }
    }
}
