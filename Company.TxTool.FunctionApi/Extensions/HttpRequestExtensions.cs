using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Company.TxTool.FunctionApi.Extensions;

public static class HttpRequestExtensions
{
    public static async Task<T> GetFromJsonBody<T>(this HttpRequest request)
    {
        var requestBody = await new StreamReader(request.Body).ReadToEndAsync();

        return JsonConvert.DeserializeObject<T>(requestBody)!;
    }

    public static async Task<string> GetBody(this HttpRequest request)
    {
        return await new StreamReader(request.Body).ReadToEndAsync();
    }
}
