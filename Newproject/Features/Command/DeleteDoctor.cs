using MediatR;
using Newproject.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Newproject.Features.Command
{
    public class DeleteDoctor
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
        }
        public class CommandHandler: IRequestHandler<Command, Unit>
        {
            private readonly CEFContext _db;
            public CommandHandler(CEFContext db) => _db = db;
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var doctor = await _db.TblDoctors.FindAsync(request.Id);
                if (doctor == null) return Unit.Value;
                _db.TblDoctors.Remove(doctor);
                await _db.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
