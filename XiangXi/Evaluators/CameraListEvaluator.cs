using System.Data.Entity.Core.Objects;
using System.Linq;
using XiangXi.Models;
using XiangXiENtities.EF;

namespace XiangXi.Evaluators
{
    public class CameraListEvaluator : Evaluator
    {
        protected override object Evaluate(CommonRequest request)
        {
            using (var ctx = new DefaultContext())
            {
                //var list = ctx.VideoPointInformation
                //    //.Where(p => EntityFunctions.Like(entity.search, p.BIOVSAddress))
                //    .ToList();
                //list.ForEach(p => p.BIOVSPersonalNumber = string.Format("https://open8200.hikvision.com:443/artemis/api/common/v1/userAuthRestService/getUserByUsername  {0}", p.BIOVSPersonalNumber));
                // http://122.193.18.104:83/pag/172.28.1.2/7302/32058488001310012504/0/MAIN/TCP/live.m3u8
                // http://122.193.18.104:83/pag/172.28.1.2/7302/{0}/0/MAIN/TCP/live.m3u8
                // http://122.193.16.161:83/pag/10.11.1.4/7302/{p.BIOVSPersonalNumber}/0/MAIN/TCP/live.m3u8
                // TODO 这里给出了示例地址
                //list.ForEach(p => p.BIOVSPersonalNumber =
                //    //$"http://122.193.16.161:83/pag/10.11.1.4/7302/{p.BIOVSPersonalNumber}/0/MAIN/TCP/live.m3u8");
                //    // rtsp://122.193.16.161:554/pag://10.11.1.4:7302:32050690001310015435:0:MAIN:TCP
                //    $"rtsp://122.193.16.161:554/pag://10.11.1.4:7302:{p.BIOVSPersonalNumber}:0:MAIN:TCP");

                string vPBIAddress = request.data.Deserialize<VideoPointInformationSearchModel>()?.VPIAddress;
                return ctx.VideoPointInformation
                    .Where(t => t.VPIAddress.Contains(vPBIAddress))
                    .ToList()
                    .Select(p => new
                {
                    name = p.VPISerialNumber,
                    url = $"rtsp://122.193.16.161:554/pag://10.11.1.4:7302:{p.VPISerialNumber}:0:MAIN:TCP",
                    position = p.VPIAddress
                }).ToList();
            }
        }
    }
}