using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository;
using Dufry.Comissoes.Domain.Interfaces.Repository.ReadOnly;
using Dufry.Comissoes.Domain.Interfaces.Service;
using Dufry.Comissoes.Domain.Services.Common;

namespace Dufry.Comissoes.Domain.Services
{
    public class PlanoCategoriaService : Service<PlanoCategoria>, IPlanoCategoriaService
    {
        private readonly IPlanoCategoriaReadOnlyRepository _readOnlyRepository;
        private readonly IPlanoCategoriaRepository _repository;
        public PlanoCategoriaService(IPlanoCategoriaRepository repository, IPlanoCategoriaReadOnlyRepository readOnlyRepository, IPlanoCategoriaReadOnlyRepository readOnlyRepository1)
            : base(repository, readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository1;
            _repository = repository;
        }


        public void UpdateDapper(PlanoCategoria planoCategoria)
        {
            //Acesso através do Dapper
            _readOnlyRepository.Update(planoCategoria);

        }


    }
}
