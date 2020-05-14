using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TorgObjects.DomainObjects;
using TorgObjects.ApplicationServices.GetTorgPointListUseCase;
using TorgObjects.InfrastructureServices.Presenters;

namespace TorgObjects.InfrastructureServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TorgPointsController : ControllerBase
    {
        private readonly ILogger<TorgPointsController> _logger;
        private readonly IGetTorgPointListUseCase _getTorgPointListUseCase;

        public TorgPointsController(ILogger<TorgPointsController> logger,
                                IGetTorgPointListUseCase getTorgPointListUseCase)
        {
            _logger = logger;
            _getTorgPointListUseCase = getTorgPointListUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTorgPoints()
        {
            var presenter = new TorgPointListPresenter();
            await _getTorgPointListUseCase.Handle(GetTorgPointListUseCaseRequest.CreateAllTorgPointsRequest(), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{TorgpointId}")]
        public async Task<ActionResult> GetTorgPoint(long TorgpointId)
        {
            var presenter = new TorgPointListPresenter();
            await _getTorgPointListUseCase.Handle(GetTorgPointListUseCaseRequest.CreateTorgPointRequest(TorgpointId), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("isTorghelpfree/{isTorghelpfree}")]
        public async Task<ActionResult> GetIsTorgHelpFreeTorgPoints(string isTorghelpfree)
        {
            var presenter = new TorgPointListPresenter();
            await _getTorgPointListUseCase.Handle(GetTorgPointListUseCaseRequest.CreateIsTorgHelpFreeTorgPointsRequest(isTorghelpfree), presenter);
            return presenter.ContentResult;
        }
    }
}
