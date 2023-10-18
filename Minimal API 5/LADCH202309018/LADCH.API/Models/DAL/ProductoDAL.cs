using LADCH.API.Models.EN;
using Microsoft.EntityFrameworkCore;

namespace LADCH.API.Models.DAL
{
    public class ProductoDAL
    {
        readonly LADCHContext context;

        public ProductoDAL(LADCHContext LADCHcontext)
        {
            context = LADCHcontext;
        }

        public async Task<int> Create(Producto xProducto)
        {
            context.Add(xProducto);
            return await context.SaveChangesAsync();
        }

        public async Task<Producto> GetById(int id)
        {
            var xProducto = await context.productos.FirstOrDefaultAsync(p => p.Id == id);
            return xProducto != null ? xProducto : new Producto();
        }

        public async Task<int> Edit(Producto xProducto)
        {
            int result = 0;
            var xProductoUpdate = await GetById(xProducto.Id);
            if (xProductoUpdate.Id != 0)
            {
                xProductoUpdate.Nombre = xProducto.Nombre;
                xProductoUpdate.Descripcion = xProducto.Descripcion;
                xProductoUpdate.Stock = xProducto.Stock;
                xProductoUpdate.Precio = xProducto.Precio;
                xProductoUpdate.FechaLanzamiento = xProducto.FechaLanzamiento;
            }
            return result;
        }

        public async Task<int> Delete(int id)
        {
            int result = 0;
            var xProductoDelete = await GetById(id);
            if (xProductoDelete.Id > 0)
            {
                context.productos.Remove(xProductoDelete);
                return await context .SaveChangesAsync();
            }
            return result;
        }

        public IQueryable<Producto> Query(Producto xProducto)
        {
            var query = context.productos.AsQueryable();
            if (!string.IsNullOrWhiteSpace(xProducto.Nombre))
                query = query.Where(s => s.Nombre.Contains(xProducto.Nombre));

            return query;
        }

        public async Task<int> CountSearch(Producto xProducto)
        {
            return await Query(xProducto).CountAsync();
        }

        public async Task<List<Producto>> Search(Producto xProducto, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = Query(xProducto);
            query  = query.OrderByDescending(p => p.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
    }
}
