using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back_end.Controllers.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_end.Repositories
{
    public class Repository : IRepository
    {
        private ApplicationDbContext context;

        public Repository(ApplicationDbContext _context) {
            this.context = _context;
        }
        public async Task<ActionResult<List<Genre>>> AllGenres()
        {
            return await context.Genres.ToListAsync();
        }
    }
}