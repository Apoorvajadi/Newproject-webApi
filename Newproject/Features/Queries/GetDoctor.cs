using MediatR;
using Microsoft.EntityFrameworkCore;
using Newproject.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Newproject.Features.Queries
{
    public class GetDoctor
    {
        public class Query : IRequest<IEnumerable<TblDoctor>> { }
        public class QueryHandler : IRequestHandler<Query, IEnumerable<TblDoctor>>
        {
            private readonly CEFContext _db;
            public QueryHandler(CEFContext db)
            {
                _db = db;
            }
            public async Task<IEnumerable<TblDoctor>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _db.TblDoctors.ToListAsync(cancellationToken);
            }
        }
    }
}
