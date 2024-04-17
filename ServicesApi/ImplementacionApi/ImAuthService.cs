using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsApi.Models;
using ServicesApi.InterfaceApi;

using AccessControl.Interfaces;
using AccessControl.Models;
using DAOApi;
using System.Data.SqlClient;
using System.Data;
using ModelsApi;
using System.Collections;

namespace ServicesApi.ImplementacionApi
{
    public class ImAuthService : IAuthServices
    {
        private readonly IJwtHandler _jwt;
        private readonly ConexionSql _conexionSql;
        private readonly SqlServerParameterList _lista;

        public ImAuthService(
            IJwtHandler jwt,
            ConexionSql conexionSql,
            SqlServerParameterList lista
            )
        {
            _jwt = jwt;
            _conexionSql = conexionSql;
            _lista = lista;
            
        }

        public string auth(ModelUserLogin usuario)
        {

            JsonWebToken token = new JsonWebToken();

            token = _jwt.Create(usuario.UserName);

            return token.AccessToken.ToString();

           // throw new NotImplementedException();
        }

        public ModelApiResponse authlogin(ModelUserLogin usuario)
        {
            ModelApiResponse model = new ModelApiResponse();
            ModelResLogin modelResLogin = new ModelResLogin();
            string token = "";
            JsonWebToken tokenJson = new JsonWebToken();
            int ExisteRegistro = 0;
            _lista.Parameters.Clear();
            try
            {
                if (_conexionSql.openConnection())
                {


                    _lista.Parameters.Insert(0, new SqlParameter { ParameterName = "@piUserName", SqlDbType = SqlDbType.VarChar, Value = usuario.UserName, Direction = ParameterDirection.Input });
                    _lista.Parameters.Insert(1, new SqlParameter { ParameterName = "@piUserPassword", SqlDbType = SqlDbType.VarChar, Value = usuario.UserPassword, Direction = ParameterDirection.Input });

                    _lista.Parameters.Add(new SqlParameter { ParameterName = "@vcExisteUser", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output });

                    SqlDataReader loginReader = _conexionSql.ExecuteStoredProcedure(Constants.shemaUsers + ListStoreProducers.SPConUsuarioExistente, _lista.Parameters);



                    while (loginReader.Read())
                    {

                        Int64 idUser = loginReader.GetInt64(0);
                        model.StatusCode = 1;
   
                        modelResLogin.IdUser = idUser;
                        model.Data = modelResLogin;
                    }

                    loginReader.NextResult();

                    SqlParameter foundParameter = _lista.Parameters.Find(param => param.ParameterName == "@vcExisteUser");

                    if (foundParameter != null)
                    {
                         ExisteRegistro = ((System.Data.SqlTypes.SqlInt32)foundParameter.SqlValue).Value;





                        if (ExisteRegistro > 0)
                        {

                            tokenJson = _jwt.Create(usuario.UserName);
                            token = tokenJson.AccessToken.ToString();
                            modelResLogin.token = token;


                        }
                        else
                        {
                            model.StatusCode = 0;
                            modelResLogin.token = token;
                            modelResLogin.IdUser = 0;
                            model.Data = modelResLogin;

                        }
                    }





             

                    loginReader.Close();

                }

                _conexionSql.CloseConnection();
            }
            catch (Exception)
            {
              

            }

            return model;
        }

        public string login(ModelUserLogin usuario)
        {
            string token = "";
            JsonWebToken tokenJson = new JsonWebToken();

            try
            {
                if (_conexionSql.openConnection())
                {


                    _lista.Parameters.Insert(0, new SqlParameter { ParameterName = "@piUserName", SqlDbType = SqlDbType.VarChar, Value = usuario.UserName, Direction = ParameterDirection.Input });
                    _lista.Parameters.Insert(1, new SqlParameter { ParameterName = "@piUserPassword", SqlDbType = SqlDbType.VarChar, Value = usuario.UserPassword, Direction = ParameterDirection.Input });

                    _lista.Parameters.Add(new SqlParameter { ParameterName = "@vcExisteUser ", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output });

                    SqlDataReader loginReader = _conexionSql.ExecuteStoredProcedure(Constants.shemaUsers + ListStoreProducers.SPConUsuarioExistente, _lista.Parameters);

                    SqlParameter foundParameter = _lista.Parameters.Find(param => param.ParameterName == "@ExisteRegistro");

                    int ExisteRegistro = ((System.Data.SqlTypes.SqlInt32)foundParameter.SqlValue).Value;
                   

                    if(ExisteRegistro > 0)
                    {

                        tokenJson = _jwt.Create(usuario.UserName);
                        token = tokenJson.AccessToken.ToString();


                

                        if (loginReader.Read())
                        {

                            Int64 idUsers = loginReader.GetInt64(0);

                        }




                    }
                    else
                    {
                        return token;
                    }
                    loginReader.Close();

                }

                _conexionSql.CloseConnection();
            }
            catch (Exception)
            {
                return token;

            }

            return token;
        }
    }
}
