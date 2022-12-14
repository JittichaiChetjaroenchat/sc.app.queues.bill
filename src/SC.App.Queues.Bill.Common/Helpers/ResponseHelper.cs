using System.Collections.Generic;
using SC.App.Queues.Bill.Common.Enums;
using SC.App.Queues.Bill.Common.Responses;

namespace SC.App.Queues.Bill.Common.Helpers
{
    public class ResponseHelper
    {
        public static Response<T> Ok<T>(T data) where T : class
        {
            return new Response<T>
            {
                Status = EnumResponseStatus.OK,
                Data = data,
                Errors = new List<ResponseError>()
            };
        }

        public static Response<T> Error<T>(ICollection<ResponseError> errors) where T : class
        {
            return new Response<T>
            {
                Status = EnumResponseStatus.ERROR,
                Errors = errors
            };
        }
    }
}