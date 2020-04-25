using EShop.DBContext;
using EShop.Infrastructure;
using EShop.Resolver;
using Microsoft.Extensions.DependencyInjection;
using System;
using UnitTests.Database.Fixtures.UnitTests.Database.Fixtures;
using Xunit;

namespace UnitTests.Resolvers
{

    namespace UnitTests.Resolvers
    {
        public class ContextResolverTests : IClassFixture<EshopApiConfigurationFixture>
        {
            private readonly IDbContextResolver _sut;

            public ContextResolverTests(EshopApiConfigurationFixture fixture)
            {
                _sut = new DbContextResolver(
                    new ServiceCollection()
                    .AddEShop(fixture.Configuration)
                    .BuildServiceProvider());
            }

            [Theory]
            [InlineData(typeof(RoDbContext))]
            [InlineData(typeof(BgDbContext))]
            [InlineData(typeof(SrDbContext))]
            [InlineData(typeof(UkDbContext))]
            public void Pass(Type type)
            {
                var result = _sut.Resolve(type);
                Assert.Contains(result.GetType(), ContextTypes);
            }


            [Theory]
            [InlineData(typeof(DbContextExtension))]
            [InlineData(null)]
            public void Failed(Type type) =>
                Assert.Throws<NotImplementedException>(() => _sut.Resolve(type));

            private Type[] ContextTypes = new Type[]
            {
            typeof(RoDbContext),
            typeof(BgDbContext),
            typeof(SrDbContext),
            typeof(UkDbContext),
            };
        }
    }
}