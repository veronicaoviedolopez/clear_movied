using System.Linq;
using back_end.DTOs;

namespace  back_end.Utilities
{
    public static class QuerableExtensions
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable, PaginacionDTO paginacionDTO) { 
            return queryable
            .Skip((paginacionDTO.Pagina-1) * paginacionDTO.RecordsPorPagina)
            .Take(paginacionDTO.RecordsPorPagina);
        }
    }
}