using System;

namespace Company.TxTool.Application.Extensions
{
    public static class CollectionExtensions
    {
        public static void Sync<T>(this ICollection<T> target, IEnumerable<int> sourceIds, Func<T, int> targetIdSelector, Func<int, T> newEntityBuilder)
        {
            var existingEntityIdMap = target.ToDictionary(targetIdSelector, t => t);

            var entityIdsToRemove = existingEntityIdMap.Keys.Except(sourceIds);
            foreach (var idToRemove in entityIdsToRemove)
            {
                target.Remove(existingEntityIdMap[idToRemove]);
            }

            var entityIdsToAdd = sourceIds.Except(existingEntityIdMap.Keys);
            foreach (var idToAdd in entityIdsToAdd)
            {
                target.Add(newEntityBuilder(idToAdd));
            }
        }
    }
}
