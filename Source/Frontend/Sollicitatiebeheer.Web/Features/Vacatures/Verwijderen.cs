using MediatR;
using Sollicitatiebeheer.Web.Infrastructure.Handlers;
using System;
using Sollicitatiebeheer.Data.EFCore;
using System.Linq;

namespace Sollicitatiebeheer.Web.Features.Vacatures
{
    public class Verwijderen
    {
        public class Handler : DbRequestHandler<Request, Response>
        {
            public Handler(ISollicitatiebeheerContext sollicitatiebeheerContext) : base(sollicitatiebeheerContext)
            {
            }

            public override Response Handle(Request message)
            {
                var vacature = _db.Vacatures.SingleOrDefault(v => v.Id == message.Id);
                _db.Delete(vacature);
                _db.SaveChanges();

                return new Response();
            }
        }

        public class Request : IRequest<Response>
        {
            public Guid Id { get; set; }
        }
        public class Response { }
    }
}
