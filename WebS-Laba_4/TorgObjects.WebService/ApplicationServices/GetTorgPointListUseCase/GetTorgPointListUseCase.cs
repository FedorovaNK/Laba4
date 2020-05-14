using System.Threading.Tasks;
using System.Collections.Generic;
using TorgObjects.DomainObjects;
using TorgObjects.DomainObjects.Ports;
using TorgObjects.ApplicationServices.Ports;

namespace TorgObjects.ApplicationServices.GetTorgPointListUseCase
{
    public class GetTorgPointListUseCase : IGetTorgPointListUseCase
    {
        private readonly IReadOnlyTorgPointRepository _readOnlyTorgPointRepository;

        public GetTorgPointListUseCase(IReadOnlyTorgPointRepository readOnlyTorgPointRepository) 
            => _readOnlyTorgPointRepository = readOnlyTorgPointRepository;

        public async Task<bool> Handle(GetTorgPointListUseCaseRequest request, IOutputPort<GetTorgPointListUseCaseResponse> outputPort)
        {
            IEnumerable<TorgPoint> Torgpoints = null;
            if (request.TorgPointId != null)
            {
                var Torgpoint = await _readOnlyTorgPointRepository.GetTorgPoint(request.TorgPointId.Value);
                Torgpoints = (Torgpoint != null) ? new List<TorgPoint>() { Torgpoint } : new List<TorgPoint>();
                
            }
            else if (request.IsPechatProduct != null)
            {
                Torgpoints = await _readOnlyTorgPointRepository.QueryTorgPoints(new IsPechatProductCriteria(request.IsPechatProduct));
            }
            else
            {
                Torgpoints = await _readOnlyTorgPointRepository.GetAllTorgPoints();
            }
            outputPort.Handle(new GetTorgPointListUseCaseResponse(Torgpoints));
            return true;
        }
    }
}
