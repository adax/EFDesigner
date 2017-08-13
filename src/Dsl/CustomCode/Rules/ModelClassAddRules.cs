﻿using System.Linq;
using Microsoft.VisualStudio.Modeling;

namespace Sawczyn.EFDesigner.EFModel
{
   [RuleOn(typeof(ModelClass), FireTime = TimeToFire.TopLevelCommit)]
   internal class ModelClassAddRules : AddRule
   {
      public override void ElementAdded(ElementAddedEventArgs e)
      {
         base.ElementAdded(e);

         ModelClass element = (ModelClass) e.ModelElement;
         Store store = element.Store;
         Transaction current = store.TransactionManager.CurrentTransaction;

         if (current.IsSerializing)
            return;

         // there could already be an identity property if this class was created via Paste
         if (!element.AllAttributes.Any(a => a.IsIdentity))
         {
            ModelAttribute newAttribute = new ModelAttribute(element.Partition)
                                          {
                                             Name = "Id",
                                             Type = "Int32",
                                             IsIdentity = true,
                                             IdentityType = IdentityType.AutoGenerated
                                          };
            element.Attributes.Add(newAttribute);
         }

         if (element.ModelRoot.ConcurrencyDefault == Concurrency.Optimistic &&
             !element.AllAttributes.Any(x => x.IsConcurrencyToken))
         {
            ModelAttribute concurrencyToken = new ModelAttribute(element.Partition)
            {
               Name = "Timestamp",
               Type = "Binary",
               IsConcurrencyToken = true
            };
            element.Attributes.Add(concurrencyToken);
         }

         element.DbSetName = ModelRoot.PluralizationService.IsSingular(element.Name)
            ? ModelRoot.PluralizationService.Pluralize(element.Name)
            : element.Name;

         element.TableName = ModelRoot.PluralizationService.IsSingular(element.Name)
            ? ModelRoot.PluralizationService.Pluralize(element.Name)
            : element.Name;
      }
   }
}
