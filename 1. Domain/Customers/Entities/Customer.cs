using CommerX.Domain.Common.Entities;
using CommerX.Domain.Customers.ValueObjects;

namespace CommerX.Domain.Customers.Entities;

// Customer es una entidad: tiene Id y ciclo de vida usa sealed class
public sealed class Customer : BaseEntity
{
    // propiedades tipadas con Value Objects ya no son strings primitivos
    public FullName FullName { get; private set; } = null!;
    public LastName LastName { get; private set; } = null!;
    public Document Document { get; private set; } = null!;
    public EmailAddress Email { get; private set; } = null!;
    public Phone Phone { get; private set; } = null!;
    public Address Address { get; private set; } = null!;
    public BirthDate BirthDate { get; private set; } = null!;

    // constructor privado vacío requerido por EF Core para materialización
    private Customer() { }

    // método estático de fábrica única puerta de entrada
    public static Customer Create(
        string fullName,
        string lastName,
        string document,
        string email,
        string phone,
        string address,
        DateOnly birthDate)
    {
        // cada Create() valida y normaliza su propio dato
        // Customer no repite ninguna validación de formato
        return new Customer
        {
            FullName = FullName.Create(fullName),
            LastName = LastName.Create(lastName),
            Document = Document.Create(document),
            Email = EmailAddress.Create(email),
            Phone = Phone.Create(phone),
            Address = Address.Create(address),
            BirthDate = BirthDate.Create(birthDate)
        };
    }

    // método de dominio: reemplaza el email
    public void UpdateEmail(string newEmail)
    => Email = EmailAddress.Create(newEmail);

    public void UpdateAddress(string address) // <-- Solo recibe un string
        => Address = Address.Create(address); // <-- Pasa un solo argumento
}
