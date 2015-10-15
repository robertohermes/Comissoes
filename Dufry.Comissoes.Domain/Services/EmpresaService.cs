using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Repository;
using Dufry.Comissoes.Domain.Interfaces.Repository.ReadOnly;
using Dufry.Comissoes.Domain.Interfaces.Service;
using Dufry.Comissoes.Domain.Services.Common;
using System.Collections.Generic;

namespace Dufry.Comissoes.Domain.Services
{
    public class EmpresaService : Service<Empresa>, IEmpresaService
    {
        private readonly IEmpresaReadOnlyRepository _readOnlyRepository;
        private readonly IEmpresaRepository _repository;

        public EmpresaService(IEmpresaRepository repository, IEmpresaReadOnlyRepository readOnlyRepository, IEmpresaReadOnlyRepository readOnlyRepository1)
            : base(repository, readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository1;
            _repository = repository;
        }


        public IEnumerable<Empresa> AllConcatCodigoEmpresaLegado()
        {
            //Acesso através do Dapper
            return _readOnlyRepository.AllConcatCodigoEmpresaLegado();

        }


    }
}
