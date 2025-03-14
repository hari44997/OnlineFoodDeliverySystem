﻿using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Serivces
{
    public interface IAgentService
    {
        Task<IEnumerable<Agent>> GetAllAgentsAsync();
        Task<Agent> GetAgentByIdAsync(int id);
        Task AddAgentAsync(Agent agent);
        Task UpdateAgentAsync(int id, Agent agent);
        Task DeleteAgentAsync(int id);
    }
}
