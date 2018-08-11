﻿using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace JValueMasker.Utilities
{
    internal static class Masker
    {
        internal const string DefaultMask = "***";

        public static JProperty Mask(JProperty jProperty, 
                                     List<string> propertiesToMask, 
                                     string mask = DefaultMask)
        {
            var property = jProperty.Name;
            var value = jProperty.Value;
            if (value is JValue && ShouldBeMasked(property, propertiesToMask))
            {
                return new JProperty(property, mask);
            }

            return jProperty;
        }

        private static bool ShouldBeMasked(string propertyName, List<string> propertiesToMask)
        {
            return propertiesToMask.Contains(propertyName);
        }
    }
}
