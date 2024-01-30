using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;

namespace Dataverse;

class Connect{
    public static ServiceClient GetService(string url){
        string connectionString = $"AuthType=OAuth;Url={url};RedirectUri=http://localhost;LoginPrompt=Auto";
        ServiceClient svc = new(connectionString);
        return svc;
    }
}

public class CreateEntity{
    public static Entity CenterDay(string locid, string yyyymmdd, string total){
        var record = new Entity("crff9_centerday");

        // convert to datetime
        var year = yyyymmdd[..4];
        var month = yyyymmdd.Substring(4, 2);
        var day = yyyymmdd.Substring(6, 2);
        var date = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));

        record["crff9_locid"] = locid;
        record["crff9_yyyymmdd"] = yyyymmdd;
        record["crff9_total"] = total;
        record["crff9_date"] = date;

        return record;
    }
}