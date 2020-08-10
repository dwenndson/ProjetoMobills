using Dapper;
using Microsoft.Data.SqlClient;
using ProjetoMobills.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMobills.Data.Respository.Implement
{
    public class ReceitaRepository : IReceitaRepository
    {
        private readonly SqlConfiguracaoConexao _dbContext;
        public ReceitaRepository(SqlConfiguracaoConexao dbContext)
        {
            _dbContext = dbContext;
        }

        //Método de adicionar despesa
        public async Task<int> Add(Receita receita)
        {
            receita.Data = DateTime.Today;
            using var conn = new SqlConnection(_dbContext.Value);
            conn.Open();
            const string query = @"INSERT INTO tbl_Receita(Valor, Descricao, Pago, Data) VALUES(@Valor, @Descricao, @Pago, @Data)";
            var affectRows = await conn.ExecuteAsync(query, receita);
            conn.Close();
            return affectRows;
        }

        public async void Delete(int id)
        {
            const string query = "DELETE FROM tbl_Receita WHERE Id = @Id";
            using var conn = new SqlConnection(_dbContext.Value);
            conn.Open();
            var affectRowns = await conn.ExecuteAsync(query, new { Id = id });
        }

        public async Task<Receita> GeyById(int id)
        {
            using var conn = new SqlConnection(_dbContext.Value);
            conn.Open();
            const string query = @"SELECT * FROM tbl_Receita WHERE id = @Id ";
            var affectRows = await conn.QueryAsync<Receita>(query, new { Id = id });
            return affectRows.FirstOrDefault();
        }

        public async Task<IEnumerable<Receita>> List()
        {
            using var conn = new SqlConnection(_dbContext.Value);
            conn.Open();
            const string query = @"SELECT * FROM tbl_Receita";
            var affectRows = await conn.QueryAsync<Receita>(query);
            return affectRows;
        }

        public async Task<int> Update(Receita receita)
        {
            receita.Data = DateTime.Today;
            using var conn = new SqlConnection(_dbContext.Value);
            conn.Open();
            const string query = @"UPDATE tbl_Receita SET Valor = @Valor, Descricao = @Descricao, Pago  = @Pago,  Data = @Data Value (@Valor, @Descricao, @Pago, @Data)";
            var affectRows = await conn.QueryFirstAsync(query, receita);
            return affectRows;


        }
    }
}
