using System;
using MediatR;
using Sollicitatiebeheer.Data.EFCore;
using Sollicitatiebeheer.Model.Afdelingen;
using Sollicitatiebeheer.Model.Vacatures;
using Sollicitatiebeheer.Web.Infrastructure.Handlers;

namespace Sollicitatiebeheer.Web.Features.Vacatures {
    public class Bewaren {
        public class Handler : DbRequestHandler<Request, Response> {
            public Handler(ISollicitatiebeheerContext sollicitatiebeheerContext) : base(sollicitatiebeheerContext) {
            }

            public override Response Handle(Request message) {
                var vacature = message.Vacature;

                vacature.AfdelingId = message.AfdelingId;

                if (vacature.Id.Equals(Guid.Empty)) {
                    _db.Add(vacature);
                } else {
                    _db.Update(vacature);
                }

                _db.SaveChanges();

                return new Response();
            }
        }

        public class Request : IRequest<Response> {
            public Vacature Vacature { get; set; }
            public int AfdelingId { get; set; }
        }
        public class Response {
        }
    }
}
