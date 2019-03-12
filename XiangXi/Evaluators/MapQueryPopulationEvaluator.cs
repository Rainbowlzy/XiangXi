using System.Data.Entity.Core.Objects;
using System.Linq;
using XiangXi.Models;
using XiangXiENtities.EF;
using XiangXiENtities.EF.NewEntities;

namespace XiangXi.Evaluators
{
    /// <summary>
    /// 人口点位列表
    /// </summary>
    //[CacheOptions(Timeout = 50000)]
    public class MapQueryPopulationEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var datalevel = CurrentUserInformation?.DataLevel;
            using (var context = new DefaultContext())
            {
                IQueryable<Population> population_list = context.Population.Where(t => t.IsDeleted == 0 && t.DataLevel.StartsWith(datalevel));
                IQueryable<Poi> poi_list = context.Poi.Where(t => t.IsDeleted == 0 && t.DataLevel.StartsWith(datalevel) && t.Longitude.Length>0 && t.Latitude.Length>0);
                return population_list.Join(poi_list, population => population.PAddress, poi => poi.PAddress, (population, poi) => poi)
                    .GroupBy(t=>t.PAddress).Select(t=>t.FirstOrDefault())
                    .OrderBy(poi => poi.ord).ToList();
            }
        }
    }
}