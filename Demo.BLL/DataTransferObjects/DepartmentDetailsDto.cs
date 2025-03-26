using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.DataTransferObjects
{
    public class DepartmentDetailsDto
    {
        //Constructor-Based Mapping
        ///public DepartmentDetailsDto(Department department) 
        ///{
        ///    Id = department.Id;
        ///    Name = department.Name;
        ///    Code = department.Code;
        ///    Description = department.Description;
        ///    CreatedBy = department.CreatedBy;
        ///    CreatedOn = DateOnly.FromDateTime((DateTime)department.CreatedOn);
        ///    LastModifiedBy = department.LastModifiedBy;
        ///    LastModifiedOn = DateOnly.FromDateTime((DateTime)department.LastModifiedOn);
        ///    IsDeleted = department.IsDeleted;
        ///}
        public int Id { get; set; }  //Pk
        public int CreatedBy { get; set; }  //User Id
        public DateOnly CreatedOn { get; set; }
        public int LastModifiedBy { get; set; }  //User Id
        public DateOnly LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; } //Soft Delete
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
