using Dapper;
using Dapper_dz6_Products.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_dz6_Products.Repositories
{
    class ProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Add(ProductEntity product)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = @"
            INSERT INTO Products (Name, Description, Price, CreatedAt)
            VALUES (@Name, @Description, @Price, @CreatedAt);
            SELECT CAST(SCOPE_IDENTITY() AS INT);";
            return connection.QuerySingle<int>(sql, product);
        }

        public ProductEntity GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = "SELECT * FROM Products WHERE Id = @Id;";
            return connection.QueryFirstOrDefault<ProductEntity>(sql, new { Id = id });
        }

        public List<ProductEntity> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = "SELECT * FROM Products;";
            return connection.Query<ProductEntity>(sql).ToList();
        }

        public void Update(ProductEntity product)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = @"
            UPDATE Products 
            SET Name = @Name, Description = @Description, Price = @Price 
            WHERE Id = @Id;";
            connection.Execute(sql, product);
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = "DELETE FROM Products WHERE Id = @Id;";
            connection.Execute(sql, new { Id = id });
        }
    }
}
