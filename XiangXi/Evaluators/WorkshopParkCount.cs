using System.Collections.Generic;
using System.Linq;
using System.Web;
using XiangXi.Models;
using XiangXiENtities.EF;

namespace XiangXi.Evaluators
{
    [CacheOptions(Timeout = 5000)]
    public class BuildingParkCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var xaxis = new List<string>();
                var series = new List<int>();

                foreach (var line in ctx.FactoryBuilding.Where(t=>t.FBNameOfIndustrialPark!=null && t.FBNameOfIndustrialPark!=string.Empty).GroupBy(t => t.FBNameOfIndustrialPark))
                {
                    xaxis.Add(line.Key);
                    series.Add(line.Count());
                }
                return new
                {
                    sum = series.Sum(),
                    xaxis = xaxis,
                    series = series
                };
            }
        }
    }


    /// <summary>
    /// 工业园统计
    /// </summary>
    public class WorkshopParkCountEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                var xaxis = new List<string>();
                var series = new List<int>();

                foreach (var line in ctx.FactoryBuilding.GroupBy(t => t.FBNameOfIndustrialPark))
                {
                    xaxis.Add(line.Key);
                    series.Add(line.Count());
                }
                return new
                {
                    sum = series.Sum(),
                    xaxis = xaxis,
                    series = series
                };
            }
        }
    }
}