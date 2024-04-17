using DAOApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;




namespace DAOApi
{
    public class ConexionSql
    {

        private readonly string connectionString = null;
        private SqlConnection connection = null;

        private readonly IOptions<ModelConexion> _accessOptions;

        public ConexionSql(IOptions<ModelConexion> accessOptions)
        {
            _accessOptions = accessOptions;
            this.connectionString = _accessOptions.Value.CoreSolufiDB;

        }

       

        public bool openConnection()
        {
            try
            {
                if (this.connection != null && this.connection.State == System.Data.ConnectionState.Open)
                {
                    throw new InvalidOperationException("Sólo se permite una conexión abierta.");
                }
                this.connection = new SqlConnection(this.connectionString);
                this.connection.Open();
                return true;
            }
            catch (Exception ex)
            {

                this.connection.Close();
                this.connection.Open();
                return false;
            }
        }
        public void CloseConnection()
        {
            if (this.connection != null && this.connection.State == System.Data.ConnectionState.Open)
            {
                this.connection.Close();
            }
        }
        public SqlDataReader ExecuteStoredProcedure(string storedProcedureName, List<SqlParameter> parameters)
        {
            SqlCommand sqlCommand = new SqlCommand(storedProcedureName, this.connection)
            {
                CommandType = CommandType.StoredProcedure

            };
            this.AssignParametersGenerico(sqlCommand, parameters);
            return sqlCommand.ExecuteReader();
        }
        public SqlDataReader ExecuteQuery(string query, List<SqlParameter> parameters = null)
        {
            SqlCommand sqlCommand = new SqlCommand(query, this.connection);

            if (parameters != null)
            {
                this.AssignParametersGenerico(sqlCommand, parameters);
            }

            return sqlCommand.ExecuteReader();
        }

        private void AssignParametersGenerico(SqlCommand sqlCommand, List<SqlParameter> parameters)
        {
            if (parameters != null && parameters.Count > 0)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    sqlCommand.Parameters.Add(parameter);
                }

            }
        }

    }
}
