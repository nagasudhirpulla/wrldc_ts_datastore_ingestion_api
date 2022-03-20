using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using TsDataStoreApi.Infra.BasicAuth;
using TsDataStoreApi.Infra.Persistence;

namespace TsDataStoreApi.Controllers;
[Route("[controller]")]
[ApiController]
public class DataController : ControllerBase
{
    private readonly ILogger<DataController> _logger;
    private readonly ITsDataStore _tsDataStore;

    public DataController(ILogger<DataController> logger, ITsDataStore tsDataStore)
    {
        _logger = logger;
        _tsDataStore = tsDataStore;
    }

    [BasicAuth] // You can optionally provide a specific realm --> [BasicAuth("my-realm")]
    [HttpPost(Name = "InsertData")]
    public async Task<bool> PostAsync(DataInsCommand d)
    {
        // datetime should be in yyyy-MM-dd HH:mm:ss format
        var ts = DateTime.ParseExact(d.Ts ?? "", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        bool isOk = await _tsDataStore.Insert(ts, d.MeasId ?? "", d.Val);
        return isOk;
    }

    public class DataInsCommand
    {
        public string? Ts { get; set; }
        public string? MeasId { get; set; }
        public double Val { get; set; }

    }
}
