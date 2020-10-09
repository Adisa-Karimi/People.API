using AutoMapper;
using People.Domain.DTOs;
using People.Domain.Models;

namespace People.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
        }

    }
}
