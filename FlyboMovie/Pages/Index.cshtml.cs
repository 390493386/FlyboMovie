using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlyboMovie.Data;
using FlyboMovie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlyboMovie.Pages
{
    public class IndexModel : PageModel
    {
        AppDbContext _dbContext;

        public IList<Movie> Movies { get; set; }

        public IndexModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            Movies = _dbContext.Movies
                .Where(m => !m.IsInactive)
                .OrderBy(m => m.RecordCreatedTime)
                .ToList();
        }
    }
}
