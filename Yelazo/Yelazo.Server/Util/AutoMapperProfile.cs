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
                CreateMap<Gasto, CrearGastoDTO>().ReverseMap();
                CreateMap<Rol, CrearRolDTO>().ReverseMap();
                CreateMap<Insumo, CrearInsumosDTO>().ReverseMap();
                CreateMap<MetodoPago, CrearMetodoPagoDTO>().ReverseMap();
                CreateMap<Mantenimiento, CrearMantenimientoDTO>().ReverseMap();
                CreateMap<TipoGasto, CrearTipoGastoDTO>().ReverseMap();
                CreateMap<Proveedor, CrearProveedorDTO>().ReverseMap();
            }
    }
}
