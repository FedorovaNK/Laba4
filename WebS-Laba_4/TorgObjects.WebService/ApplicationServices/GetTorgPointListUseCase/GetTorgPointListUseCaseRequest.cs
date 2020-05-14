using TorgObjects.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace TorgObjects.ApplicationServices.GetTorgPointListUseCase
{
    public class GetTorgPointListUseCaseRequest : IUseCaseRequest<GetTorgPointListUseCaseResponse>
    {
        public string IsPechatProduct { get; private set; }
        public long? TorgPointId { get; private set; }

        private GetTorgPointListUseCaseRequest()
        { }

        public static GetTorgPointListUseCaseRequest CreateAllTorgPointsRequest()
        {
            return new GetTorgPointListUseCaseRequest();
        }

        public static GetTorgPointListUseCaseRequest CreateTorgPointRequest(long TorgpointId)
        {
            return new GetTorgPointListUseCaseRequest() { TorgPointId = TorgpointId };
        }
        public static GetTorgPointListUseCaseRequest CreateIsPechatProductTorgPointsRequest(string isPechatProduct)
        {
            return new GetTorgPointListUseCaseRequest() { IsPechatProduct = isPechatProduct };
        }
    }
}
