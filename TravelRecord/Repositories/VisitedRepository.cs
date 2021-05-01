using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TravelRecord.Model;
using TravelRecord.Repository.IRepsitory;

namespace TravelRecord.Repository
{
    class VisitedRepository : Repository<Visited>, IVisitedRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        public VisitedRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

    }
}
