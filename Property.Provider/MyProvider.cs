using AutoMapper;
using People.DataAccess;
using People.Domain.DTOs;
using People.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace People.Provider
{
    public class MyProvider : IMyProvider
    {
        readonly IGenericEfRepository<Student> _rep;
        private readonly IMapper _mapper;
        public MyProvider(IGenericEfRepository<Student> rep, IMapper mapper)
        {
            _rep = rep;
            _mapper = mapper;
        }
        public StudentDto AddStudent(StudentDto student)
        {
            try
            {
                var itemToCreate = _mapper.Map<Student>(student);
                _rep.Add(itemToCreate);
                _rep.Save();
                var createdDto = _mapper.Map<StudentDto>(itemToCreate);
                return createdDto;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudents()
        {
            try
            {
                var item = await _rep.Get();
                var dtOs = _mapper.Map<IEnumerable<StudentDto>>(item);
                return dtOs;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
