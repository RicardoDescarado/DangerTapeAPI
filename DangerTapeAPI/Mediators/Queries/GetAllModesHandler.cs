using DangerTapeAPI.Database.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DangerTapeAPI.Mediators.Queries
{
    public class GetAllModesRequest : IRequest<List<Database.Entities.Mode>>
    {

    }
    public class GetAllModesHandler : IRequestHandler<GetAllModesRequest, List<Database.Entities.Mode>>
    {
        public GetAllModesHandler()
        {

        }
        public async Task<List<Mode>> Handle(GetAllModesRequest request, CancellationToken cancellationToken)
        {
            var output = new List<Mode>
            {
                new Mode
                {
                    Id = 1,
                    Name = "Ionian"
                },
                new Mode
                {
                    Id = 2,
                    Name = "Dorian"
                },
                new Mode
                {
                    Id = 3,
                    Name = "Phrygian"
                }
            };

            return await Task.FromResult(output);
        }
    }
}