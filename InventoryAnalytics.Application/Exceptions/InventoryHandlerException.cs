

namespace InventoryAnalytics.Application.Exceptions
{
    public class InventoryHandlerException : Exception
    {
        public InventoryHandlerException(string message) : base( message)
        {
            LogError(message);
            NotifyAdmin(message);
        }
        private void LogError(string message)
        {
            // Aquí podrías implementar la lógica para registrar el error en un archivo de log, base de datos, etc.
            Console.WriteLine($"Error: {message}");
        }
        private void NotifyAdmin(string message)
        {
            // Aquí podrías implementar la lógica para notificar al administrador, por ejemplo, enviando un correo electrónico.
            Console.WriteLine($"Notificación al administrador: {message}");
        }
    }
}
