using System.IO;
using System.Linq;
using XiangXi.Models;

namespace XiangXi.Evaluators
{
    public class FileListEvaluator:Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var dir = @"..\..\XiangXi\gen\";
            return Directory.GetFiles(dir, "*List.html").Select(s=>s.Replace(dir, "http://localhost/XiangXi/gen/".Replace("\\","/")));
        }
    }
}