using AutoMapper;
using Yelazo.BD.Data.Entity;
using Yelazo.Shared.DTO;

namespace Yelazo.Server.Util
{
    public class AutoMapperProfile : Profile
    {

            public AutoMapperProfile()
            {
                CreateMap<Producto, CrearProductoDTO>().ReverseMap();
                CreateMap<Producto, EditarProductoDTO>().ReverseMap();
                CreateMap<Rol, CrearRolDTO>().ReverseMap();
                CreateMap<CategoriaInsumo, CrearCategoriaInsumosDTO>().ReverseMap();

            }

    }
}
