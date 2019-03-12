using System.Linq;
using XiangXi.Models;
using XiangXiENtities.EF;
using XiangXiENtities.EF.NewEntities;

namespace XiangXi.Evaluators
{
    /// <summary>
    /// 厂房点位列表
    /// </summary>
    [CacheOptions(Timeout = 50000)]
    public class MapQueryFactoryBuildingEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var searchModel = request.data.Deserialize<FactoryBuildingSearchModel>();
            var industrialParkName = searchModel?.FBNameOfIndustrialPark;

            using (var ctx = new DefaultContext())
            {
                IQueryable<FactoryBuilding> queryable = ctx.FactoryBuilding.Where(building =>building.IsDeleted==0);
                if (!string.IsNullOrEmpty(industrialParkName))
                    queryable = queryable.Where(t => t.FBNameOfIndustrialPark == industrialParkName);
                return
                    queryable
                        .Join(ctx.Poi.Where(t => t.Longitude.Length > 0 && t.Latitude.Length > 0), building => building.FBNameOfIndustrialPark,
                            poi => poi.PAddress, (building, poi) => poi).OrderBy(poi => poi.ord).ToList();
            }
        }
    }
}