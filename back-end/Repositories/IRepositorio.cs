using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back_end.Controllers.Entities;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Repositories
{
    public interface IRepository
    {
        Task<ActionResult<List<Genre>>> AllGenres();
    }
}