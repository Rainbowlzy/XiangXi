using System.Linq;
using XiangXi.Models;
using XiangXiENtities.EF;

namespace XiangXi.Evaluators
{
    /// <summary>
    /// 残疾人点位列表
    /// </summary>
    [CacheOptions(Timeout = 50000)]
    public class MapQueryDisabledManEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                return
                    ctx.Population.Join(ctx.CareForTheObject, population => population.PCitizenshipNumber,
                        care => care.CFTOId, (population, care) => population)
                        .Join(ctx.Poi, population => population.PAddress,
                            poi => poi.PAddress, (population, poi) => poi).OrderBy(poi => poi.ord).ToList();
            }
        }
    }
}