using EShop.DBContext;
using EShop.Infrastructure;
using EShop.Model.User;
using EShop.Repository;
using EShop.Resolver;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTests.Database.Fixtures;
using UnitTests.Database.Fixtures.UnitTests.Database.Fixtures;
using Xunit;

namespace UnitTests.Resolvers
{
    public class RepositoryResolverTests : IClassFixture<EshopApiConfigurationFixture>
    {
        private readonly IRepositoryResolver _sut;

        public RepositoryResolverTests(EshopApiConfigurationFixture fixture)
        {
            _sut = new RepositoryResolver(
                new ServiceCollection()
                .AddEShop(fixture.Configuration)
                .BuildServiceProvider());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void Pass(int typeId) =>
            Assert.Contains(_sut.Resolve<User>(typeId).GetType(), RepoTypes);

        public Type[] RepoTypes = new Type[]
        {
            typeof(GenericRepository<User, RoDbContext>),
            typeof(GenericRepository<User, BgDbContext>),
            typeof(GenericRepository<User, SrDbContext>),
            typeof(GenericRepository<User, UkDbContext>),
        };
    }
}