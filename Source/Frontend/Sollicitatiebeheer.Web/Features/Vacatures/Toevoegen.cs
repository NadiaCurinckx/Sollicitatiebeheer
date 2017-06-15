using System;
using MediatR;
using Sollicitatiebeheer.Model.Vacatures;

namespace Sollicitatiebeheer.Web.Features.Vacatures
{
    public class Toevoegen
    {
        public class Handler : IRequestHandler<Request, Response>
        {
            public Response Handle(Request message)
            {
                return new Response
                {
                    Vacature = new VacatureBuilder().Build()                    
                };
            }
        }

        public class Request : IRequest<Response>
        {

        }
        public class Response
        {
            public Vacature Vacature { get; set; }            
        }
    }
}
