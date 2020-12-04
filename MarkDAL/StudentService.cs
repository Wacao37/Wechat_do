using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using MarkModel;

namespace MarkDAL
{
    class StudentService
    {
        public bool addStudent(StudentClass s)
        {
            bool flag = false;
            using (SqlConnection con = new SqlConnection(Dbhelper.dbsr))
            {
                Dbhelper DB = new Dbhelper(con);
                SqlParameter pNo = new SqlParameter { ParameterName = "@sNo", SqlDbType = SqlDbType.Char, Value = s.sNo };
                SqlParameter pName = new SqlParameter { ParameterName = "@sName", SqlDbType = SqlDbType.Char, Value = s.sName };
                SqlParameter pPass = new SqlParameter { ParameterName = "@sPass", SqlDbType = SqlDbType.Char, Value = s.sPass };
                try
                {
                    if ( DB.ExecuteSQL("insert into students(sNo,sName,sPass)values(@sNo,@sName,@sPass)",pNo,pName,pPass)>0){ flag = true; }
                }
                catch { }
                con.Close();
            }
            return flag;
        }
        public bool deleteStudent(StudentClass Student)
        {
            bool flag = false;
            using (SqlConnection con = new SqlConnection(Dbhelper.dbsr))
            {
                Dbhelper DB = new Dbhelper(con);
                SqlParameter pNo = new SqlParameter { ParameterName = "@sNo", SqlDbType = SqlDbType.Char, Value = Student.sNo };
                if(DB.ExecuteSQL("delete from students where sNo=@sNo", pNo) > 0)
                { flag = true; }
                con.Close();
            }
            return flag;
        }
        public bool updateStudent(StudentClass Student)
        {
            bool flag = false;
            using (SqlConnection con = new SqlConnection(Dbhelper.dbsr))
            {
                Dbhelper DB = new Dbhelper(con);
                SqlParameter pNo = new SqlParameter { ParameterName = "@sNo", SqlDbType = SqlDbType.Char, Value = Student.sNo };
                SqlParameter pName = new SqlParameter { ParameterName = "@sName", SqlDbType = SqlDbType.Char, Value = Student.sName };
                SqlParameter pPass = new SqlParameter { ParameterName = "@sPass", SqlDbType = SqlDbType.Char, Value = Student.sPass };
                if(DB.ExecuteSQL("update students set sName=@sName,sPass=@sPass where sNo=@sNo",pNo,pName,pPass)>0)
                { flag = true; }
                con.Close();
            }
            return flag;
        }
        public DataTable getStudentDataTable()
        {
            DataTable dt = new DataTable("Students");
            using (SqlConnection con = new SqlConnection(Dbhelper.dbsr))
            {
                Dbhelper DB = new Dbhelper(con);
                SqlDataAdapter adapter = DB.GetAdapter("select*from Students order by sNo");
                adapter.Fill(dt);
                con.Close();
            }
            return dt;
        }
    }
}
