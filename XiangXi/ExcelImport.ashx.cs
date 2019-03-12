using System;
using System.Text;
using System.Web;
using XiangXi.Evaluators;
using XiangXi.Models;

namespace XiangXi
{
    /// <summary>
    /// 保存头像文件
    /// </summary>
    [System.Web.Services.WebService(Namespace = "http://tempuri.org/")]
    [System.Web.Services.WebServiceBinding(ConformsTo = System.Web.Services.WsiProfiles.BasicProfile1_1)]

    public class ExcelImport : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            StringBuilder errorMsg = new StringBuilder(); // 错误信息
            string result = "";

            if (context.Request.Files.Count==0)
            {

                result = new
                {
                    IsOk=0,
                    Msg="没有收到文件"
                }.ToJson();
                context.Response.Write(result);
                context.Response.End();
            }



            #region 1.获取Excel文件并转换为一个List集合

            // 1.1存放Excel文件到本地服务器
            HttpPostedFile[] file = new HttpPostedFile[context.Request.Files.Count];//不确定文件数组; // 获取上传的文件
            string fileType = context.Request.Params["fileType"].ToString(); // 保存文件并获取文件路径
            string path, filePath;
            path = context.Server.MapPath("..\\Upload\\Excel");
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            filePath = GenerateFilePath(path);

            //尝试生成一个唯一的文件名字，如果存在就再生成一个
            int c = 0;
            while (System.IO.File.Exists(filePath) && c <= 5)
            {
                ++c;
                filePath = RegenerateFilePath(path);
            }

            file[0] = context.Request.Files[0];
            file[0].SaveAs(filePath);//存储图片完毕
            // 单元格抬头
            // key：实体对象属性名称，可通过反射获取值
            // value：属性对应的中文注解
            ImportProc.Proc(fileType, filePath, Evaluator.GetUser(context.Request.Params["auth_user"]), out errorMsg);

            #endregion
            result = ("{\"IsOk\":\"1\",\"Msg\":\"上传成功\"}");
            context.Response.Write(result);
            context.Response.End();
        }
        /// <summary>
        /// 生成一个文件路径
        /// </summary>
        /// <param name="path">目录地址</param>
        /// <returns>文件全路径</returns>
        private static string GenerateFilePath(string path)
        {
            return path + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
        }

        /// <summary>
        /// 规避文件重复
        /// </summary>
        /// <param name="path">目录地址</param>
        /// <returns>文件全路径</returns>
        private static string RegenerateFilePath(string path)
        {
            return path + "\\R" + DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next() + ".xls";
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

