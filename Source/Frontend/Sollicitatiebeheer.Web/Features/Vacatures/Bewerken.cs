using MediatR;
using Sollicitatiebeheer.Web.Infrastructure.Handlers;
using System;
using Sollicitatiebeheer.Data.EFCore;
using System.Linq;
using Sollicitatiebeheer.Model.Vacatures;

namespace Sollicitatiebeheer.Web.Features.Vacatures
{
    public class Bewerken
    {
        public class Handler : DbRequestHandler<Request, Response>
        {
            public Handler(ISollicitatiebeheerContext sollicitatiebeheerContext) : base(sollicitatiebeheerContext)
            {
            }

            public override Response Handle(Request message)
            {
                var vacature = _db.Vacatures.SingleOrDefault(v => v.Id == message.Id);
                
                return new Response
                {
                    Vacature = vacature
                };
            }
        }

        public class Request : IRequest<Response>
        {
            public Guid Id { get; set; }
        }
        public class Response
        {
            public Vacature Vacature { get; set; }
        }
    }
}
