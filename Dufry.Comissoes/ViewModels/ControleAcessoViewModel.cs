using AutoMapper;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.ViewModels
{
    public class ControleAcessoViewModel
    {
        public string Name { get; set; }

        public static ControleAcessoViewModel ToViewModel(ControleAcesso controleacesso)
        {
            return Mapper.Map<ControleAcessoViewModel>(controleacesso);
        }
    }
}