namespace AkkaApi.Messages
{
    public class Persona
    {
        private string nombre { get; set; }

        public Persona(string _nombre) { 

            nombre = _nombre;
        }

        public void AgregarApellido(string apellido)
        {
            nombre = nombre + " " + apellido;
        }

        public string getNombre()
        {
            return nombre;
        }
    }
}
