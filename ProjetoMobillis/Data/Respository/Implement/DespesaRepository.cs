using Dapper;
using ProjetoMobills.Data.Models;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoMobills.Data.Respository
{
    public class DespesaRespository : IDespesaRepository
    {
        private readonly SqlConfiguracaoConexao _dbContext;
        public DespesaRespository(SqlConfiguracaoConexao dbContext)
        {
            _dbContext = dbContext;
        }
        
        //Método de adicionar despesa
        public async Task<int> Add(Despesa despesa)
        {
            despesa.Data = DateTime.Today;
            using (var conn = new SqlConnection(_dbContext.Value))
            {
                conn.Open();
                const string query = @"INSERT INTO tbl_Despesa(Valor, Descricao, Pago, Data) VALUES (@Valor, @Descricao, @Pago, @Data)";
                var affectRows = await conn.ExecuteAsync(query, despesa);
                conn.Close();
                return affectRows;
            }
        }

        public async Task<int> Delete(int id)
        {
            const string query = "DELETE FROM tbl_Despesa WHERE Id = @Id";
            using var conn = new SqlConnection(_dbContext.Value);
            conn.Open();
            var affectRowns = await conn.ExecuteAsync(query, new { Id = id });
            return affectRowns;
        }

        public async Task<Despesa> GeyById(int id)
        {
            using var conn = new SqlConnection(_dbContext.Value);
            conn.Open();
            const string query = @"SELECT * FROM tbl_Despesa WHERE id = @Id ";
            var affectRows = await conn.QuerySingleOrDefaultAsync<Despesa>(query, new { Id = id });
            return affectRows;
        }

        public async Task<IEnumerable<Despesa>> List()
        {
            using var conn = new SqlConnection(_dbContext.Value);
            conn.Open();
            const string query = @"SELECT * FROM tbl_Despesa";
            var affectRows = await conn.QueryAsync<Despesa>(query);
            return affectRows.ToList();
        }

        public async Task<int> Update(Despesa despesa)
        {
            despesa.Data = DateTime.Today;
            using var conn = new SqlConnection(_dbContext.Value);
            conn.Open();
            const string query = @"UPDATE tbl_Receita SET Valor = @Valor, Descricao = @Descricao, Pago  = @Pago,  Data = @Data Value (@Valor, @Descricao, @Pago, @Data)";
            var affectRows = await conn.ExecuteAsync(query, despesa);
            return affectRows;

            
        }
        
    }
}
