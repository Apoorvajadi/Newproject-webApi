using MediatR;
using Newproject.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Newproject.Features.Queries
{
    public class GetDoctorById
    {
        public class Query: IRequest<TblDoctor>
        {
            public int Id { get; set; }
        }
        public class QueryHandler : IRequestHandler<Query, TblDoctor>
        {
            private readonly CEFContext _db;
            public QueryHandler(CEFContext db)
            {
                this._db = db;
            }

            public async Task<TblDoctor> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _db.TblDoctors.FindAsync(request.Id);
            }
        }
    }
}
