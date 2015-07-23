using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.Data.Context.Config
{
    public class ContextInitializer : DropCreateDatabaseIfModelChanges<MusicStoreContext>
    {
        protected override void Seed(MusicStoreContext context)
        {

        }
    }
}