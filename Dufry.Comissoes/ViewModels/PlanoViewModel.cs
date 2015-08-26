using System.Collections.Generic;
using Dufry.Comissoes.Domain.Entities;
using System.Web.Mvc;


namespace Dufry.Comissoes.ViewModels
{
    public class PlanoViewModel
    {
        public Plano Plano { get; set; }

        public Categoria Categoria { get; set; }

        public CategoriaPercentual CategoriaPercentual { get; set; }

        public PlanoCategoria PlanoCategoria { get; set; }

        public IEnumerable<SelectListItem> CategoriasSelectListItem { get; set; }

        public IEnumerable<SelectListItem> LojasSelectListItem { get; set; }

        public PlanoViewModel(Plano plano, IEnumerable<SelectListItem> categoriaSelectListItem, IEnumerable<SelectListItem> lojaSelectListItem)
        {
            Plano = plano;
            CategoriasSelectListItem = categoriaSelectListItem;
            LojasSelectListItem = lojaSelectListItem;
        }

        public PlanoViewModel(Plano plano)
        {
            Plano = plano;
        }

        //public PlanoViewModel(Plano plano, Categoria categoria, CategoriaPercentual categoriaPercentual)
        //{
        //    Plano = plano;
        //    Categoria = categoria;
        //    CategoriaPercentual = categoriaPercentual;
        //}
    }
}