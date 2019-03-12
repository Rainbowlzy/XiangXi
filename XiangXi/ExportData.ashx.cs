using System;
using System.Web;

namespace XiangXi
{
    /// <summary>
    /// ExportSchema 的摘要说明
    /// </summary>
    public class ExportData : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string title = context.Request.QueryString["title"];
            HttpResponse response = context.Response;
            string fileName = "导出模板-" + title + "-" + DateTime.Now.ToShortDateString();
            var excelContent = string.Empty;
            response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            response.ContentType = "application/vnd.ms-excel";
            response.AppendHeader("Content-Disposition", "attachment; filename="+ fileName + ".xls");
            response.Write(excelContent);
            response.Flush();
            response.End();
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}