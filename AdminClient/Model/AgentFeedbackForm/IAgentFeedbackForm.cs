using AdminClient.DTO;

namespace AdminClient.Model.AgentFeedbackForm
{
    public interface IAgentFeedbackForm
    {
        public AgentFeedbackFormViewModel AgentFeedbackFormCreate(AgentFeedbackFormNewDTO agentFeedbackFormNewDTO);
    }
}
