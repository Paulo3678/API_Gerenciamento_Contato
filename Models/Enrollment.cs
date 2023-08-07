namespace GerenciamentoContatos.Models;

public class Enrollment
{
    public Guid Id { get; set; }
    public string? Observation { get; set; }
    public DateTime EnrollmentCreationDate { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Responsibility { get; set; }
    public string Company { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string DDD { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string RelationshipWithIBM { get; set; }
    public bool ShareData { get; set; }
    public string? ContactForm { get; set; }
    public bool EnrollmentApproved { get; set; }

}
