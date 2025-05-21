
using Microsoft.AspNetCore.Mvc;

namespace Target.Helpers
{
    public static class ApiResponseHelper
    {
        public static IActionResult Response<T>(T data, string message = "Operação realizada com sucesso.", int statusCode = 200)
        {
            return new JsonResult(new
            {
                success = true,
                message,
                data,
            })
            {
                StatusCode = statusCode
            };
        }

        public static IActionResult Response(string message = "Operação realizada com sucesso.", int statusCode = 200, bool _sucess = true)
        {
            return new JsonResult(new
            {
                success = _sucess,
                message,
            })
            {
                StatusCode = statusCode
            };
        }
    }

}