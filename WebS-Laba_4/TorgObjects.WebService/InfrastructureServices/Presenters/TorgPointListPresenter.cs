using TorgObjects.ApplicationServices.GetTorgPointListUseCase;
using System.Net;
using Newtonsoft.Json;
using TorgObjects.ApplicationServices.Ports;

namespace TorgObjects.InfrastructureServices.Presenters
{
    public class TorgPointListPresenter : IOutputPort<GetTorgPointListUseCaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public TorgPointListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetTorgPointListUseCaseResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = response.Success ? JsonConvert.SerializeObject(response.TorgPoints) : JsonConvert.SerializeObject(response.Message);
        }
    }
}
