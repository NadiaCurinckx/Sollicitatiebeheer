using System;
using MediatR;
using Sollicitatiebeheer.Data.EFCore;
using Sollicitatiebeheer.Model.Vacatures;
using Sollicitatiebeheer.Web.Infrastructure.Handlers;

namespace Sollicitatiebeheer.Web.Features.Vacatures
{
    public class Bewaren
    {
        public class Handler : DbRequestHandler<Request, Response>
        {
            public Handler(ISollicitatiebeheerContext sollicitatiebeheerContext) : base(sollicitatiebeheerContext)
            {
            }

            public override Response Handle(Request message)
            {                
                _db.Add(message.Vacature);
                _db.SaveChanges();                

                return new Response();
            }
        }

        public class Request : IRequest<Response>
        {            
            public Vacature Vacature { get; set; }
        }
        public class Response
        {
        }        
    }
}
