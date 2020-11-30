Imports System.Web.Services
Imports System.ComponentModel
Imports MarkDAL
Imports MarkModel
' 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class Server

    Inherits WebService

    <WebMethod()>
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

    Public Function getSubjectDataTable() As DataTable
    End Function
End Class
