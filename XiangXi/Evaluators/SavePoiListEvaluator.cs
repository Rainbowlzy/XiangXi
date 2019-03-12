using System.Collections.Generic;
using System.Linq;
using System.Text;
using XiangXi.Models;
using XiangXiENtities.EF;
using XiangXiENtities.EF.NewEntities;
using static Newtonsoft.Json.JsonConvert;

namespace XiangXi.Evaluators
{
    public class SavePoiListEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            var pois = DeserializeObject<List<Poi>>(request?.data);
            var builder = new StringBuilder();
            int i = 0;
            using (var ctx = new DefaultContext())
            {
                foreach (
                    var poi in
                        pois.Select(p => p.PAddress).SelectMany(addr => ctx.Poi.Where(p => p.PAddress == addr)))
                {
                    ctx.Poi.Remove(poi);
                    if (pois[pois.Count - 1].ord <= 0)
                    {
                        poi.ord = ++i;
                    }
                }
                ctx.SaveChanges();
                return new
                {
                    success = true,
                    message = "±£´æ³É¹¦",
                    response =
                        pois.Where(p => !string.IsNullOrEmpty(p.Latitude) && !string.IsNullOrEmpty(p.Longitude))
                            .AsParallel()
                            .Select(poi => Make(new CommonRequest
                            {
                                auth = request?.auth,
                                context = request?.context,
                                data = SerializeObject(poi),
                                method = "savepoievaluator"
                            }).Eval(new CommonRequest
                            {
                                auth = request?.auth,
                                context = request?.context,
                                data = SerializeObject(poi),
                                method = "savepoievaluator"
                            }))
                            .ToList()
                };
            }
        }
    }
}