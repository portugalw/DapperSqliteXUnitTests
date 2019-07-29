using Moq;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDapper;
using Xunit;

namespace XUnitTestDapper
{
    public class UnitTest1
    {
        Mock<IDatabaseConnectionFactory> connectionFactoryMock = new Mock<IDatabaseConnectionFactory>();

        [Fact]
        public async Task QueryTest()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Id = 0 },
                new Product { Id = 1 }
            };
            var db = new InMemoryDatabase();
            db.Insert(products);
            connectionFactoryMock.Setup(c => c.GetConnection()).Returns(db.OpenConnection());

            // Act
            var result = await new ProductRepository(connectionFactoryMock.Object).GetAll(new { id = 1 });

            // Assert
            Assert.Equal(result.Count(),products.Count());
        }
    }
}
