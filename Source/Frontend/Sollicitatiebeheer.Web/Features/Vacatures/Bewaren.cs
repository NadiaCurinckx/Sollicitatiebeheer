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
                if(message.BewaarMethode == BewaarMethode.Nieuw)
                {
                    _db.Add(message.Vacature);
                    _db.SaveChanges();
                }

                return new Response();
            }
        }

        public class Request : IRequest<Response>
        {
            public BewaarMethode BewaarMethode { get; set; }
            public Vacature Vacature { get; set; }
        }
        public class Response
        {
        }

        public enum BewaarMethode
        {
            Bewerken,
            Nieuw         
        }
    }
}
