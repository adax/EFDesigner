﻿using System.Data.Entity.Design.PluralizationServices;
using Microsoft.VisualStudio.Modeling;

namespace Sawczyn.EFDesigner.EFModel
{
   [RuleOn(typeof(Association), FireTime = TimeToFire.Inline)]
   internal class AssociationAddRules : AddRule
   {
      public override void ElementAdded(ElementAddedEventArgs e)
      {
         base.ElementAdded(e);

         Association element = (Association)e.ModelElement;
         Store store = element.Store;
         Transaction current = store.TransactionManager.CurrentTransaction;
         PluralizationService pluralizationService = ModelRoot.PluralizationService;

         if (current.IsSerializing)
            return;

         if (string.IsNullOrEmpty(element.TargetPropertyName))
         {
            string rootName = element.TargetMultiplicity == Multiplicity.ZeroMany &&
                              pluralizationService.IsSingular(element.Target.Name)
                                 ? pluralizationService.Pluralize(element.Target.Name)
                                 : element.Target.Name;

            string identifierName = rootName;
            int index = 0;

            while (element.Source.HasIdentifierNamed(identifierName))
               identifierName = $"{rootName}_{++index}";

            element.TargetPropertyName = identifierName;
         }

         if (element is BidirectionalAssociation bidirectionalAssociation)
         {
            if (string.IsNullOrEmpty(bidirectionalAssociation.SourcePropertyName))
            {
               string rootName = element.SourceMultiplicity == Multiplicity.ZeroMany &&
                                 pluralizationService.IsSingular(element.Source.Name)
                                    ? pluralizationService.Pluralize(element.Source.Name)
                                    : element.Source.Name;

               string identifierName = rootName;
               int index = 0;

               while (element.Target.HasIdentifierNamed(identifierName))
                  identifierName = $"{rootName}_{++index}";

               bidirectionalAssociation.SourcePropertyName = identifierName;
            }
         }

         AssociationChangeRules.SetEndpointRoles(element);

      }
   }
}
