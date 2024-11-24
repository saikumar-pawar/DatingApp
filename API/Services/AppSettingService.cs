using API.Data;
using API.Entities;
using API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace API.Services;

public class AppSettingService : IAppSettingService
{
    private readonly DataContext _context;

    public AppSettingService(DataContext context)
    {
        _context = context;
    }

    public async Task<PagedList<AppSetting>> GetPagedAppSettingsAsync(int pageNumber, int pageSize)
    {
        var query = _context.AppSettings.AsQueryable();
        var totalItemCount = await query.CountAsync();
        var appSettings = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PagedList<AppSetting>(appSettings, totalItemCount, pageNumber, pageSize);
    }

    public async Task<AppSetting?> GetAppSettingAsync(int id)
    {
        return await _context.AppSettings.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task UpdateAppSettingAsync(AppSetting appSetting)
    {
        _context.Entry(appSetting).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
