using Yelazo.BD.Data;
namespace Yelazo.Server.Repositorios
{
    public interface IRepositorio<E> where E : class, IEntityBase
    {
        Task<bool> Delete(int id);
        Task<bool> Existe(int id);
        //Task<bool> ExisteByNombre(string codigo);
        Task<int> Insert(E entidad);
        //Task<string?> InsertDevuelveCodigo(E entidad);
        Task<List<E>> Select();
        //Task<E?> SelectByNombre(string codigo);
        Task<E?> SelectById(int id);
        Task<bool> UpdateEntidad(int id, E entidad);
        //Task<bool> UpdateEstado(int id, E entidad);
    }
  
}
