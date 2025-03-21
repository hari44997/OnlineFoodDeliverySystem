using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Repository
{
    public interface IAgentRepository
    {
        Task<IEnumerable<Agent>> GetAllAgentsAsync();
        Task<Agent> GetAgentByIdAsync(int id);
        Task AddAgentAsync(Agent agent);
        Task UpdateAgentAsync(int id, Agent agent);
        Task DeleteAgentAsync(int id);
        Task AssignAgentToOrderAsync(int agentId, int orderId);
    }
}
