public class Department
{
    // Identificador único generado automáticamente
    public Guid Id { get; private set; } = Guid.NewGuid();

    // Propiedades con set privado para mantener encapsulamiento
    public string NameDepartment { get; private set; }
    public string DescriptionDepartment { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }

    // Constructor sin parámetros requerido por EF Core
    protected Department() { }

    // Constructor de dominio
    public Department(string name, string description, string email, string phoneNumber)
    {
        Validate(name, description, email, phoneNumber);

        NameDepartment = name;
        DescriptionDepartment = description;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    // Método de modificación
    public void Update(string name, string description, string email, string phoneNumber)
    {
        Validate(name, description, email, phoneNumber);

        NameDepartment = name;
        DescriptionDepartment = description;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    // Validación reutilizable
    private void Validate(string name, string description, string email, string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is required.", nameof(name));
        if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Description is required.", nameof(description));
        if (string.IsNullOrWhiteSpace(email) || !email.Contains("@")) throw new ArgumentException("Invalid email.", nameof(email));
        if (string.IsNullOrWhiteSpace(phoneNumber)) throw new ArgumentException("Phone number is required.", nameof(phoneNumber));
    }
}
