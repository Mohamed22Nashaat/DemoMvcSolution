using Demo.BLL.DataTransferObjects;
using Demo.BLL.Factories;
using Demo.DAL.Models;
using Demo.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Services
{
    public class DepartmentServices(IDepartmentRepository _departmentRepository) : IDepartmentServices
    {
        // private readonly IDepartmentRepository _departmentRepository = departmentRepository;

        // Get All Departments
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _departmentRepository.GetAll();

            /// var departmentsToReturn = departments.Select(D => new DepartmentDto
            ///{
            ///    DeptId = D.Id,
            ///    Code = D.Code,
            ///    Description = D.Description,
            ///    Name = D.Name,
            ///    DateOfCreation = DateOnly.FromDateTime((DateTime)D.CreatedOn)
            ///});
            return departments.Select(D => D.ToDepartmentDto());
        }

        // Get Department By Id
        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department is null)
            {
                return null;
            }
            ///var departmentToReturn = new DepartmentDetailsDto
            ///{
            ///    Id = department.Id,
            ///    Name = department.Name,
            ///    Code = department.Code,
            ///    Description = department.Description,
            ///    CreatedBy = department.CreatedBy,
            ///    CreatedOn = DateOnly.FromDateTime((DateTime)department.CreatedOn),
            ///    LastModifiedBy = department.LastModifiedBy,
            ///    LastModifiedOn = DateOnly.FromDateTime((DateTime)department.LastModifiedOn),
            ///    IsDeleted = department.IsDeleted
            ///};
            ///return departmentToReturn;

            return department is null ? null : department.ToDepartmentDetailsDto();
            //Manual Mapping
            //AutoMapper
            //Constructor Mapping
            //Extension Method
        }

        // Add Department

        public int AddDepartment(CreatedDepartmentDto departmentDto)
        {
            var department = departmentDto.ToEntity();
            return _departmentRepository.Add(department);
        }

        //Update Department
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            // var department = departmentDto.ToEntity();
            return _departmentRepository.Update(departmentDto.ToEntity());
        }

        //Delete Department
        public bool DeleteDepartment(int id)
        {
            var Dept = _departmentRepository.GetById(id);
            if (Dept is null) return false;

            else
            {
                int result = _departmentRepository.Remove(Dept);
                return result > 0 ? true : false;
            }
        }

    }
}
