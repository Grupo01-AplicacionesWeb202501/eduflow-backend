namespace AcademicStaff.Domain.Model.ValueObjects
{
    public class Email
    {
        public string Value { get; private set; }

        public Email(string value)
        {
            if (!IsValidEmail(value)) throw new ArgumentException("Email inválido");
            Value = value;
        }

        private bool IsValidEmail(string email)
        {
            // lógica básica o regex
            return email.Contains("@");
        }

        public override string ToString() => Value;
    }
}
