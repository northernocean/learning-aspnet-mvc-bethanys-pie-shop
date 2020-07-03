using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext dbContext;

        public PieRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Pie> AllPies 
        {
            get 
            {
                return dbContext.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek 
        {
            get 
            {
                return dbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public IEnumerable<Category> AllCategories
        {
            get
            {
                return dbContext.Categories;
            }
        }
        

        public Pie GetPieById(int pieId)
        {
            return dbContext.Pies.SingleOrDefault(p => p.PieId == pieId);
        }
    }
}
