using MediatR;
using Sollicitatiebeheer.Web.Infrastructure.Handlers;
using System;
using System.Collections.Generic;
using Sollicitatiebeheer.Data.EFCore;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sollicitatiebeheer.Model.Vacatures;
using Sollicitatiebeheer.Model.Afdelingen;

namespace Sollicitatiebeheer.Web.Features.Vacatures {
    public class Bewerken {
        public class Handler : DbRequestHandler<Request, Response> {
            public Handler(ISollicitatiebeheerContext sollicitatiebeheerContext) : base(sollicitatiebeheerContext) {
            }

            public override Response Handle(Request message) {
                var vacature = _db.Vacatures.Include(v => v.Afdeling).SingleOrDefault(v => v.Id == message.Id);

                return new Response {
                    Vacature = vacature,
                    GeselecteerdeAfdeling = vacature.AfdelingId.ToString(),
                    Afdelingen = _db.Afdelingen.ToList()
                };
            }
        }

        public class Request : IRequest<Response> {
            public Guid Id { get; set; }
        }
        public class Response : VacatureDetail {
        }
    }
}
