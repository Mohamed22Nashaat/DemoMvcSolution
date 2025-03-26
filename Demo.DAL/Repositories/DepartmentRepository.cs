using Demo.DAL.Data.Contexts;
using Demo.DAL.Models.DepartmentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Repositories
{
    // Primary Constructor .Net 8 C#12
    public class DepartmentRepository(ApplicationDbContext dbContext) : GenericRepository<Department>(dbContext),IDepartmentRepository
    {


      
    }
}
