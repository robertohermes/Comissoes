﻿using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository.Common;

namespace Dufry.Comissoes.Domain.Interfaces.Repository.ReadOnly
{
    public interface IPlanoCategoriaReadOnlyRepository : IReadOnlyRepository<PlanoCategoria>
    {
        void Insert(PlanoCategoria planoCategoria);

        void Update(PlanoCategoria planoCategoria);

        void Delete(PlanoCategoria planoCategoria);
    
    }
}
