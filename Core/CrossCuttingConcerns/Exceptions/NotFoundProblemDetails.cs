using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core.CrossCuttingConcerns.Exceptions;

public class NotFoundProblemDetails : ProblemDetails
{
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
