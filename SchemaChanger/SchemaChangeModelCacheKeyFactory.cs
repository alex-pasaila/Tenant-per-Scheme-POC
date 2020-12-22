using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace SchemaChanger
{
    public class SchemaChangeModelCacheKeyFactory : IModelCacheKeyFactory
    {
        public object Create(DbContext context)
        {
            return new { Type = context.GetType(), Schema = context is IDbContextSchema schema ? schema.Schema : null };
        }
    }
}