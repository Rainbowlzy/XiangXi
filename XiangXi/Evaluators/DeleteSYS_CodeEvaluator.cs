using Newtonsoft.Json;
using XiangXi.Models;
using XiangXiENtities.EF;

namespace XiangXi.Evaluators
{
    public class DeleteSYS_CodeEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var data = JsonConvert.DeserializeObject<SYS_Code>(request.data);
            if (data == null)
                return new CommonOutputT<string>
                {
                    success = false,
                    message = "删除失败"
                };
            using (var ctx = new DefaultContext())
            {
                var one = ctx.SYS_Code.Find(data.id);
                if (one == null)
                {
                    return new CommonOutputT<string>
                    {
                        success = false,
                        message = "未找到实体"
                    };
                }
                ctx.SYS_Code.Remove(one);
                ctx.SaveChanges();
                return new CommonOutputT<string>
                {
                    success = true,
                    message = "删除成功"
                };
            }
        }
    }
}