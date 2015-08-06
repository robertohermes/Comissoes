using System;
using AutoMapper;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.ViewModels
{
    public class ColaboradorViewModel
    {
        public int Id_Colaborador { get; set; }
        public int Id_Loja { get; set; }
        public int Id_Cargo { get; set; }
        public string CodigoSecundario { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime? DataAdmissao { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Email { get; set; }
        public string Genero { get; set; }
        public decimal? Comissao { get; set; }


        public ColaboradorViewModel ToViewModel(Colaborador Colaborador)
        {
            return Mapper.Map<ColaboradorViewModel>(Colaborador);
        }
    }
}