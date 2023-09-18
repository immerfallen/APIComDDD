using System.ComponentModel.DataAnnotations;

namespace Api.Domain.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage ="Email é um campo obrigatório para Login")]
        [EmailAddress(ErrorMessage ="Email informado inválido")]
        [StringLength(100, ErrorMessage ="Email deve ter no máximo {1} caracteres")]
        public string Email { get; set; }
    }
}
