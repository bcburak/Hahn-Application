using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.July2021.Domain.Constants;

namespace Hahn.ApplicatonProcess.July2021.Domain.Services
{
    public class AssetService : IAssetService
    {
        public AssetService()
        {

        }

        public object GetAllAssets()
        {
            var json = new WebClient().DownloadString(Domain.Constants.Constants.assetUrl);
            var des = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            return des;
        }
    }
}
