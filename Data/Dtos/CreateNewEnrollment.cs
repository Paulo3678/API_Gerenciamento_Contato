using System.ComponentModel.DataAnnotations;

namespace GerenciamentoContatos.Data.Dtos;

public class CreateNewEnrollment
{
    [Required(ErrorMessage = "É preciso informar seu nome.")]
    [StringLength(50)]
    public string Name { get; set; }
    [Required(ErrorMessage = "É preciso informar seu sobrenome informar.")]
    [StringLength(50)]
    public string LastName { get; set; }
    [Required(ErrorMessage = "É preciso informar seu cargo.")]
    [StringLength(150)]
    public string Responsibility { get; set; }
    [Required(ErrorMessage = "É preciso informar sua empresa.")]
    [StringLength(100)]
    public string Company { get; set; }
    [Required(ErrorMessage = "É preciso informar seu país.")]
    [StringLength(100)]
    public string Country { get; set; }
    [Required(ErrorMessage = "É preciso informar seu estado.")]
    [StringLength(100)]
    public string State { get; set; }
    [Required(ErrorMessage = "É preciso informar sua cidade")]
    [StringLength(100)]
    public string City { get; set; }
    [Required(ErrorMessage = "É preciso informar o código postal.")]
    [RegularExpression("/^[0-9]{5}-[0-9]{3}/", ErrorMessage = "É preiso informar um DDD válido 11111-111")]
    [StringLength(10)]
    public string PostalCode { get; set; }
    [Required(ErrorMessage = "É preciso informar um DDD.")]
    [StringLength(5)]
    public string DDD { get; set; }
    [Required(ErrorMessage = "É preciso informar seu número de telefone 98888-8888.")]
    [RegularExpression("/^[0-9]{5}-[0-9]{4}/", ErrorMessage = "Informe um número de telefone válido 98888-8888")]
    [StringLength(20)]
    public string Phone { get; set; }
    [Required(ErrorMessage = "É preciso informar seu e-mail")]
    [StringLength(100)]
    public string Email { get; set; }
    [Required(ErrorMessage = "É preciso informar a sua relação com a IBM")]
    [StringLength(100)]
    public string RelationshipWithIBM { get; set; }
    [Required(ErrorMessage = "É preciso dizer se deseja compartilhar seus dados.")]
    public bool ShareData { get; set; }
    [Required(ErrorMessage = "É preciso informar a forma de contato.")]
    [StringLength(50)]
    public string? ContactForm { get; set; }
}
