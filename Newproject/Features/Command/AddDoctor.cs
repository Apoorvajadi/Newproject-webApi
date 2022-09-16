using MediatR;
using Newproject.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Newproject.Features.Command
{
    public class AddDoctor
    {
        public class Command: IRequest<int>
        {
            public string DoctorName{ get; set; }
            public string Gender { get; set; }
            public decimal Salary { get; set; }
        }
        public class CommandHadler : IRequestHandler<Command, int>
        {
            private readonly CEFContext _db;
            public CommandHadler(CEFContext db)
            {
                this._db = db;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = new TblDoctor
                {

                    DoctorName = request.DoctorName,
                    Gender = request.Gender,
                    Salary = request.Salary
                };
                await _db.TblDoctors.AddAsync(entity, cancellationToken);
                await _db.SaveChangesAsync(cancellationToken);
                return entity.Id;
            }
        }
    }
}
