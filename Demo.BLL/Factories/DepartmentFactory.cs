using Demo.BLL.DataTransferObjects;
using Demo.DAL.Models.DepartmentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Factories
{
    public static class DepartmentFactory
    {
        public static DepartmentDto ToDepartmentDto(this Department D)
        {
            return new DepartmentDto
            {
                DeptId = D.Id,
                Code = D.Code,
                Description = D.Description,
                Name = D.Name,
                DateOfCreation = DateOnly.FromDateTime((DateTime)D.CreatedOn)
            };
        }

        public static DepartmentDetailsDto ToDepartmentDetailsDto(this Department D)
        {
            return new DepartmentDetailsDto
            {
                Id = D.Id,
                Name = D.Name,
                Code = D.Code,
                Description = D.Description,
                CreatedBy = D.CreatedBy,
                CreatedOn = DateOnly.FromDateTime((DateTime)D.CreatedOn),
                LastModifiedBy = D.LastModifiedBy,
                LastModifiedOn = DateOnly.FromDateTime((DateTime)D.LastModifiedOn),
                IsDeleted = D.IsDeleted
            };
        }

        public static Department ToEntity(this CreatedDepartmentDto D)
        {
            return new Department
            {
                Name = D.Name,
                Code = D.Code,
                Description = D.Description,
                CreatedOn = D.DateOfCreation.ToDateTime(new TimeOnly()),


            };
        }

        public static Department ToEntity(this UpdatedDepartmentDto updatedDepartmentDto)
        {
            return new Department
            {
                Id = updatedDepartmentDto.Id,
                Name = updatedDepartmentDto.Name,
                Code = updatedDepartmentDto.Code,
                Description = updatedDepartmentDto.Description,
                CreatedOn = updatedDepartmentDto.DateOfCreation.ToDateTime(new TimeOnly())
            };
        }
    }
}
