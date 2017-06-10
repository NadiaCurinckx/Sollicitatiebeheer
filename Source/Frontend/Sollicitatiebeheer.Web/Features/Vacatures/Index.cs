using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;

namespace Sollicitatiebeheer.Web.Features.Vacatures {
    public class Index {
        public class Handler : IRequestHandler<Request, Response> {
            public Response Handle(Request message) {
                var vacatures = new List<string> {
                    "Vacature 1",
                    "Vacature 2",
                    "Vacature 3"
                };

                if (String.IsNullOrEmpty(message.SortOrder)) {
                    message.SortOrder = "asc";
                }

                switch (message.SortOrder.ToLower().Trim()) {
                    case "asc":
                        vacatures = vacatures.OrderBy(v => v).ToList();
                        break;
                    case "desc":
                        vacatures = vacatures.OrderByDescending(v => v).ToList();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(message.SortOrder), $"Sort order {message.SortOrder} does not exist.");
                }

                return new Response(message, vacatures);
            }
        }

        public class Request : IRequest<Response> {
            public Request() { }
            public Request(Request request) {
                SortOrder = request.SortOrder;
            }
            public string SortOrder { get; set; }
        }

        public class Response : Request {
            public Response(Request request, List<string> vacatures) : base(request) => Vacatures = vacatures;
            public List<string> Vacatures { get; }
        }
    }
}
