using MarkModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MarkDAL
{
    class SujectService
    {
        //添加课程,返回课程id
        public int addSubject(ref SubjectClass suject)
        {
            int ID = 0;
            using (SqlConnection con = new SqlConnection(Dbhelper.dbsr))
            {
                Dbhelper helper = new Dbhelper(con);
                SqlParameter pSubject = new SqlParameter { ParameterName = "@sSubject", SqlDbType = System.Data.SqlDbType.VarChar, Value = suject.sSubject };
                if(helper.ExecuteSQL("insert into Subjects (sSubject) values(@sSubject)", pSubject) > 0)
                {
                    ID = helper.GetScalar("select top 1 sID from Subjects order by sID desc");
                }
                con.Close();
            }
                return ID;
        }

        //删除课程，返回布尔值，是否删除成功
        public bool deleteSubject(SubjectClass subject)
        {
            bool flag = false;
            using(SqlConnection con = new SqlConnection(Dbhelper.dbsr))
            {
                Dbhelper helper = new Dbhelper(con);
                SqlParameter pID = new SqlParameter { ParameterName = "@sID", SqlDbType = System.Data.SqlDbType.Int, Value = subject.ID };
                if(helper.ExecuteSQL("delete from Subjects where sID=@sID ", pID) > 0)
                {
                    flag = true;
                }
                con.Close();
            }
            return flag;
        }

        //更新课程(根据课程iid更新课程名)
        public bool updateSubject(SubjectClass subject)
        {
            bool flag = false;
            using(SqlConnection con = new SqlConnection(Dbhelper.dbsr))
            {
                Dbhelper helper = new Dbhelper(con);
                SqlParameter pID = new SqlParameter { ParameterName = "@sID", SqlDbType = System.Data.SqlDbType.Int, Value = subject.ID };
                SqlParameter pSubject = new SqlParameter { ParameterName = "@sSubject", SqlDbType = System.Data.SqlDbType.VarChar, Value = subject.sSubject };
                if(helper.ExecuteSQL("update Subjects set sSubject=@sSubject where sID=@sID", pSubject, pID) > 0)
                {
                    flag = true;
                }
            }
            return flag;
        }

        //获取表“Subjects”中的所有数据
        public DataTable getSubjectDataTable()
        {
            DataTable dt = new DataTable("Subjects");
            using(SqlConnection con = new SqlConnection(Dbhelper.dbsr))
            {
                Dbhelper helper = new Dbhelper(con);
                SqlDataAdapter adapter = helper.GetAdapter("select * from Subjects order by sSubject");
            }
            return dt;
        }

    }
}
