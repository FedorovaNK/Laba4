using TorgObjects.DomainObjects;
using TorgObjects.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace TorgObjects.ApplicationServices.GetTorgPointListUseCase
{
    public class GetTorgPointListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<TorgPoint> TorgPoints { get; }

        public GetTorgPointListUseCaseResponse(IEnumerable<TorgPoint> Torgpoints) => TorgPoints = Torgpoints;
    }
}
