using API.Data;
using API.Entities;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class AppSettingsController : ControllerBase
{
    private readonly IAppSettingService _appSettingService;

    public AppSettingsController(IAppSettingService appSettingService)
    {
        _appSettingService = appSettingService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAppSettings(int pageNumber = 1, int pageSize = 10)
    {
        int maxPageSize = 50;
        
        if (pageNumber < 1 || pageSize < 1)
        {
            return BadRequest("Invalid page number or page size.");
        }
        if (pageSize > maxPageSize)
        {
            pageSize = maxPageSize;
        }

        var pagedAppSettings = await _appSettingService.GetPagedAppSettingsAsync(pageNumber, pageSize);
        return Ok(pagedAppSettings);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAppSetting(int id)
    {
        var appSetting = await _appSettingService.GetAppSettingAsync(id);

        if (appSetting == null)
        {
            return NotFound();
        }

        return Ok(appSetting);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAppSetting(int id, AppSetting appSetting)
    {
        if (id != appSetting.Id)
        {
            return BadRequest("Id mismatch in request body and URL.");
        }

        try
        {
            await _appSettingService.UpdateAppSettingAsync(appSetting);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (await _appSettingService.GetAppSettingAsync(id) == null)
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }

        return NoContent();
    }
}
