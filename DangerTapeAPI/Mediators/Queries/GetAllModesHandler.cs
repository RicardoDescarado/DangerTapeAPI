using DangerTapeAPI.Database.Entities;
using DangerTapeAPI.Database.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DangerTapeAPI.Mediators.Queries
{
    public class GetAllModesRequest : IRequest<List<Mode>>
    {

    }
    public class GetAllModesHandler : IRequestHandler<GetAllModesRequest, List<Mode>>
    {
        private readonly IRepository<Mode> _repository;
        public GetAllModesHandler(IRepository<Mode> repository)
        {
            _repository = repository;
        }
        public async Task<List<Mode>> Handle(GetAllModesRequest request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll().ToListAsync(cancellationToken);
        }
    }
}