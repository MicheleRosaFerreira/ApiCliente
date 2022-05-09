using System.ComponentModel.DataAnnotations;

namespace ApiCliente.Models
{
    public class ClienteModels
    {

       [Required(ErrorMessage = "Campo obrigatorio ")] public string? nome { get; set; }
       [Required(ErrorMessage = "Campo obrigatorio ")] public string? sobrenome { get; set; }
       [Required(ErrorMessage="Campo obrigatorio ")] public string? cpf { get; set; }
        DateTime dataNascimento { get; set; }

    }
}