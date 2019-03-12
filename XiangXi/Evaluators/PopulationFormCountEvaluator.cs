using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XiangXi.Models;
using XiangXiENtities.EF;

namespace XiangXi.Evaluators
{
    [CacheOptions(Timeout = 5000)]
    public class PopulationFormCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var xaxis = new List<string>();
            var series = new List<int>();
            using (var context = new DefaultContext())
            {
                foreach (var line in context.Population.GroupBy(p => p.PNeighborhoodVillageCommittee))
                {
                    xaxis.Add(line.Key);
                    series.Add(line.Count());
                }
                return new
                {
                    sum = series.Sum(),
                    xaxis,
                    series
                };
            }
        }
    }
}