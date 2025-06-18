namespace AcademicStaffContext.AcademicStaff.Domain.Model.ValueObjects
{
    public class AcademicDegree
    {
        public string Value { get; private set; }

        private static readonly HashSet<string> AllowedDegrees = new(StringComparer.OrdinalIgnoreCase)
        {
            "Licenciatura", "Maestría", "Doctorado"
        };

        // Constructor sin parámetros para EF Core
        protected AcademicDegree() { }

        public AcademicDegree(string value)
        {
            var trimmedValue = value?.Trim();

            if (string.IsNullOrWhiteSpace(trimmedValue) || !AllowedDegrees.Contains(trimmedValue))
                throw new ArgumentException("Grado académico inválido.");

            Value = trimmedValue;
        }

        public override bool Equals(object? obj) => Equals(obj as AcademicDegree);

        public bool Equals(AcademicDegree? other) => other != null && Value == other.Value;

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value;

        public static IEnumerable<string> GetAllowedDegrees() => AllowedDegrees;
    }
}
