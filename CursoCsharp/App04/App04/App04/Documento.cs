namespace App04
{
    public class Documento : IOperaciones, IMensajeria
    {
        private string nombre;


        public Documento(string s)
        {
            nombre = s;
        }


        public void Guardar()
        {
            Console.WriteLine("Este metodo es para guardar el documento");
        }

        public void Cargar()
        {
            Console.WriteLine("Este metodo es para cargar el documento");
        }

        public bool NecesitaGuardar()
        {
            return false;
        }

        public void EnviarEmail()
        {
            Console.WriteLine("Enviar correo electronico por gmail");
        }

        public void EnviarMensajeTexto()
        {
            Console.WriteLine("Enviar mensaje de texto");
        }

        public void EnviarNotification()
        {
            Console.WriteLine("Enviar Notificacion por Login");
        }
    }
}
