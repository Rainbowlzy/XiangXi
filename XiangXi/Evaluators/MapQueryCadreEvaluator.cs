using System;
using System.Data.Objects;
using System.Linq;
using XiangXi.Models;
using XiangXiENtities.EF;

namespace XiangXi.Evaluators
{
    /// <summary>
    /// 干部
    /// </summary>
    [CacheOptions(Timeout = 50000)]
    public class MapQueryCadreEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                return
                    ctx.Population.Join(ctx.Cadre,
                        population => population.PCitizenshipNumber, cadre => cadre.CIdCardNo,
                        (population, cadre) => population)
                        .Join(ctx.Poi, population => population.PAddress,
                            poi => poi.PAddress, (population, poi) => poi).OrderBy(poi => poi.ord).ToList();
            }
        }
    }
}