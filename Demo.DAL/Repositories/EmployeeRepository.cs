using Demo.DAL.Data.Contexts;
using Demo.DAL.Models.EmployeeModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Repositories
{
    public class EmployeeRepository(ApplicationDbContext dbContext) : GenericRepository<Employee>(dbContext), IEmployeeRepository
    {
        

    }
}
