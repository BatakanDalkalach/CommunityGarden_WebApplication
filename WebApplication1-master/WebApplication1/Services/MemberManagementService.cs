using Microsoft.EntityFrameworkCore;
using WebApplication1.DatabaseContext;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class MemberManagementService
    {
        private readonly CommunityGardenDatabase _database;

        public MemberManagementService(CommunityGardenDatabase database)
        {
            _database = database;
        }

        public async Task<List<GardenMember>> RetrieveAllMembersAsync()
        {
            return await _database.GardenMembers
                .Include(member => member.ManagedPlots)
                .OrderBy(member => member.FullLegalName)
                .ToListAsync();
        }

        public async Task<GardenMember?> FindMemberByIdAsync(int memberId)
        {
            return await _database.GardenMembers
                .Include(member => member.ManagedPlots)
                .Include(member => member.RecordedHarvests)
                .FirstOrDefaultAsync(member => member.MemberId == memberId);
        }

        public async Task<GardenMember> EnrollNewMemberAsync(GardenMember member)
        {
            _database.GardenMembers.Add(member);
            await _database.SaveChangesAsync();
            return member;
        }

        public async Task<List<GardenMember>> SearchByMembershipTypeAsync(string tier)
        {
            return await _database.GardenMembers
                .Where(m => m.MembershipTier == tier)
                .OrderBy(m => m.FullLegalName)
                .ToListAsync();
        }
    }
}
