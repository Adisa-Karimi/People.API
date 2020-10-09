using People.Domain.DTOs;
using People.Domain.Models;
using System.Collections.Generic;

namespace People.Test
{
    public class MockData
    {
        public static MockData Current { get; } = new MockData();
        public List<Student> Students { get; set; }

        public MockData()
        {
            Students = new List<Student>()
            {
                new Student() { Id = 1,
                    Name = "Ahmad", Family = "Asadi", Age = 25 },
                new Student() { Id = 2,
                     Name = "Sara", Family = "Ahmadi", Age = 20 },
                new Student() { Id = 3,
                     Name = "Farid", Family = "Naderi", Age = 33 }
            };
        }
    }
}
