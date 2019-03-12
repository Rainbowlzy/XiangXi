using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XiangXi.Models;
using XiangXiENtities.EF;

namespace XiangXi.Evaluators
{
    public class ScheduleEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new XiangXiEntities())
            {
                UserInformation user = Sessions["UserInformation"] as UserInformation;
                string name = user.UILoginName;
                string pwd = user.UICode;
                var rows = ctx.V_Table_Comments.ToList();
                var tables = new HashSet<string>(rows.Select(p => p.table_name));
                return tables.ToDictionary(p => p, p => rows.Where(r => r.table_name == p).ToList());
            }
        }
    }
}