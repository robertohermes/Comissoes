using System;
using System.Collections.Generic;
using AutoMapper;
using Dufry.Comissoes.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Dufry.Comissoes.ViewModels
{
    public class CategoriaPercentualViewModel
    {

        public IEnumerable<SelectListItem> CategoriasSelectListItem { get; set; }

        public IEnumerable<SelectListItem> LojasSelectListItem { get; set; }

        public CategoriaPercentual CategoriaPercentual { get; set; }

        public Loja Loja { get; set; }

        public CategoriaPercentualViewModel(CategoriaPercentual categoriaPercentual, Loja loja)
        {
            CategoriaPercentual = categoriaPercentual;
            Loja = loja;
        }

        public CategoriaPercentualViewModel(CategoriaPercentual categoriaPercentual, IEnumerable<SelectListItem> categoriaSelectListItem, IEnumerable<SelectListItem> lojaSelectListItem)
        {
            CategoriaPercentual = categoriaPercentual;
            CategoriasSelectListItem = categoriaSelectListItem;
            LojasSelectListItem = lojaSelectListItem;
        }

        //<REVER> - Ajustar, deletar o método "CategoriaPercentualViewModel" e acrescentar Loja quando o modelo do BI estiver pronto
        //public CategoriaPercentualViewModel ToViewModel(CategoriaPercentual categoriaPercentual)
        //{
        //    return Mapper.Map<CategoriaPercentualViewModel>(categoriaPercentual);
        //}
    }
}