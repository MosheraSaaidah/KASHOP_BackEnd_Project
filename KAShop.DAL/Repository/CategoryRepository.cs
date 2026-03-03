using KAShop.DAL.Data;
using KAShop.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAShop.DAL.Repository
{
    public class CategoryRepository : GenericRepositry<Category> , ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

    }

}
