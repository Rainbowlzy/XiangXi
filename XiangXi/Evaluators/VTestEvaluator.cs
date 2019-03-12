using System.Collections.Generic;
using System.Linq;
using XiangXi.Models;
using XiangXiENtities.EF;

namespace XiangXi.Evaluators
{
    public class VTestEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new XiangXiEntities())
            {
                var rows = ctx.V_Table_Comments.ToList();
                var tables = new HashSet<string>(rows.Select(p => p.table_name));
                return tables.ToDictionary(p => p, p => rows.Where(r => r.table_name == p).ToList());
            }
        }
    }
}