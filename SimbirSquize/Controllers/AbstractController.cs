using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SimbirSquize.Data;

namespace SimbirSquize.Controllers
{
    public class AbstractController : Controller
    {
        public ServiceResponse<T> WrapToResponse<T>(T responseContent)
        {
            return new ServiceResponse<T>
            {
                Data = responseContent
            };
        }

        protected static Dictionary<string, string[]> WrapErrorResponse(ModelStateDictionary ModelState)
        {
            return ModelState
                .ToDictionary(
                    kvp => char.ToUpper(kvp.Key[0]) + kvp.Key.Substring(1),
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );
        }
    }
}