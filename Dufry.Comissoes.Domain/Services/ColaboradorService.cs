using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository;
using Dufry.Comissoes.Domain.Interfaces.Repository.ReadOnly;
using Dufry.Comissoes.Domain.Interfaces.Service;
using Dufry.Comissoes.Domain.Services.Common;
using System.Collections.Generic;

namespace Dufry.Comissoes.Domain.Services
{
    public class ColaboradorService : Service<Colaborador>, IColaboradorService
    {
        private readonly IColaboradorReadOnlyRepository _readOnlyRepository;
        private readonly IColaboradorRepository _repository;

        public ColaboradorService(IColaboradorRepository repository, IColaboradorReadOnlyRepository readOnlyRepository, IColaboradorReadOnlyRepository readOnlyRepository1)
            : base(repository, readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository1;
            _repository = repository;
        }

        public IEnumerable<KeyValuePair<string, string>> All_ID_COMPOSTO()
        {
            //Acesso através do Dapper
            return _readOnlyRepository.All_ID_COMPOSTO();

        }

    }
}
