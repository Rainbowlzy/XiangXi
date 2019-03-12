using System.Linq;
using XiangXi.Models;
using XiangXiENtities.EF;

namespace XiangXi.Evaluators
{
    /// <summary>
    /// 查询监控点位列表
    /// </summary>
    [CacheOptions(Timeout = 50000)]
    public class MapQueryCameraEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                return ctx.VideoPointInformation
                    .Join(ctx.Poi
                            .Where(p => p.PAddress != null && p.Longitude != null && p.Latitude != null)
                            .GroupBy(t => t.PAddress)
                            .Select(t => t.FirstOrDefault())
                            .OrderBy(poi => poi.ord),
                        video => video.VPIAddress,
                        poi => poi.PAddress, (videoPointBitInformation, poi) => new
                        {
                            videoPointBitInformation.VPISerialNumber,
                            poi.Longitude,
                            poi.Latitude,
                            poi.PAddress,
                            poi.ord
                        }).ToList().Select(k => new
                    {
                        url =
                            $"rtsp://122.193.16.161:554/pag://10.11.1.4:7302:{k.VPISerialNumber}:0:MAIN:TCP",
                        k.Longitude,
                        k.Latitude,
                        k.PAddress,
                        k.ord
                    });
            }
        }
    }
    [CacheOptions(Timeout = 50000)]
    public class MapQueryNewCameraEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                return ctx.VideoPointInformation
                    .Join(ctx.Poi
                            .Where(p => p.PAddress != null && p.Longitude != null && p.Latitude != null)
                            .GroupBy(t => t.PAddress)
                            .Select(t => t.FirstOrDefault())
                            .OrderBy(poi => poi.ord),
                        video => video.VPIAddress,
                        poi => poi.PAddress, (videoPointBitInformation, poi) => new
                        {
                            videoPointBitInformation.VPISerialNumber,
                            poi.Longitude,
                            poi.Latitude,
                            poi.PAddress,
                            poi.ord
                        }).ToList().Select(k => new
                    {
                        url =
                            $"http://122.193.16.161:83/pag/10.11.1.4/7302/{k.VPISerialNumber}/0/SUB/TCP/live.m3u8",
                        k.Longitude,
                        k.Latitude,
                        k.PAddress,
                        k.ord
                    });

            }
        }
    }
}