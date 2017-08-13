﻿namespace Sawczyn.EFDesigner.EFModel
{
   public class NavigationProperty
   {
      public ModelClass ClassType { get; set; }
      public Association AssociationObject { get; set; }
      public string PropertyName { get; set; }
      public Multiplicity Cardinality { get; set; }

      public bool IsCollection => /*Cardinality == Multiplicity.OneMany || */Cardinality == Multiplicity.ZeroMany;
      public bool Required => Cardinality == Multiplicity.One /*|| Cardinality == Multiplicity.OneMany*/;
      public bool ConstructorParameterOnly { get; set; }
   }
}
