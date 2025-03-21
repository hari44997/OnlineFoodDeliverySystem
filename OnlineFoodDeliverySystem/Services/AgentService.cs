using OnlineFoodDeliverySystem.Exceptions;
using OnlineFoodDeliverySystem.Models;
using OnlineFoodDeliverySystem.Repository;

namespace OnlineFoodDeliverySystem.Services
{
    public class AgentService:IAgentService
    {
        private readonly IAgentRepository _agentRepository;
        private readonly IOrderRepository _orderRepository;

        public AgentService(IAgentRepository agentRepository, IOrderRepository orderRepository)
        {
            _agentRepository = agentRepository;
            _orderRepository = orderRepository;
        }
        public async Task AddAgentAsync(Agent agent)
        {
            await _agentRepository.AddAgentAsync(agent);
        }

        public async Task DeleteAgentAsync(int id)
        {
            Agent deleteAgent = await _agentRepository.GetAgentByIdAsync(id);
            if (deleteAgent == null)
            {
                throw new NotFoundException($"Agent with id {id} does not exist");
            }
            await _agentRepository.DeleteAgentAsync(id);
        }

        public async Task<Agent> GetAgentByIdAsync(int id)
        {
            var getAgent = await _agentRepository.GetAgentByIdAsync(id);
            if (getAgent == null)
            {
                throw new NotFoundException($"Agent with id {id} does not exist");
            }
            return getAgent;
        }

        public async Task<IEnumerable<Agent>> GetAllAgentsAsync()
        {
            var getAllAgents = await _agentRepository.GetAllAgentsAsync();
            return getAllAgents.ToList();
        }

        public async Task UpdateAgentAsync(int id, Agent agent)
        {
            Agent updateAgent = await _agentRepository.GetAgentByIdAsync(id);
            if (updateAgent == null)
            {
                throw new NotFoundException($"Agent with id {id} does not exist");
            }
            await _agentRepository.UpdateAgentAsync(id, agent);
        }

        public async Task AssignAgentToOrderAsync(int agentId, int orderId)
        {
            var agent = await _agentRepository.GetAgentByIdAsync(agentId);
            if (agent == null)
            {
                throw new NotFoundException($"Agent with id {agentId} does not exist");
            }

            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            if (order == null)
            {
                throw new NotFoundException($"Order with id {orderId} does not exist");
            }

            await _agentRepository.AssignAgentToOrderAsync(agentId, orderId);
        }
    }
}