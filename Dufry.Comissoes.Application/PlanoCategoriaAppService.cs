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

        public ValidationResult UpdateBatch(List<PlanoCategoria> planoCategoriaListNovos, List<PlanoCategoria> planoCategoriaListAtuais)
        {
            List<PlanoCategoria> planocategoriaListToUpdate = new List<PlanoCategoria>();
            List<PlanoCategoria> planocategoriaListToDelete = new List<PlanoCategoria>();
            List<PlanoCategoria> planocategoriaListToinsert = new List<PlanoCategoria>();

            planocategoriaListToUpdate = (from pci in planoCategoriaListNovos
                                        join pca in planoCategoriaListAtuais
                                        on new { pci.ID_PLANO, pci.ID_CATEGORIA }
                                        equals new { pca.ID_PLANO, pca.ID_CATEGORIA }
                                        select pci).ToList();

            planocategoriaListToDelete = (from pca in planoCategoriaListAtuais
                                          where !planocategoriaListToUpdate.Any(pcu => pcu.ID_PLANO == pca.ID_PLANO && pcu.ID_CATEGORIA == pca.ID_CATEGORIA)
                                        select pca).ToList();

            planocategoriaListToinsert = (from pcn in planoCategoriaListNovos
                                          where !planocategoriaListToUpdate.Any(pcu => pcu.ID_PLANO == pcn.ID_PLANO && pcu.ID_CATEGORIA == pcn.ID_CATEGORIA)
                                          select pcn).ToList();

            //BeginTransaction();


            foreach (PlanoCategoria planocategoriaUpd in planocategoriaListToUpdate)
            {
                PlanoCategoria updAux = _service.Find(t => t.ID_PLANO == planocategoriaUpd.ID_PLANO
                                                        && t.ID_CATEGORIA == planocategoriaUpd.ID_CATEGORIA).FirstOrDefault();

                planocategoriaUpd.ID_PLANO_CATEGORIA = updAux.ID_PLANO_CATEGORIA;

                _service.UpdateDapper(planocategoriaUpd);

            }

            //foreach (PlanoCategoria planocategoriaUpd in planocategoriaListToUpdate)
            //{

            //    PlanoCategoria updAux = _service.Find(t => t.ID_PLANO == planocategoriaUpd.ID_PLANO
            //                                            && t.ID_CATEGORIA == planocategoriaUpd.ID_CATEGORIA).FirstOrDefault();

            //    updAux.ORDEM_HIERARQUIA = planocategoriaUpd.ORDEM_HIERARQUIA;
            //    updAux.CREATED_DATETIME = planocategoriaUpd.CREATED_DATETIME;
            //    updAux.CREATED_USERNAME = planocategoriaUpd.CREATED_USERNAME;
            //    updAux.LAST_MODIFY_DATE = planocategoriaUpd.LAST_MODIFY_DATE;
            //    updAux.LAST_MODIFY_USERNAME = planocategoriaUpd.LAST_MODIFY_USERNAME;

            //    ValidationResult.Add(_service.Update(updAux));
                
            //}

            //foreach (PlanoCategoria planocategoriaIns in planoCategoriaListNovos)
            //{
            //    ValidationResult.Add(_service.Add(planocategoriaIns));
            //}

            //foreach (PlanoCategoria planocategoriaDel in planocategoriaListToDelete)
            //{
            //    ValidationResult.Add(_service.Delete(planocategoriaDel));
            //}

            //if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public void UpdateHierarquia(List<PlanoCategoria> planoCategoriaListNovos, List<PlanoCategoria> planoCategoriaListAtuais)
        {
            foreach (PlanoCategoria planocategoriaIns in planoCategoriaListNovos)
            {
                //ValidationResult.Add(_service.UpdateDapper(planocategoriaIns));
                _service.UpdateDapper(planocategoriaIns);
            }
            
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
