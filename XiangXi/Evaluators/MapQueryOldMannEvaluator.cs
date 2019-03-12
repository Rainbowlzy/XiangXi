using System;
using System.Data.Objects;
using System.Linq;
using XiangXi.Models;
using XiangXiENtities.EF;

namespace XiangXi.Evaluators
{
    /// <summary>
    /// 老人点位列表
    /// </summary>
    //[CacheOptions(Timeout = 50000)]
    public class MapQueryOldMannEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var datalevel = CurrentUserInformation?.DataLevel;
                return ctx.Population.Where(t => t.PAge >= 60 && t.DataLevel.Contains(datalevel)&&t.IsDeleted==0)
                    .Join(ctx.Poi.Where(t => t.DataLevel.Contains(datalevel) && t.IsDeleted == 0), t => t.PAddress, t => t.PAddress, (t, r) => r)
                    .GroupBy(t=>t.PAddress)
                    .Select(t=>t.FirstOrDefault()).ToList();
            }
        }
    }
}