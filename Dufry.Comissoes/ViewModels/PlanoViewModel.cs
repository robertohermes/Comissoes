using System;
using AutoMapper;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.ViewModels
{
    public class PlanoViewModel
    {
        public Plano Plano { get; set; }

        public PlanoViewModel(Plano plano)
        {
            Plano = plano;
        }
    }
}