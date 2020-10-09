using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using People.API;
using People.API.Controllers;
using People.DataAccess;
using People.Domain.DTOs;
using People.Domain.Models;
using People.Provider;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace People.Test
{
    public class HomeControllerTest 
    {
        readonly HomeController _controller;
        private readonly Mock<IGenericEfRepository<Student>> _mockRepo;
        readonly IMapper mapper;
        public HomeControllerTest()
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            mapper = mappingConfig.CreateMapper();

            _mockRepo = new Mock<IGenericEfRepository<Student>>();

            IMyProvider provider = new MyProvider(_mockRepo.Object, mapper);

            _controller = new HomeController(provider);

            _mockRepo.Setup(m => m.Get())
                .Returns(Task.FromResult(MockData.Current.Students.AsEnumerable()));
        }

        [Fact]
        public async Task Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = await _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public async Task Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = await _controller.Get() as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<StudentDto>>(okResult?.Value);
            Assert.Equal(3, items.Count);
        }
    }
}
