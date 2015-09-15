using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Expressions;
using Dufry.Comissoes.Application.Interfaces;
using Dufry.Comissoes.Data.Context;
using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Interfaces.Service;
using Dufry.Comissoes.Domain.Validation;

namespace Dufry.Comissoes.Application
{
    public class PlanoCategoriaAppService : AppService<ComissoesContext>, IPlanoCategoriaAppService
    {
        private readonly IPlanoCategoriaService _service;

        public PlanoCategoriaAppService(IPlanoCategoriaService planocategoriaService)
        {
            _service = planocategoriaService;
        }

        public ValidationResult Create(PlanoCategoria planocategoria)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(planocategoria));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult CreateBatch(List<PlanoCategoria> planocategoriaList)
        {
            BeginTransaction();

            foreach (PlanoCategoria planocategoria in planocategoriaList)
            {
                ValidationResult.Add(_service.Add(planocategoria));                
            }

            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult DeleteBatch(List<PlanoCategoria> planocategoriaList)
        {
            BeginTransaction();

            foreach (PlanoCategoria planocategoria in planocategoriaList)
            {
                ValidationResult.Add(_service.Delete(planocategoria));
            }

            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult UpdateBatch(List<PlanoCategoria> planocategoriaListToInsert, List<PlanoCategoria> planocategoriaListToDelete)
        {
            List<PlanoCategoria> planocategoriaListToUpdate = new List<PlanoCategoria>();
            List<PlanoCategoria> planocategoriaListToRemove = new List<PlanoCategoria>();

            planocategoriaListToUpdate = (from pci in planocategoriaListToInsert
                                        join pcd in planocategoriaListToDelete
                                        on new { pci.ID_PLANO, pci.ID_CATEGORIA }
                                        equals new { pcd.ID_PLANO, pcd.ID_CATEGORIA }
                                        select pci).ToList();

            //<Corrigir>
            planocategoriaListToRemove = (from pcd in planocategoriaListToDelete
                                          join pcu in planocategoriaListToUpdate
                                          on new { pcd.ID_PLANO, pcd.ID_CATEGORIA }
                                          equals new { pcu.ID_PLANO, pcu.ID_CATEGORIA }
                                          select pcd).ToList();

            //planocategoriaListToUpdate = from planocategoriaListToInsert

            BeginTransaction();


            foreach (PlanoCategoria planocategoriaDel in planocategoriaListToDelete)
            {
                ValidationResult.Add(_service.Delete(planocategoriaDel));
            }

            foreach (PlanoCategoria planocategoriaIns in planocategoriaListToInsert)
            {
                ValidationResult.Add(_service.Add(planocategoriaIns));
            }

            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(PlanoCategoria planocategoria)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(planocategoria));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(PlanoCategoria planocategoria)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(planocategoria));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public PlanoCategoria Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<PlanoCategoria> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<PlanoCategoria> Find(Expression<Func<PlanoCategoria, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
