namespace AteneaMobile.Models
{
    public enum MenuItemType
    {
        ConsultarPaciente,
        ConsultarEmpleado,
        Configuracion,
        Salir
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
