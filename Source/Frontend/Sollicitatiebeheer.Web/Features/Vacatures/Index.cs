using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
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

                if (String.IsNullOrEmpty(message.SorteerCode)) {
                    message.SorteerCode = "asc";
                }

                switch (message.SorteerCode.ToLower().Trim()) {
                    case "asc":
                        vacatures = vacatures.OrderBy(v => v).ToList();
                        break;
                    case "desc":
                        vacatures = vacatures.OrderByDescending(v => v).ToList();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(message.SorteerCode), $"Sort order {message.SorteerCode} does not exist.");
                }

                return new Response(message, vacatures);
            }
        }

        public class Request : IRequest<Response> {
            public Request() {
                SorteerCode = "asc";
            }
            public Request(Request request) {
                SorteerCode = request.SorteerCode;
            }

            private string _sorteerCode;
            public string SorteerCode {
                get => _sorteerCode;
                set => _sorteerCode = value.Trim().ToLower();
            }

            public class Validator : AbstractValidator<Request> {
                public Validator() {
                    RuleFor(r => r.SorteerCode)
                        .NotEmpty()
                        .Must(EenGeldigeSorteerCodeZijn)
                        .WithMessage("Ongeldige sorteercode.");
                }

                private readonly string[] _geldigeSorteerCodes = { "asc", "desc" };
                public bool EenGeldigeSorteerCodeZijn(string sorteerCode) {
                    return _geldigeSorteerCodes.Contains(sorteerCode);
                }
            }
        }

        public class Response : Request {
            public Response(Request request, List<string> vacatures) : base(request) => Vacatures = vacatures;
            public List<string> Vacatures { get; }
        }
    }
}
