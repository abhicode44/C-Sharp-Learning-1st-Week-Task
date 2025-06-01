using Demo_API.Data;
using Demo_API.Models;
using MediatR;

namespace Demo_API.Features.Players.CreatePlayer
{
    
    public class CreatePlayerHandler : IRequestHandler<CreatePlayerCommand, int>
    {
        private readonly MyContext _context;

        public CreatePlayerHandler(MyContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = new Player { Name = request.Name, Level = request.Level };
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return (player.Id);
        }
    }
}
