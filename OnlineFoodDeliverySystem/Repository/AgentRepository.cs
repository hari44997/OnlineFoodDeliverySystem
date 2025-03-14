using Microsoft.AspNetCore.Components.Forms;
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
            var deleteAgent = await _context.Agents.FindAsync(id);
            if (deleteAgent != null)
            {
                _context.Agents.Remove(deleteAgent);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Agent> GetAgentByIdAsync(int id)
        {
            var getagent = await _context.Agents.FindAsync(id);
            return getagent;
        }

        public async Task<IEnumerable<Agent>> GetAllAgentsAsync()
        {
            return await _context.Agents.ToListAsync();
        }

        public async Task UpdateAgentAsync(int id, Agent agent)
        {
            var Updateagent = await _context.Agents.FindAsync(id);
            Updateagent.Name = agent.Name;
            Updateagent.Rating = agent.Rating;
            _context.Agents.Update(Updateagent);
            await _context.SaveChangesAsync();
        }
    }
}
