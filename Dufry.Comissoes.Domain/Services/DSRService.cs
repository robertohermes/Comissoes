using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository;
using Dufry.Comissoes.Domain.Interfaces.Repository.ReadOnly;
using Dufry.Comissoes.Domain.Interfaces.Service;
using Dufry.Comissoes.Domain.Services.Common;

namespace Dufry.Comissoes.Domain.Services
{
    public class DSRService : Service<DSR>, IDSRService
    {
        private readonly IDSRReadOnlyRepository _readOnlyRepository;
        private readonly IDSRRepository _repository;
        public DSRService(IDSRRepository repository, IDSRReadOnlyRepository readOnlyRepository, IDSRReadOnlyRepository readOnlyRepository1)
            : base(repository, readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository1;
            _repository = repository;
        }



    }
}
