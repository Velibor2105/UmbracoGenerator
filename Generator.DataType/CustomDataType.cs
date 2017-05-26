using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generator.Entity;
using System.Data;
namespace Generator.DataType
{
    public class CustomDataType
    {
        private SqlConnection _connection;
        public CustomDataType(string connectionString)
        {
            if (connectionString != null)
            {
                _connection = new SqlConnection(connectionString);
                _connection.Open();
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public int AddCustomDataType(PropModel propModel)
        {
            if ((propModel.Type.StartsWith("MNTP") || propModel.Type.StartsWith("MUP") || propModel.Type.StartsWith("NC") || propModel.Type.StartsWith("AT")) && ExistDataType(GetDateType(propModel.Type)))
            {
                return GetDataTpyeId(GetDateType(propModel.Type));
            }
            if (propModel.Type.StartsWith("MNTP") && !ExistDataType(GetDateType(propModel.Type)))
            {
                SqlCommand cmd = new SqlCommand("pr_AddMNTPToDataType", _connection);
                cmd.Parameters.Add("@text", SqlDbType.VarChar).Value = GetDateType(propModel.Type);
                cmd.Parameters.Add("@createDate ", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
                return Convert.ToInt32(cmd.Parameters["@id"].Value);
            }
            if (propModel.Type.StartsWith("MUP") && !ExistDataType(GetDateType(propModel.Type)))
            {
                SqlCommand cmd = new SqlCommand("pr_AddMUPToDataType", _connection);
                cmd.Parameters.Add("@text", SqlDbType.VarChar).Value = GetDateType(propModel.Type);
                cmd.Parameters.Add("@createDate ", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
                return Convert.ToInt32(cmd.Parameters["@id"].Value);
            }
            if (propModel.Type.StartsWith("NC") && !ExistDataType(GetDateType(propModel.Type)))
            {
                SqlCommand cmd = new SqlCommand("pr_AddNestedContentToDataType", _connection);
                cmd.Parameters.Add("@text", SqlDbType.VarChar).Value = GetDateType(propModel.Type);
                cmd.Parameters.Add("@createDate ", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
                return Convert.ToInt32(cmd.Parameters["@id"].Value);
            }
            if (propModel.Type.StartsWith("AT") && !ExistDataType(GetDateType(propModel.Type)))
            {
                SqlCommand cmd = new SqlCommand("pr_AddArchetypeToDataType", _connection);
                cmd.Parameters.Add("@text", SqlDbType.VarChar).Value = GetDateType(propModel.Type);
                cmd.Parameters.Add("@createDate ", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
                return Convert.ToInt32(cmd.Parameters["@id"].Value);
            }
            return 0;
        }

        public SqlConnection GetConncetion()
        {
            return _connection;
        }

        public bool ExistDataType(string text)
        {
            SqlCommand cmd = new SqlCommand("pr_ExistDataType", _connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Text", SqlDbType.VarChar).Value = text;
            cmd.Parameters.Add("@Count", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            return Convert.ToInt32(cmd.Parameters["@Count"].Value) > 0;
        }

        public int GetDataTpyeId(string text)
        {
            SqlCommand cmd = new SqlCommand("[pr_GetIdDataTypeByText]", _connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Text", SqlDbType.VarChar).Value = text;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            return Convert.ToInt32(cmd.Parameters["@Id"].Value);
        }

        private static string GetDateType(string text)
        {
            char[] delimiterChars = { ':','-' };
            string[] words = text.Split(delimiterChars);

            return words != null && words.Count() > 1 ? words[1] : "Enter data type";
        }
    }
}
