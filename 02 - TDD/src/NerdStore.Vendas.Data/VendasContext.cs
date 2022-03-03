using MediatR;
using Microsoft.EntityFrameworkCore;
using NerdStore.Core.Data;
using NerdStore.Core.DomainObjects;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.Vendas.Data
{
    public class VendasContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;

        public VendasContext(DbContextOptions<VendasContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        public async Task<bool> Commit()
        {
            var sucesso = await base.SaveChangesAsync() > 0;

            if (sucesso) await _mediator.PublicarEventos(this);

            return sucesso;
        }
    }

    public static class MediatorExtension
    {
        public static async Task PublicarEventos(this IMediator mediator, VendasContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Notifications != null && x.Entity.Notifications.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.Notifications)
                .ToList();

            domainEntities.ToList()
                .ForEach(e => e.Entity.LimparEventos());

            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    await mediator.Publish(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
