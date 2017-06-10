using System.Collections.Generic;
using MediatR;

namespace Sollicitatiebeheer.Web.Features.Vacatures {
    public class Index {
        public class Handler : IRequestHandler<Request, Response> {
            public Response Handle(Request message) {
                return new Response(new List<string> {
                    "Vacature 1",
                    "Vacature 2",
                    "Vacature 3"
                });
            }
        }

        public class Request : IRequest<Response> { }

        public class Response {
            public Response(List<string> vacatures) => Vacatures = vacatures;
            public List<string> Vacatures { get; }
        }
    }
}
