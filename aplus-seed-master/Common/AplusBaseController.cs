using aplus_back_seed.Interfaces;
using Microsoft.AspNetCore.Mvc;

public class AplusBasedController : ControllerBase
{
    protected IAplusSample _sample;
    protected readonly ILogger<AplusBasedController> _logger;
    protected IAplusDataAccesses _data;
    public AplusBasedController(IAplusSample sample,ILogger<AplusBasedController> logger, IAplusDataAccesses data){
        _sample = sample;
        _logger = logger;
        _data = data;
    }
}