﻿using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository;
using Dufry.Comissoes.Domain.Interfaces.Repository.ReadOnly;
using Dufry.Comissoes.Domain.Interfaces.Service;
using Dufry.Comissoes.Domain.Services.Common;

namespace Dufry.Comissoes.Domain.Services
{
    public class CategoriaService : Service<Categoria>, ICategoriaService
    {
        private readonly ICategoriaReadOnlyRepository _readOnlyRepository;
        private readonly ICategoriaRepository _repository;
        public CategoriaService(ICategoriaRepository repository, ICategoriaReadOnlyRepository readOnlyRepository, ICategoriaReadOnlyRepository readOnlyRepository1)
            : base(repository, readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository1;
            _repository = repository;
        }



    }
}
