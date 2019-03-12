using System.Linq;
using XiangXi.Models;
using XiangXiENtities.EF;

namespace XiangXi.Evaluators
{
    public class PopulationGenderCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var context = new DefaultContext())
            {
                return new
                {
                    series = context.Population.Where(t => t.PAge > 0).GroupBy(t => t.PNeighborhoodVillageCommittee).Select(t => new
                {
                    name = t.Key,
                    value = t.Count()
                }).ToList()
                };
            }
        }
    }
}