using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mf_dev_backend_2025.Models
{
    [Table("Veiculos")]
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Nome Obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Placa Obrigatoria")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "Ano de Fabricacao Obrigatorio")]
        public int AnoFabricacao { get; set; }

        [Required(ErrorMessage = "Ano do Modelo Obrigatorio")]
        public int AnoModelo { get; set; }
    }
}
