//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
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

namespace Testing
{
   public partial class UParentOptional : Testing.HiddenEntity, INotifyPropertyChanged
   {
      partial void Init();

      /// <summary>
      /// Default constructor. Protected due to required properties, but present because EF needs it.
      /// </summary>
      protected UParentOptional(): base()
      {
         PropertyInChild = "hello";
         UChildCollection = new System.Collections.Generic.HashSet<Testing.UChild>();

         Init();
      }

      /// <summary>
      /// Public constructor with required data
      /// </summary>
      /// <param name="uchildrequired"></param>
      public UParentOptional(Testing.UChild uchildrequired)
      {
         PropertyInChild = "hello";
         if (uchildrequired == null) throw new ArgumentNullException(nameof(uchildrequired));
         UChildRequired = uchildrequired;

         UChildCollection = new System.Collections.Generic.HashSet<Testing.UChild>();
         Init();
      }

      /// <summary>
      /// Static create function (for use in LINQ queries, etc.)
      /// </summary>
      /// <param name="uchildrequired"></param>
      public static UParentOptional Create(Testing.UChild uchildrequired)
      {
         return new UParentOptional(uchildrequired);
      }

      /*************************************************************************
       * Persistent properties
       *************************************************************************/

      /// <summary>
      /// Backing field for PropertyInChild
      /// </summary>
      protected string _PropertyInChild;
      /// <summary>
      /// When provided in a partial class, allows value of PropertyInChild to be changed before setting.
      /// </summary>
      partial void SetPropertyInChild(string oldValue, ref string newValue);
      /// <summary>
      /// When provided in a partial class, allows value of PropertyInChild to be changed before returning.
      /// </summary>
      partial void GetPropertyInChild(ref string result);

      /// <summary>
      /// Default value = "hello"
      /// </summary>
      public string PropertyInChild
      {
         get
         {
            string value = _PropertyInChild;
            GetPropertyInChild(ref value);
            return (_PropertyInChild = value);
         }
         set
         {
            string oldValue = _PropertyInChild;
            SetPropertyInChild(oldValue, ref value);
            if (oldValue != value)
            {
               _PropertyInChild = value;
               OnPropertyChanged();
            }
         }
      }

      /*************************************************************************
       * Persistent navigation properties
       *************************************************************************/

      protected Testing.UChild _UChildOptional;
      partial void SetUChildOptional(Testing.UChild oldValue, ref Testing.UChild newValue);
      partial void GetUChildOptional(ref Testing.UChild result);

      public Testing.UChild UChildOptional
      {
         get
         {
            Testing.UChild value = _UChildOptional;
            GetUChildOptional(ref value);
            return (_UChildOptional = value);
         }
         set
         {
            Testing.UChild oldValue = _UChildOptional;
            SetUChildOptional(oldValue, ref value);
            if (oldValue != value)
            {
               _UChildOptional = value;
               OnPropertyChanged();
            }
         }
      }

      public virtual ICollection<Testing.UChild> UChildCollection { get; set; }

      protected Testing.UChild _UChildRequired;
      partial void SetUChildRequired(Testing.UChild oldValue, ref Testing.UChild newValue);
      partial void GetUChildRequired(ref Testing.UChild result);

      /// <summary>
      /// Required
      /// </summary>
      public Testing.UChild UChildRequired
      {
         get
         {
            Testing.UChild value = _UChildRequired;
            GetUChildRequired(ref value);
            return (_UChildRequired = value);
         }
         set
         {
            Testing.UChild oldValue = _UChildRequired;
            SetUChildRequired(oldValue, ref value);
            if (oldValue != value)
            {
               _UChildRequired = value;
               OnPropertyChanged();
            }
         }
      }

      public override event PropertyChangedEventHandler PropertyChanged;

      protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }

   }
}

