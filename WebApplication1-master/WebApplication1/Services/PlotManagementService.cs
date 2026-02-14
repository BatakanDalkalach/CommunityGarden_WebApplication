using Microsoft.EntityFrameworkCore;
using WebApplication1.DatabaseContext;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class PlotManagementService
    {
        private readonly CommunityGardenDatabase _database;

        public PlotManagementService(CommunityGardenDatabase database)
        {
            _database = database;
        }

        public async Task<List<GardenPlot>> RetrieveAllPlotsAsync()
        {
            return await _database.GardenPlots
                .Include(plot => plot.CurrentTenant)
                .OrderBy(plot => plot.PlotDesignation)
                .ToListAsync();
        }

        public async Task<GardenPlot?> FindPlotByIdentifierAsync(int identifier)
        {
            return await _database.GardenPlots
                .Include(plot => plot.CurrentTenant)
                .FirstOrDefaultAsync(plot => plot.PlotIdentifier == identifier);
        }

        public async Task<GardenPlot> RegisterNewPlotAsync(GardenPlot plot)
        {
            _database.GardenPlots.Add(plot);
            await _database.SaveChangesAsync();
            return plot;
        }

        public async Task ModifyPlotDetailsAsync(GardenPlot plot)
        {
            _database.Entry(plot).State = EntityState.Modified;
            try
            {
                await _database.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CheckPlotExistsAsync(plot.PlotIdentifier))
                {
                    throw new InvalidOperationException("Plot not found");
                }
                throw;
            }
        }

        public async Task RemovePlotAsync(int identifier)
        {
            var plotToRemove = await _database.GardenPlots.FindAsync(identifier);
            if (plotToRemove != null)
            {
                _database.GardenPlots.Remove(plotToRemove);
                await _database.SaveChangesAsync();
            }
        }

        public async Task<bool> CheckPlotExistsAsync(int identifier)
        {
            return await _database.GardenPlots.AnyAsync(p => p.PlotIdentifier == identifier);
        }

        public async Task<List<GardenPlot>> GetVacantPlotsAsync()
        {
            return await _database.GardenPlots
                .Where(plot => !plot.IsOccupied)
                .OrderBy(plot => plot.PlotDesignation)
                .ToListAsync();
        }
    }
}
