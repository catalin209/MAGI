using EShop.DBContext;
using EShop.Infrastructure;
using EShop.Model.User;
using EShop.Repository;
using EShop.Resolver;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitTests.Database.Fixtures;
using UnitTests.Database.Fixtures.UnitTests.Database.Fixtures;
using Xunit;

namespace UnitTests.Repositories
{
    public class GenericRepositoryTest : IClassFixture<EshopApiConfigurationFixture>
    {
        private readonly IGenericRepository<User, RoDbContext> _sut;
        public GenericRepositoryTest(EshopApiConfigurationFixture fixture)
        {
            var dbResolver = new DbContextResolver(new ServiceCollection()
                .AddEShop(fixture.Configuration)
                .BuildServiceProvider());

            _sut = new GenericRepository<User, RoDbContext>(dbResolver);
        }

        [Fact]
        public void CRUDTest()
        {
            //Create & Read
            var allUsers = _sut.GetAll();
            var user = _sut.Insert(new User("Test", "Test2", "123456678", "Bucharest", 1, "t.t@gmail.com", "password"));
            _sut.Save();
            Assert.NotNull(user);
            Assert.NotEqual(0, user.Id);

            //Update
            user.FirstName = "Update";
            _sut.Update(user);
            _sut.Save();
            Assert.Equal("Update", user.FirstName);

            //Delete
            _sut.Delete(user.Id);
            _sut.Save();
            Assert.Null(_sut.GetById(user.Id));
        }
    }
}