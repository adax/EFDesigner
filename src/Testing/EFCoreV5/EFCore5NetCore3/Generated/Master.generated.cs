//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
//
//     Produced by Entity Framework Visual Editor v3.0.0.3
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

namespace EFCore5NetCore3
{
   public partial class Master
   {
      partial void Init();

      /// <summary>
      /// Default constructor. Protected due to required properties, but present because EF needs it.
      /// </summary>
      protected Master()
      {
         ToZeroOrOneDetail1 = new global::EFCore5NetCore3.Detail1();
         ToOneDetail1 = new global::EFCore5NetCore3.Detail1();
         ToZeroOrOneDetail3 = new global::EFCore5NetCore3.Detail3();
         ToOneDetail3 = new global::EFCore5NetCore3.Detail3();
         ToZeroOrOneDetail2 = new global::EFCore5NetCore3.Detail2();
         ToOneDetail2 = new global::EFCore5NetCore3.Detail2();

         Init();
      }

      /// <summary>
      /// Replaces default constructor, since it's protected. Caller assumes responsibility for setting all required values before saving.
      /// </summary>
      public static Master CreateMasterUnsafe()
      {
         return new Master();
      }

      /// <summary>
      /// Public constructor with required data
      /// </summary>
      /// <param name="fa">Foreign key for Master.ToOneDetail3 --&gt; Detail3. </param>
      /// <param name="toonedetail3"></param>
      /// <param name="toonedetail2"></param>
      public Master(long fa, global::EFCore5NetCore3.Detail3 toonedetail3, global::EFCore5NetCore3.Detail2 toonedetail2)
      {
         this.Fa = fa;

         if (toonedetail3 == null) throw new ArgumentNullException(nameof(toonedetail3));
         this.ToOneDetail3 = toonedetail3;

         if (toonedetail2 == null) throw new ArgumentNullException(nameof(toonedetail2));
         this.ToOneDetail2 = toonedetail2;

         this.ToZeroOrOneDetail1 = new global::EFCore5NetCore3.Detail1();
         this.ToOneDetail1 = new global::EFCore5NetCore3.Detail1();
         this.ToZeroOrOneDetail2 = new global::EFCore5NetCore3.Detail2();
         this.ToOneDetail2 = new global::EFCore5NetCore3.Detail2();

         Init();
      }

      /// <summary>
      /// Static create function (for use in LINQ queries, etc.)
      /// </summary>
      /// <param name="fa">Foreign key for Master.ToOneDetail3 --&gt; Detail3. </param>
      /// <param name="toonedetail3"></param>
      /// <param name="toonedetail2"></param>
      public static Master Create(long fa, global::EFCore5NetCore3.Detail3 toonedetail3, global::EFCore5NetCore3.Detail2 toonedetail2)
      {
         return new Master(fa, toonedetail3, toonedetail2);
      }

      /*************************************************************************
       * Properties
       *************************************************************************/

      /// <summary>
      /// Identity, Indexed, Required
      /// </summary>
      [Key]
      [Required]
      public long Id { get; protected set; }

      /// <summary>
      /// Indexed
      /// Foreign key for Master.ToZeroOrOneDetail3 --&gt; Detail3. 
      /// </summary>
      public long? Fb { get; set; }

      public string Property1 { get; set; }

      /// <summary>
      /// Indexed, Required
      /// Foreign key for Master.ToOneDetail3 --&gt; Detail3. 
      /// </summary>
      [Required]
      public long Fa { get; set; }

      /*************************************************************************
       * Navigation properties
       *************************************************************************/

      public virtual global::EFCore5NetCore3.Detail1 ToZeroOrOneDetail1 { get; set; }

      /// <summary>
      /// Required
      /// </summary>
      public virtual global::EFCore5NetCore3.Detail1 ToOneDetail1 { get; set; }

      public virtual global::EFCore5NetCore3.Detail3 ToZeroOrOneDetail3 { get; set; }

      /// <summary>
      /// Required
      /// </summary>
      public virtual global::EFCore5NetCore3.Detail3 ToOneDetail3 { get; set; }

      public virtual global::EFCore5NetCore3.Detail2 ToZeroOrOneDetail2 { get; set; }

      /// <summary>
      /// Required
      /// </summary>
      public virtual global::EFCore5NetCore3.Detail2 ToOneDetail2 { get; set; }

   }
}

