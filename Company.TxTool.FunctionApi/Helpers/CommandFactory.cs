using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Cushwake.TreasuryTool.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Company.TxTool.FunctionApi.Helpers;


public class CommandFactory<T> : ICommandFactory<T> where T : class
{
    public async Task<T> GetCommand(HttpRequest httpRequest)
    {
        var casted = (T)Activator.CreateInstance(typeof(T))!;
        IList<PropertyInfo> props = new List<PropertyInfo>(typeof(T).GetProperties());

        foreach (var prop in props)
        {
            if (prop == null)
                throw new Exception(string.Format("Property {0} not found", prop!.Name.ToLower()));

            var propReaVal = httpRequest.Query[prop.Name.Trim()];
            if (prop.PropertyType == typeof(string))
            {
                prop.SetValue(casted, propReaVal[0], null);
            }
            if (prop.PropertyType == typeof(int))
            {
                prop.SetValue(casted, propReaVal[0].ToInteger(), null);
            }
        }
        return await Task.FromResult(casted!);
    }

}

public interface ICommandFactory<TResponse> where TResponse : class
{
    Task<TResponse> GetCommand(HttpRequest httpRequest);
}

