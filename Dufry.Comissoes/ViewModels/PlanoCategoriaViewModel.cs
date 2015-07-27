using System;
using AutoMapper;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.ViewModels
{
    public class PlanoCategoriaViewModel
    {
        public int ID_PLANO { get; set; }
        public int ID_CATEGORIA_PERCENTUAL { get; set; }
        public int ORDEM_HIERARQUIA { get; set; }
        public DateTime CREATED_DATETIME { get; set; }
        public string CREATED_USERNAME { get; set; }
        public DateTime LAST_MODIFY_DATE { get; set; }
        public string LAST_MODIFY_USERNAME { get; set; }

        public static PlanoCategoriaViewModel ToViewModel(PlanoCategoria planocategoria)
        {
            return Mapper.Map<PlanoCategoriaViewModel>(planocategoria);
        }
    }
}