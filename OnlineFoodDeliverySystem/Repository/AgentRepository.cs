using Microsoft.EntityFrameworkCore;
using OnlineFoodDeliverySystem.Data;
using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Repository
{
    public class AgentRepository : IAgentRepository
    {
        private readonly FoodDbContext _context;

        public AgentRepository(FoodDbContext context)
        {
            _context = context;
        }

        public async Task AddAgentAsync(Agent agent)
        {
            await _context.Agents.AddAsync(agent);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAgentAsync(int id)
        {
            var agentToDelete = await _context.Agents.FindAsync(id);
            if (agentToDelete != null)
            {
                _context.Agents.Remove(agentToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Agent> GetAgentByIdAsync(int id)
        {
            return await _context.Agents.FindAsync(id);
        }

        public async Task<IEnumerable<Agent>> GetAllAgentsAsync()
        {
            return await _context.Agents.ToListAsync();
        }

        public async Task UpdateAgentAsync(int id, Agent agent)
        {
            var agentToUpdate = await _context.Agents.FindAsync(id);
            if (agentToUpdate != null)
            {
                agentToUpdate.Name = agent.Name;
                agentToUpdate.Phone = agent.Phone;
                agentToUpdate.RoleID = agent.RoleID;
                _context.Agents.Update(agentToUpdate);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AssignAgentToOrderAsync(int agentId, int orderId)
        {
            var agent = await _context.Agents.FindAsync(agentId);
            var order = await _context.Orders.FindAsync(orderId);

            if (agent != null && order != null)
            {
                order.AgentID = agentId;
                _context.Orders.Update(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}