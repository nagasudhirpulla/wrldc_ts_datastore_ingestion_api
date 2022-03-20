using Microsoft.AspNetCore.Mvc;
using TsDataStoreApi.Infra.BasicAuth;

namespace TsDataStoreApi.Controllers;
[Route("[controller]")]
[ApiController]
public class DataController : ControllerBase
{
    private readonly ILogger<DataController> _logger;

    public DataController(ILogger<DataController> logger)
    {
        _logger = logger;
    }

    [BasicAuth] // You can optionally provide a specific realm --> [BasicAuth("my-realm")]
    [HttpPost(Name = "InsertData")]
    public Task<bool> PostAsync(DataInsCommand d)
    {
        // TODO complete this
        // datetime string will be in the format of yyyy-MM-dd HH:mm:ss
        return Task.FromResult(true);
    }

    public class DataInsCommand
    {
        public string Ts { get; set; }
        public string MeasId { get; set; }
        public double Val { get; set; }

    }
}
