using System;
using Newtonsoft.Json;

namespace Cushwake.TreasuryTool.Domain.Helpers
{
    public static class JsonHelper
    {
        /// <summary>
        /// This method does not copy any properties with private setters. Use DeepCloner.Clone() for such requirements.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static T DeepClone<T>(T entity) where T : class
        {
            string json = JsonConvert.SerializeObject(entity, Formatting.None,
            new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return JsonConvert.DeserializeObject<T>(json)!;
        }

        public static string GetJson(object entity)
        {
            return JsonConvert.SerializeObject(entity);
        }
    }
}