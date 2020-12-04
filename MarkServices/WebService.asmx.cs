using MarkBLL;
using MarkModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MarkServices
{
    /// <summary>
    /// WebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public DataTable getStudentDataTable()
        {
            SubjectManager manager = new SubjectManager();
            return manager.getSubjectDataTable();
        }
        [WebMethod]
        public bool updateStudent(StudentClass s)
        {
            SubjectMannager manager = new SubjectManager();
            return manager.updateSubject(s);
        }
        [WebMethod]
        public bool addStudent(StudentClass s)
        {
            SubjectManager manager = new SubjectManager();
            return manager.addSubject(s);
        }
        [WebMethod]
        public bool deleteStudent(StudentClass s)
        {
            SubjectManager manager = new SubjectManager();
            return manager.deleteSubject(s);
        }
    }
}
