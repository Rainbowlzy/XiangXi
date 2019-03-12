using Newtonsoft.Json;
using XiangXi.Models;
using XiangXiENtities.EF;
using XiangXiEntities1.EF;

namespace XiangXi.Evaluators
{
    public class GetSYS_CodeListEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest parameter)
        {
            var data = parameter.data??"{}";
            var input = JsonConvert.DeserializeObject<SPCallParameter>(data.ToString());
            using (var ctx = new SPCall())
            {
                input.limit = 4000;
                var spresult = ctx.SP_GET_ALL_LIST<SYS_Code>(input);
                var rows = IEnumerableParser.Parse(spresult);
                return new
                {
                    message = "查询成功",
                    rows,
                    success = true,
                    input.total
                };
            }
        }

    }
}