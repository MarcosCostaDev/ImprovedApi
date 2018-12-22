using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseApi.Infra.Extensions
{
    public static class EntityStateExtesion
    {
        public static bool IsModified(this EntityEntry entry) =>
        entry.State == EntityState.Modified ||
        entry.References.Any(r => r.TargetEntry != null && r.TargetEntry.Metadata.IsOwned() && IsModified(r.TargetEntry));

        public static bool IsAdded(this EntityEntry entry) =>
         entry.State == EntityState.Added ||
         entry.References.Any(r => r.TargetEntry != null && r.TargetEntry.Metadata.IsOwned() && IsAdded(r.TargetEntry));

        public static bool IsDeleted(this EntityEntry entry) =>
         entry.State == EntityState.Deleted ||
         entry.References.Any(r => r.TargetEntry != null && r.TargetEntry.Metadata.IsOwned() && IsDeleted(r.TargetEntry));

        public static bool SetEntityState(this EntityEntry entity, EntityState state)
        {
            switch (state)
            {
                case EntityState.Added:
                    return entity.IsAdded();

                case EntityState.Modified:
                    return entity.IsModified();

                case EntityState.Deleted:
                    return entity.IsDeleted();
                default:
                    return false;
            }
        }
    }
}
