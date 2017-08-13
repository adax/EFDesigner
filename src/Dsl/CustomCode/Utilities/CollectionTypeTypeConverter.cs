﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.Modeling;

namespace Sawczyn.EFDesigner.EFModel
{
   public class CollectionTypeTypeConverter : TypeConverterBase
   {
      /// <summary>
      ///    Returns a collection of standard values for the data type this type converter is designed for when provided
      ///    with a format context.
      /// </summary>
      /// <param name="context">
      ///    An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context
      ///    that can be used to extract additional information about the environment from which this converter is invoked. This
      ///    parameter or properties of this parameter can be null.
      /// </param>
      /// <returns>
      ///    A <see cref="T:System.ComponentModel.TypeConverter.StandardValuesCollection" /> that holds a standard set of
      ///    valid values, or null if the data type does not support a standard set of values.
      /// </returns>
      public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
      {
         // Try to get a store from the current context  
         // "context.Instance"  returns the element(s) that are currently selected i.e. whose values are being shown in the property grid.   
         // Note that the user could have selected multiple objects, in which case context.Instance will be an array.  
         Store store = GetStore(context.Instance);
         List<string> values = new List<string>(new[] { "HashSet", "List", "ObservableCollection" });
         values.AddRange(store.ElementDirectory.FindElements<Association>().Select(x => x.CollectionClass));

         return new StandardValuesCollection(values.OrderBy(x => x).Distinct().ToList());
      }

      /// <summary>
      ///    Returns whether the collection of standard values returned from
      ///    <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues" /> is an exclusive list of possible values,
      ///    using the specified context.
      /// </summary>
      /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context. </param>
      /// <returns>
      ///    true if the <see cref="T:System.ComponentModel.TypeConverter.StandardValuesCollection" /> returned from
      ///    <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues" /> is an exhaustive list of possible values;
      ///    false if other values are possible.
      /// </returns>
      public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
      {
         return false;
      }

      /// <summary>
      ///    Returns whether this object supports a standard set of values that can be picked from a list, using the
      ///    specified context.
      /// </summary>
      /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context. </param>
      /// <returns>
      ///    true if <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues" /> should be called to find a
      ///    common set of values the object supports; otherwise, false.
      /// </returns>
      public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
      {
         return true;
      }

      public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
      {
         return sourceType == typeof(string);
      }

      public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
      {
         return value?.ToString();
      }
   }
}
