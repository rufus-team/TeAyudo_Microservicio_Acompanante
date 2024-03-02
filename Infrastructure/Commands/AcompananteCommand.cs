using Application.Interfaces.Commands;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Commands
{
    public class AcompananteCommand : IAcompananteCommand
    {
        private readonly AcompananteContext AcompananteContext;

        public AcompananteCommand(AcompananteContext AcompananteContext)
        {
            this.AcompananteContext = AcompananteContext;
        }

        public async Task<List<Tag>> AddCarectiscas(int AcompananteID, List<Tag> ListTag)
        {
            Acompanante Acompanante = await AcompananteContext.Acompanante.FindAsync(AcompananteID);
            foreach (Tag Tag in ListTag)
            {
                Acompanante.Tags.Add(Tag);
            }
            await AcompananteContext.SaveChangesAsync();
            return Acompanante.Tags;

        }

        public async Task<Acompanante> CreatedAcompanante(Acompanante Acompanante)
        {
            await AcompananteContext.AddAsync(Acompanante);
            await AcompananteContext.SaveChangesAsync();
            return Acompanante;
        }
    }
}
