using System.ComponentModel.DataAnnotations;

namespace Abstracciones.Modelos
{
    public class VehiculoBase
    {
        [Required(ErrorMessage = "La propiedad placa es debida")]
        [RegularExpression(@"[A-Z]{3}-[0-9]{3}", ErrorMessage = "El formato de la placa debe de ser ###-ABC")]
        public string Placa { get; set; }
        [Required(ErrorMessage = "La propiedad color es debida")]
        [StringLength(40,
            ErrorMessage = "La propiedad color debe de ser mayor a 4 caractares y menor a 40",
            MinimumLength = 4)]
        public string Color { get; set; }
        [Required(ErrorMessage = "La propiedad año es debida")]
        [RegularExpression(@"19|20)\d\d", ErrorMessage = "El formato del año no es valido")]
        public int Anio { get; set; }
        [Required(ErrorMessage = "La propiedad precio es debida")]
        public Decimal Precio { get; set; }
        [Required(ErrorMessage = "La propiedad correo del propietario es debida")]
        [EmailAddress]
        public string CorreoPropietario { get; set; }
        [Required(ErrorMessage = "La propiedad teléfono del propietario es debida")]
        [Phone]
        public string TelefonoPropietario { get; set; }
    }
    public class VehiculoRequest : VehiculoBase
    {
        public Guid IdModelo { get; set; }
    }
    public class VehiculoResponse : VehiculoBase
    {
        public Guid Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
    }
    public class VehiculoDetalle : VehiculoResponse
    {
        public bool RevisionValida { get; set; }
        public bool RegistroValido { get; set; }
    }
}
