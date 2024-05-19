using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteCandidatoWEB.Models
{
    public class CEP
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Cep")]
        [StringLength(8)]
        public string? NumeroCep { get; set; }

        [StringLength(500)]
        public string? Logradouro { get; set; }

        [StringLength(500)]
        public string? Complemento { get; set; }

        [StringLength(500)]
        public string? Bairro { get; set; }

        [StringLength(500)]
        public string? Localidade { get; set; }

        [StringLength(2)]
        public string? Uf { get; set; }
        public long? Unidade { get; set; }
        public int? Ibge { get; set; }

        [StringLength(500)]
        public string? Gia { get; set; }
    }
}
