namespace UnitTests.Database.Fixtures
{
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using Xunit;

    /// <summary>
    /// Test fixture base class that isolates the creation of a <see cref="Microsoft.Extensions.Configuration.IConfiguration" />.
    /// </summary>
    [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
    public abstract class AbstractConfigurationFixture : IDisposable
    {
        protected AbstractConfigurationFixture()
        {
            var path = $"{Directory.GetCurrentDirectory()}/{RelativeFolderPath}";
            Assert.True(Directory.Exists(path));
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile(AppSettingsJsonFileName, optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }

        protected abstract string AppSettingsJsonFileName { get; }
        protected abstract string RelativeFolderPath { get; }

        internal IConfiguration Configuration { get; }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // ... clean up test data from the database ...
                (Configuration as IDisposable)?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}