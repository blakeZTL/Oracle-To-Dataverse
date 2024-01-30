using Dataverse;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Oracle.ManagedDataAccess.Client;

#region Oracle Variables

string userId = "JAMES_B_BRADFORD";
string? password = Environment.GetEnvironmentVariable("OPS_NET");
if (password == null)
{
    Console.WriteLine("Password not found in environment variables.");
    Console.WriteLine("Please enter password:");
    password = Console.ReadLine();
}
string db = "10.23.22.30:1521/nasdw_users";
string command = "SELECT LOCID, YYYYMMDD, TOTAL FROM OPSNET.CENTER_DAY WHERE LOCID = 'ZTL'";

string connectionString =
    "Data Source=" + db + ";User Id=" + userId + ";Password=" + password + ";";

#endregion

#region Dataverse Variables 

string url = "https://orgd6accc40.crm9.dynamics.com";
string entityName = "crff9_centerday";

#endregion

EntityCollection newRecords = new();
using (OracleConnection conn = new(connectionString))
{
    using OracleCommand cmd = conn.CreateCommand();
    using ServiceClient service = Connect.GetService(url);
    try
    {
        conn.Open();
        cmd.CommandText = command;
        OracleDataReader reader = cmd.ExecuteReader();
        Console.WriteLine("Reading data...");
        while (reader.Read())
        {
            Entity record = CreateEntity.CenterDay(
                reader.GetString(0),
                reader.GetString(1),
                reader.GetString(2)
            );
            newRecords.Entities.Add(record);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        if (newRecords.Entities.Count > 0)
        {
            var totalRecords = newRecords.Entities.Count;
            Console.WriteLine($"Creating records ({totalRecords})...");
            newRecords.EntityName = entityName;
            int batchSize = 1000;
            for (int i = 0; i < newRecords.Entities.Count; i += batchSize)
            {
                EntityCollection batch = new() { EntityName = entityName };
                for (int j = i; j < Math.Min(i + batchSize, newRecords.Entities.Count); j++)
                {
                    batch.Entities.Add(newRecords.Entities[j]);
                }
                CreateMultipleRequest createRequest = new() { Targets = batch };
                CreateMultipleResponse createResponse = (CreateMultipleResponse)
                    service.Execute(createRequest);
                Console.WriteLine(
                    "Records created: " + i.ToString() + " of " + totalRecords.ToString()
                );
            }
        }
        conn.Close();
    }
}
