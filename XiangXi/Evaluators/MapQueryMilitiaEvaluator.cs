using System.Linq;
using XiangXi.Models;
using XiangXiENtities.EF;

namespace XiangXi.Evaluators
{
    /// <summary>
    /// 查询党员点位列表
    /// </summary>
//    [CacheOptions(Timeout = 50000)]
//    public class MapQueryMilitiaEvaluator : Evaluator
//    {
//        protected override object Evaluate(CommonRequest request)
//        {
//            using (var ctx = new DefaultContext())
//            {
//                return
//                    ctx.Population.Join(ctx.Militia,
//                        population => population.PCitizenshipNumber, militia => militia.MIdCard,
//                        (population, militia) => population)
//                        .Join(ctx.Poi, population => population.PAddress,
//                            poi => poi.PAddress, (population, poi) => poi)
//                            .GroupBy(t => t.PAddress)
//                    .Select(t => t.FirstOrDefault()).OrderBy(poi => poi.ord).ToList();
//            }
//        }
//    }
}