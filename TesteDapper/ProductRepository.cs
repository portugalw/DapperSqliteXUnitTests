using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace TesteDapper
{
    public class ProductRepository
    {
        private readonly IDatabaseConnectionFactory connectionFactory;

        public ProductRepository(IDatabaseConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public Task<IEnumerable<Product>> GetAll(object param)
        {
            return this.connectionFactory.GetConnection().QueryAsync<Product>(
                "select * from Product where Id = @id", param);
        }
    }
}
