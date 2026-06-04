using BibliotecaAPI.Entidades;

namespace BibliotecaAPI.Interfaces
{
    public interface IRepositorioValores
    {
        void InsertarValor(Valor valor);
        IEnumerable<Valor> ObtenerValores();
    }
}
