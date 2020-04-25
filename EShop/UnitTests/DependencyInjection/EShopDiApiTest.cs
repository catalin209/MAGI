using EShop.Infrastructure;
using EShop.Resolver;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTests.Database.Fixtures;
using UnitTests.Database.Fixtures.UnitTests.Database.Fixtures;
using Xunit;

namespace UnitTests.DependencyInjection
{
    public class EshopApiDiTest : IClassFixture<EshopApiConfigurationFixture>
    {
        private readonly IServiceCollection _sut;
        private readonly EshopApiConfigurationFixture _fixture;

        public EshopApiDiTest(EshopApiConfigurationFixture fixture)
        {
            _fixture = fixture;
            _sut = new ServiceCollection();

        }

        [Fact]
        public void DiResolver()
        {
            var sp = _sut.AddEShop(_fixture.Configuration).BuildServiceProvider();

            Assert.IsType<DbContextResolver>(sp.GetService<IDbContextResolver>());
            Assert.IsType<RepositoryResolver>(sp.GetService<IRepositoryResolver>());
        }
    }
}