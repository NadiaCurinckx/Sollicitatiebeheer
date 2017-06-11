using System;
using MediatR;
using Sollicitatiebeheer.Data.EFCore;

namespace Sollicitatiebeheer.Web.Infrastructure.Handlers {
    public abstract class DbRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse> {
        protected readonly ISollicitatiebeheerContext _db;

        protected DbRequestHandler(ISollicitatiebeheerContext sollicitatiebeheerContext) {
            _db = sollicitatiebeheerContext;
        }

        public abstract TResponse Handle(TRequest message);
    }
}
