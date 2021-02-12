//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
//
//     Produced by Entity Framework Visual Editor v3.0.4.5
//     Source:                    https://github.com/msawczyn/EFDesigner
//     Visual Studio Marketplace: https://marketplace.visualstudio.com/items?itemName=michaelsawczyn.EFDesigner
//     Documentation:             https://msawczyn.github.io/EFDesigner/
//     License (MIT):             https://github.com/msawczyn/EFDesigner/blob/master/LICENSE
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Data.Entity.Spatial;

namespace Testing
{
   public partial class DerivedClass: global::Testing.BaseClass
   {
      partial void Init();

      /// <summary>
      /// Default constructor. Protected due to required properties, but present because EF needs it.
      /// </summary>
      protected DerivedClass(): base()
      {
         Init();
      }

      /// <summary>
      /// Replaces default constructor, since it's protected. Caller assumes responsibility for setting all required values before saving.
      /// </summary>
      public static DerivedClass CreateDerivedClassUnsafe()
      {
         return new DerivedClass();
      }

      /// <summary>
      /// Public constructor with required data
      /// </summary>
      /// <param name="property0"></param>
      public DerivedClass(string property0)
      {
         if (string.IsNullOrEmpty(property0)) throw new ArgumentNullException(nameof(property0));
         this.Property0 = property0;

         Init();
      }

      /// <summary>
      /// Static create function (for use in LINQ queries, etc.)
      /// </summary>
      /// <param name="property0"></param>
      public static new DerivedClass Create(string property0)
      {
         return new DerivedClass(property0);
      }

      /*************************************************************************
       * Properties
       *************************************************************************/

      /// <summary>
      /// Backing field for Property1
      /// </summary>
      protected string _property1;
      /// <summary>
      /// When provided in a partial class, allows value of Property1 to be changed before setting.
      /// </summary>
      partial void SetProperty1(string oldValue, ref string newValue);
      /// <summary>
      /// When provided in a partial class, allows value of Property1 to be changed before returning.
      /// </summary>
      partial void GetProperty1(ref string result);

      public string Property1
      {
         get
         {
            string value = _property1;
            GetProperty1(ref value);
            return (_property1 = value);
         }
         set
         {
            string oldValue = _property1;
            SetProperty1(oldValue, ref value);
            if (oldValue != value)
            {
               _property1 = value;
            }
         }
      }

      /// <summary>
      /// Backing field for PropertyInChild
      /// </summary>
      protected string _propertyInChild;
      /// <summary>
      /// When provided in a partial class, allows value of PropertyInChild to be changed before setting.
      /// </summary>
      partial void SetPropertyInChild(string oldValue, ref string newValue);
      /// <summary>
      /// When provided in a partial class, allows value of PropertyInChild to be changed before returning.
      /// </summary>
      partial void GetPropertyInChild(ref string result);

      public string PropertyInChild
      {
         get
         {
            string value = _propertyInChild;
            GetPropertyInChild(ref value);
            return (_propertyInChild = value);
         }
         set
         {
            string oldValue = _propertyInChild;
            SetPropertyInChild(oldValue, ref value);
            if (oldValue != value)
            {
               _propertyInChild = value;
            }
         }
      }

      /// <summary>
      /// Backing field for Id1
      /// </summary>
      internal int _id1;
      /// <summary>
      /// When provided in a partial class, allows value of Id1 to be changed before setting.
      /// </summary>
      partial void SetId1(int oldValue, ref int newValue);
      /// <summary>
      /// When provided in a partial class, allows value of Id1 to be changed before returning.
      /// </summary>
      partial void GetId1(ref int result);

      /// <summary>
      /// Identity, Indexed, Required
      /// </summary>
      [Key]
      [Required]
      public int Id1
      {
         get
         {
            int value = _id1;
            GetId1(ref value);
            return (_id1 = value);
         }
         set
         {
            int oldValue = _id1;
            SetId1(oldValue, ref value);
            if (oldValue != value)
            {
               _id1 = value;
            }
         }
      }

   }
}

