using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ReportInfrastructure.Sql
{
    public static class DapperHelper
    {
        private static string _connectionString;
        public static string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        public static IDbConnection Connection
        {
            get
            {
                //"Data Source=DESKTOP-HO9R1KR\\SA -WEB ;Initial Catalog = BPMS_NanoBoton; Integrated Security= True; MultipleActiveResultSets=True"
                return new SqlConnection("Data Source = DESKTOP-HO9R1KR\\SA ;Initial Catalog = BPMS_NanoBoton; Integrated Security= True;");//Configurations.ConnectionString
            }
        }

        #region ExecuteMultiple

        public static int ExecuteMultiple<T>(T[] inputModel, string ProcedureName)
        {
            return ExecuteMultiple<T>(inputModel, commandType: CommandType.StoredProcedure, ProcedureName);
        }

        /// <summary>
        /// Execute Multiple Query
        /// </summary>        
        /// <typeparam name="T">Parameters Input Model</typeparam>
        /// <param name="inputModel">Object of Parameters Input Model</param>
        /// <param name="commandType">Command Type (Text, StoredProcedure or TableDirect)</param>
        /// <param name="query">Sql Server Query</param>
        /// <returns>Count of affected rows</returns>
        public static int ExecuteMultiple<T>(T[] inputModel, CommandType commandType, string query)
        {

            using (IDbConnection conn = Connection)
            {
                if (!(conn.State == ConnectionState.Open))
                {
                    conn.Open();
                }

                // var p = new DynamicParameters(inputModel);
                var result = conn.Execute(query, inputModel, commandType: commandType);
                return result;

            }
        }

        #endregion

        #region Query

        public static IEnumerable<TOutput> GetQueryResult<TParameters, TOutput>(TParameters inputModel, CommandType commandType, string query)
        {
            using (IDbConnection conn = Connection)
            {
                if (!(conn.State == ConnectionState.Open))
                {
                    conn.Open();
                }

                //result = conn.QueryAsync<T>(ProcedureName,commandType: CommandType.StoredProcedure);
                if (inputModel == null)
                {
                    var result = conn.Query<TOutput>(query, commandType: commandType, commandTimeout: 50);
                    return result;
                }
                else
                {
                    var parameters = new DynamicParameters(inputModel);
                    var result = conn.Query<TOutput>(query, parameters, commandType: commandType);
                    return result;
                }

            }
        }

        public static IEnumerable<TOutput> GetQueryResult<TOutput>(CommandType commandType, string query)
        {
            using (IDbConnection conn = Connection)
            {
                if (!(conn.State == ConnectionState.Open))
                {
                    conn.Open();
                }

                var result = conn.Query<TOutput>(query, commandType: commandType);
                return result;


            }
        }

        public static IEnumerable<TOutput> Query<TOutput>(object input, CommandType commandType, string query)
        {
            using (IDbConnection conn = Connection)
            {
                if (!(conn.State == ConnectionState.Open))
                {
                    conn.Open();
                }

                var results = conn.Query<TOutput>(query, input, commandType: commandType);
                //var result = conn.Query<TOutput>(query, commandType: commandType);
                return results;


            }
        }


        #endregion

        public static List<dynamic> StoredProcWithParamsDynamic(string procname, dynamic parms)
        {
            using (IDbConnection conn = Connection)

            //using (SqlConnection connection = Connection)
            {
                return conn.Query(procname, (object)parms, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public static object ExecuteStoredProcedure<TOutput>(DynamicParameters parameters, string ProcedureName, string outputParameterName = null)
        {
            using (IDbConnection conn = Connection)
            {
                if (!(conn.State == ConnectionState.Open))
                {
                    conn.Open();
                }


                //parameters.Add("@newId", DbType.Int32, direction: ParameterDirection.Output);

                var result = conn.Execute(ProcedureName, parameters, null, null, CommandType.StoredProcedure);

                if (string.IsNullOrEmpty(outputParameterName))
                {
                    return result;
                }
                else
                {
                    var retVal = parameters.Get<TOutput>(outputParameterName);
                    return retVal;
                }
            }
        }


        public enum OutputData
        {
            OnlyFirstRecord = 1,
            AllReturnedData = 2,
        }

        //public class MultipleOutputModel<TDataModel, TMessageModel>
        //{
        //    public TMessageModel message { get; set; }
        //    public TDataModel data { get; set; }
        //}

        /// <summary>
        /// C#:     DapperHelper.ExecuteQuery_With_DataAndMessage<object, DataModel, DBMessageModel>("spTest", null, System.Data.CommandType.StoredProcedure);
        /// 
        /// SQL:    exec spGetMessage  @MessageID = 3, @MessageKey = 'NotFound_Record', @Culture = 'fa-IQ'
        ///         and 
        ///         Get Data Query
        /// </summary>
        /// <typeparam name="TParameters"></typeparam>
        /// <typeparam name="TDataModel"></typeparam>
        /// <typeparam name="TMessageModel"></typeparam>
        /// <param name="sqlQueries"></param>
        /// <param name="param"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static MultipleOutputModel<List<TDataModel>, TMessageModel> ExecuteQuery_With_DataAndMessage<TDataModel, TMessageModel>(string sqlQueries, object param, CommandType commandType, ReturnType returnType)
        {
            //TParameters

            SqlMapper.GridReader resultSet = null;
            var result = new MultipleOutputModel<List<TDataModel>, TMessageModel>();

            using (IDbConnection conn = Connection)
            {
                if (!(conn.State == ConnectionState.Open))
                {
                    conn.Open();
                }

                if (param == null)
                {
                    resultSet = conn.QueryMultiple(sqlQueries, commandType: commandType);
                }
                else
                {

                    var parameters = new DynamicParameters(param);
                    resultSet = conn.QueryMultiple(sqlQueries, param: parameters, commandType: commandType);
                }

                switch (returnType)
                {
                    case ReturnType.OnlyData:
                        if (!resultSet.IsConsumed)
                        {
                            var dataset = resultSet?.Read<TDataModel>();
                            if (dataset != null)
                            {
                                result.data = dataset.ToList();
                            }
                            else
                            {
                                result.data = new List<TDataModel>();
                            }
                            //result.data = resultSet?.Read<TDataModel>()?.ToList();
                        }
                        break;

                    case ReturnType.OnlyMessage:
                        if (!resultSet.IsConsumed)
                        {
                            result.message = resultSet.Read<TMessageModel>().First();
                        }
                        break;

                    case ReturnType.MessageAndData:
                        while (!resultSet.IsConsumed)
                        {
                            result.message = resultSet.Read<TMessageModel>().First();

                            var dataset = resultSet?.Read<TDataModel>();
                            if (dataset != null)
                            {
                                result.data = dataset.ToList();
                            }
                            else
                            {
                                result.data = new List<TDataModel>();
                            }
                            //result.data = resultSet?.Read<TDataModel>()?.ToList();
                        }
                        break;

                    case ReturnType.DataAndMessage:
                        while (!resultSet.IsConsumed)
                        {

                            var dataset = resultSet?.Read<TDataModel>();
                            if (dataset != null)
                            {
                                result.data = dataset.ToList();
                            }
                            else
                            {
                                result.data = new List<TDataModel>();
                            }

                            result.message = resultSet.Read<TMessageModel>().First();

                        }
                        break;

                    default:
                        break;
                }

                //try
                //{
                //    result.message = resultSet.Read<TMessageModel>().First();
                //}
                //catch (Exception ex)
                //{}

                //try
                //{
                //    result.data = resultSet?.Read<TDataModel>()?.ToList();
                //}
                //catch (Exception ex)
                //{}



                return result;

            }

        }


        public static ReportInfrastructure.Service.ServiceResult<int> DeleteMultipleItems(int[] ID, string storedProcedureName /*string token, string ip, string culture, int branchID*/)
        {
            var serviceResult = new ReportInfrastructure.Service.ServiceResult<int>();

            if (string.IsNullOrEmpty(storedProcedureName))
            {
                throw new Exception("Developer Exception ...");
            }

            if (ID == null)
            {
                serviceResult.State = Service.StateEnum.NotValid;
                return serviceResult;
            }

            var IDs = ID.Select(S => new IDModel<int> { ID = S /*Token = token, IP = ip, Culture = culture, BranchID = branchID */})?.ToArray();


            bool isOK = IDs.Any(p => !(p.ID > 0));

            if (isOK)
            {
                serviceResult.State = ReportInfrastructure.Service.StateEnum.NotValid;
                return serviceResult;
            }

            try
            {
                using (IDbConnection conn = Connection)
                {
                    if (!(conn.State == ConnectionState.Open))
                    {
                        conn.Open();
                    }

                    //T[] inputModel
                    var result = DapperHelper.ExecuteMultiple<IDModel<int>>(IDs, System.Data.CommandType.StoredProcedure, storedProcedureName);
                    serviceResult.SetData(result);


                    //object param = new { IDs/*, token */};
                    //var result = conn.Execute(storedProcedureName, param, commandType: CommandType.StoredProcedure);
                    //serviceResult.SetData(result);
                }

                //var result = DapperHelper.ExecuteMultiple<IDModel<int>>(IDs, System.Data.CommandType.StoredProcedure, storedProcedureName);
                //serviceResult.SetData(result);
            }
            catch (SqlException ex)
            {
                if (ex.Number == ReportInfrastructure.Sql.ErrorNumbers.CustomErrors)
                {
                    serviceResult.State = ReportInfrastructure.Service.StateEnum.Exception;
                    serviceResult.Message = ex.Message;
                }
                else
                {
                    serviceResult.State = ReportInfrastructure.Service.StateEnum.Exception;
                    //serviceResult.Message = ex.Message;
                }

            }
            catch (Exception ex)
            {
                serviceResult.State = ReportInfrastructure.Service.StateEnum.Exception;
            }

            return serviceResult;
        }
    }
}

