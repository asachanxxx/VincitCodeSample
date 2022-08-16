using System;
using System.Runtime.Serialization;

namespace Cushwake.TreasuryTool.Domain.Helpers
{
    public static class ObjectHelper
    {
        public static void Copy<TSource, TTarget>(TSource source, TTarget target) where TSource : class where TTarget : class
        {
            var sourceProperties = source.GetType().GetProperties();
            var targetProperties = target.GetType().GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                foreach (var targetProperty in targetProperties)
                {
                    if (sourceProperty.Name != targetProperty.Name || sourceProperty.PropertyType != targetProperty.PropertyType)
                    {
                        continue;
                    }

                    if (targetProperty.CanWrite)
                    {
                        targetProperty.SetValue(target, sourceProperty.GetValue(source));
                    }
                    break;
                }
            }
        }

        public static T Clone<T>(T source) where T : class
        {
            T target = (FormatterServices.GetUninitializedObject(typeof(T)) as T)!;
            Copy(source, target);
            return target;
        }
    }
}
