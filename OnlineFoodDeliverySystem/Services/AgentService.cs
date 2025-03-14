using Microsoft.EntityFrameworkCore;
using OnlineFoodDeliverySystem.Exceptions;
using OnlineFoodDeliverySystem.Models;
using OnlineFoodDeliverySystem.Repository;

namespace OnlineFoodDeliverySystem.Services
{
    public class AgentService : IAgentService
    {
        private readonly IAgentRepository _agentRepository;

        public AgentService(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }
        public async Task AddAgentAsync(Agent agent)
        {
            await _agentRepository.AddAgentAsync(agent);
        }

        public async Task DeleteAgentAsync(int id)
        {
            Agent deleteAgent = await _agentRepository.GetAgentByIdAsync(id);
            if(deleteAgent == null)
            {
                throw new NotFoundException($"Agent wiht id {id} does not exists");
            }
            await _agentRepository.DeleteAgentAsync(id);
        }

        public async Task<Agent> GetAgentByIdAsync(int id)
        {
            var getagent = await _agentRepository.GetAgentByIdAsync(id);
            if(getagent == null)
            {
                throw new NotFoundException($"Agent with id {id} does not exists");
            }
            return getagent;
        }

        public async Task<IEnumerable<Agent>> GetAllAgentsAsync()
        {
            var getallagents = await _agentRepository.GetAllAgentsAsync();
            return getallagents.ToList();
        }

        public async Task UpdateAgentAsync(int id, Agent agent)
        {
            Agent updateAgent = await _agentRepository.GetAgentByIdAsync(id);
            if (updateAgent == null)
            {
                throw new NotFoundException($"Agent wiht id {id} does not exists");
            }
            await _agentRepository.UpdateAgentAsync(id, agent);
        }
    }
}
