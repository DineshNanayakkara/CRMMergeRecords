using ErrorHandling;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Client;
using Microsoft.Xrm.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Url=https://dynamicscrmnext.crm5.dynamics.com; Username=dineshn@dynamicscrmnext.onmicrosoft.com; Password=P@$$w0rd1;";
            Microsoft.Xrm.Client.CrmConnection connection = CrmConnection.Parse(connectionString);

            try
            {
                using (OrganizationService orgService = new OrganizationService(connection))
                {
                    CrmEntityReference target = new CrmEntityReference();
                    target.Id = new Guid("AAD1D9DD-7B98-E411-80D6-C4346BADB628");
                    target.LogicalName = Incident.EntityLogicalName;

                    MergeRequest mergeRequest = new MergeRequest();
                    mergeRequest.SubordinateId = new Guid("ACD1D9DD-7B98-E411-80D6-C4346BADB628");                    
                    mergeRequest.Target = target;
                    mergeRequest.PerformParentingChecks = false;

                    Incident incidentUpdate = new Incident();
                    incidentUpdate.Title = "Merged2";

                    mergeRequest.UpdateContent = incidentUpdate;

                    MergeResponse mergeResponse = (MergeResponse)orgService.Execute(mergeRequest);
                    string s = "";
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
