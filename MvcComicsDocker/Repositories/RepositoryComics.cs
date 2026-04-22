using Microsoft.EntityFrameworkCore;
using MvcComicsDocker.Data;
using MvcComicsDocker.Models;

namespace MvcComicsDocker.Repositories
{
    public class RepositoryComics
    {
        private ComicsContext context;

        public RepositoryComics(ComicsContext context)
        {
            this.context = context;
        }

        public async Task<List<Comic>> GetComicsAsync()
        {
            return await context.Comics.ToListAsync();
        }

        public async Task<int> GetMaxIdComicAsync()
        {
            return await context.Comics.MaxAsync(z => z.IdComic) + 1;
        }

        public async Task CreateComicAsync(string nombre, string imagen)
        {
            int idComic = await GetMaxIdComicAsync();

            Comic comic = new Comic
            {
                IdComic = idComic,
                Nombre = nombre,
                Imagen = imagen
            };

            await context.AddAsync(comic);
            await context.SaveChangesAsync();
        }
    }
}
