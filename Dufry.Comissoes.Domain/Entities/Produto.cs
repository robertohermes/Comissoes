using System;
using System.ComponentModel.DataAnnotations;


namespace Dufry.Comissoes.Domain.Entities
{
    public partial class Produto
    {
        public int Id_Produto { get; set; }
        public int Id_ProdutoTipo { get; set; }
        public int Id_ProdutoSubGrupoDufry { get; set; }
        public int Id_TipoBusiness { get; set; }
        [Display(Name = "Item")]
        [Required(ErrorMessage = "O Item é obrigatório")]
        public string CodigoProdutoAlternate { get; set; }
        [Display(Name = "Item")]
        public string DescricaoProdutoNome { get; set; }
        public string DescricaoProdutoNomeIngles { get; set; }
        public string Cor { get; set; }
        public string NCM { get; set; }
        public string Nacional { get; set; }
        public string MarcaLocal { get; set; }
        public string LinhaLocal { get; set; }
        public string MarcaGlobal { get; set; }
        public string LinhaGlobal { get; set; }
        public string Tamanho { get; set; }
        public decimal? Peso { get; set; }
        public string Modelo { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }

    }
}
