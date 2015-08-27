using Dufry.Comissoes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
//using AutoMapper;

namespace Dufry.Comissoes.ViewModels
{
    public class DSRViewModel
    {
        public DSR Dsr { get; set; }

        public Loja Loja { get; set; }

        public IEnumerable<SelectListItem> LojasSelectListItem { get; set; }

        public DSRViewModel(DSR dsr, Loja loja)
        {
            Dsr = dsr;
            Loja = loja;
        }

        public DSRViewModel(DSR dsr, IEnumerable<SelectListItem> lojaSelectListItem)
        {
            Dsr = dsr;
            LojasSelectListItem = lojaSelectListItem;
        }

        //<REVER>
        //public DSRViewModel ToViewModel(DSR dsr)
        //{
        //    return Mapper.Map<DSRViewModel>(dsr);
        //}
    }
}