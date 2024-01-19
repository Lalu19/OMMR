using AdminClient.DTO;
using AdminClient.Model.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminClient.Model.AgentFeedbackForm
{
    public class AgentFeedbackFormProvider : IAgentFeedbackForm
    {
        IHttpWebClients _objIHttpWebClients;
        public AgentFeedbackFormProvider(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }

        public AgentFeedbackFormViewModel AgentFeedbackFormCreate(AgentFeedbackFormNewDTO agentFeedbackFormNewDTO)
        {
            try
            {
                AgentFeedbackFormViewModel objupdateResults = new AgentFeedbackFormViewModel();
                objupdateResults = JsonConvert.DeserializeObject<AgentFeedbackFormViewModel>(_objIHttpWebClients.PostRequest("/api/AdScreenFeedbackForm/AdScreenFeedbackFormCreate", JsonConvert.SerializeObject(agentFeedbackFormNewDTO), true));
                return objupdateResults;
            }
            catch (Exception)
            {
                throw;

            }
        }
    }
}
