﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace Framework.Core.OnionClass
{
   
    public static class MappingExtensions
    {
        public static PrimitivePropertyConfiguration IsUnique(this PrimitivePropertyConfiguration configuration)
        {
            return configuration.HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute { IsUnique = true }));
        }
    }
    
}
