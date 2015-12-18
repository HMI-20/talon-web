using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace OnlineCoupone.DAL.Helper
{
    public class PostgreSQLHelper_OnlineSystem
    {
        const string CONNECTION_STRING = "Server=127.0.0.1;User Id=postgres;Password=MakTraDe;Database=OnlineSystemDB;";
        //const string CONNECTION_STRING = "Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=AppDK.Client;CommandTimeout=240;";

        internal static DataTable ExecuteSelectCommand(string CommandName, CommandType cmdType)
        {
            DataTable table = null;
            using (NpgsqlConnection con = new NpgsqlConnection(CONNECTION_STRING))
            {
                using (NpgsqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                        {
                            table = new DataTable();
                            var reader = cmd.ExecuteReader();
                            table.Load(reader);
                        }
                    }
                    catch (Exception e)
                    {
                        //Log.Error(e);
                        throw;
                    }
                }
            }

            return table;
        }
        internal static DataTable ExecuteParamerizedSelectCommand(string CommandName, CommandType cmdType, NpgsqlParameter[] param)
        {
            DataTable table = new DataTable();

            using (NpgsqlConnection con = new NpgsqlConnection(CONNECTION_STRING))
            {
                using (NpgsqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;
                    cmd.Parameters.AddRange(param);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                        {
                            table = new DataTable();
                            var reader = cmd.ExecuteReader();
                            table.Load(reader);
                        }
                    }
                    catch (Exception e)
                    {
                        //Log.Error(e);
                        throw;
                    }
                }
            }

            return table;
        }

        internal static bool ExecuteNonQuery(string CommandName, CommandType cmdType, NpgsqlParameter[] pars)
        {
            int result = 0;

            using (NpgsqlConnection con = new NpgsqlConnection(CONNECTION_STRING))
            {
                using (NpgsqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;
                    cmd.Parameters.AddRange(pars);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        result = cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        //Log.Error(e);
                        throw;
                    }
                }
            }

            return (result > 0);
        }

        internal static List<string> Select_ArrayString(string select)
        {
            try
            {
                List<String> list = new List<string>();
                using (DataTable table = PostgreSQLHelper_Policlinic.ExecuteSelectCommand(select, CommandType.Text))
                {
                    if (table.Rows.Count > 0)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            list.Add(row[0].ToString());
                        }
                    }
                }

                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        internal static int Select_Number(string select)
        {
            try
            {
                int count = 0;
                using (DataTable table = PostgreSQLHelper_Policlinic.ExecuteSelectCommand(select, CommandType.Text))
                {
                    if (table.Rows.Count > 0)
                    {
                        count = int.Parse(table.Rows[0][0].ToString());
                    }
                }

                return count;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        internal static string Select_String(string select)
        {
            try
            {
                string result = "";
                using (DataTable table = PostgreSQLHelper_Policlinic.ExecuteSelectCommand(select, CommandType.Text))
                {
                    if (table.Rows.Count > 0)
                    {
                        result = table.Rows[0][0].ToString();
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }
    }
}
