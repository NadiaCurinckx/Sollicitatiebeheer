using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using Sollicitatiebeheer.Data.EFCore;
using Sollicitatiebeheer.Model.Afdelingen;
using Sollicitatiebeheer.Model.Vacatures;
using Sollicitatiebeheer.Web.Infrastructure.Handlers;

namespace Sollicitatiebeheer.Web.Features.Vacatures {
    public class Toevoegen {
        public class Handler : DbRequestHandler<Request, Response> {
            public Handler(ISollicitatiebeheerContext sollicitatiebeheerContext) : base(sollicitatiebeheerContext) {
            }

            public override Response Handle(Request message) {
                return new Response {
                    Vacature = new VacatureBuilder().Build(),
                    GeselecteerdeAfdeling = _db.Afdelingen.First().Id.ToString(),
                    Afdelingen = _db.Afdelingen.ToList()
                };
            }
        }

        public class Request : IRequest<Response> {

        }
        public class Response : VacatureDetail {
        }
    }
}
