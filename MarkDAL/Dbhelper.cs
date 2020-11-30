using System;
using System.Data.SqlClient;
using System.Data;
namespace MarkDAL
{
    public class Dbhelper
    {
            public SqlConnection con;
            public SqlCommand cmd;
            public static String dbsr = System.Configuration.ConfigurationManager.ConnectionStrings["dbUri"].ConnectionString;
            //构造函数初始化con和cmd
            public Dbhelper(SqlConnection con)
            {
                con.Open();
                this.con = con;
                cmd = new SqlCommand
                {
                    Connection = con
                };
            }

            //获取执行sql的函数
            public int ExecuteSQL(String sql)
            {
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                //返回受sql语句影响的数据行数
                return cmd.ExecuteNonQuery();
            }
            //重载1
            public int ExecuteSQL(String sql, params SqlParameter[] sqlParameters)
            {
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(sqlParameters);
                int i = Convert.ToInt32(cmd.ExecuteNonQuery());
                return i;
            }
            //获取一行数据
            public int GetScalar(String sql)
            {
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                int i = Convert.ToInt32(cmd.ExecuteScalar());
                return i;
            }
            //重载，params是声明后面SqlParameter类型的数组的长度是可变的
            public int GetScalar(String sql, params SqlParameter[] sqlParameters)
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                //将数据重新加载到cmd的Parameters中
                cmd.Parameters.AddRange(sqlParameters);
                int yy = Convert.ToInt32(cmd.ExecuteScalar());
                return yy;
            }

            //获取接收sql操作结果的对象
            public SqlDataReader GetReader(String sql)
            {
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                SqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            //重载
            public SqlDataReader GetReader(String sql, params SqlParameter[] sqlParameters)
            {
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(sqlParameters);
                SqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            //获取将数据填充到本地数据库的适配器
            public SqlDataAdapter GetAdapter(String sql)
            {
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                return adapter;
            }

            //重载
            public SqlDataAdapter GetAdapter(String sql, params SqlParameter[] sqlParameters)
            {
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(sqlParameters);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                return adapter;
            }
        }
    }

