using API.Entities;

namespace API.Services.Interfaces;

public interface IAppSettingService
{
    Task<PagedList<AppSetting>> GetPagedAppSettingsAsync(int pageNumber, int pageSize);
    Task<AppSetting?> GetAppSettingAsync(int id);
    Task UpdateAppSettingAsync(AppSetting appSetting);
}
