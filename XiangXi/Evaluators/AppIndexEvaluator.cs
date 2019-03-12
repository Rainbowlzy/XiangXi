using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using XiangXi.Models;
using XiangXiENtities.EF;

namespace XiangXi.Evaluators
{
    public class UploadedImageEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var mapPath = request.context.Request.MapPath("~/Upload/Image");
            List<string> files = new List<string>();
            Stack<string> stack = new Stack<string>();
            stack.Push(mapPath);
            while (stack.Count!=0)
            {
                var currentdir = stack.Pop();
                foreach (var directory in Directory.GetDirectories(currentdir))
                {
                    stack.Push(directory);
                }
                files.AddRange(Directory.GetFiles(currentdir));
            }
            return files
                .OrderByDescending(File.GetCreationTime)
                .Select(s => s.Replace(mapPath, $"http://localhost/XiangXi/Upload/Image")).ToList();
        }
    }
    public class AppInteractionEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            return new AppIndex
            {
                config = new AppIndexConfig
                {
                    bannerImage = "http://192.168.1.111/XiangXi/Upload/portrait/R0001.jpg"
                },
                menu = new[]
                {
                    new MenuItem
                    {
                        image="http://192.168.1.111/XiangXi/Upload/portrait/R0001.jpg",
                        title="菜单1",
                        url="http://www.baidu.com"
                    },
                    new MenuItem
                    {
                        image="http://192.168.1.111/XiangXi/Upload/portrait/R0001.jpg",
                        title="菜单1",
                        url="http://www.baidu.com"
                    },
                    new MenuItem
                    {
                        image="http://192.168.1.111/XiangXi/Upload/portrait/R0001.jpg",
                        title="菜单1",
                        url="http://www.baidu.com"
                    },
                }
            };
        }
    }

    public class AppIndexEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var user = CurrentUserInformation;
            using (var ctx = new DefaultContext())
            {
                return new AppIndex
                {
                    config = new AppIndexConfig
                    {
                        bannerImage = "http://192.168.1.111/XiangXi/Upload/portrait/R0001.jpg"
                    },
                    notice = ctx.Notice.Where(p => p.NNotificationSenderObject == user.id),
                    menu =
                        ctx.MenuConfiguration.Where(p => p.MCParentTitle == "APP首页").Select(p => new MenuItem
                        {
                            title = p.MCTitle,
                            image = p.MCPicture,
                            url = p.MCLink
                        }).ToArray()
                };
            }
        }
    }
}