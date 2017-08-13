﻿using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.Modeling.Validation;

namespace Sawczyn.EFDesigner.EFModel
{
   [ValidationState(ValidationState.Enabled)]
   public partial class ModelAttribute
   {
      public static string[] ValidTypes =
      {
         "Binary",
         "Boolean",
         "Byte",
         "DateTime",
         "DateTimeOffset",
         "Decimal",
         "Double",
         "Geography",
         "GeographyCollection",
         "GeographyLineString",
         "GeographyMultiLineString",
         "GeographyMultiPoint",
         "GeographyMultiPolygon",
         "GeographyPoint",
         "GeographyPolygon",
         "Geometry",
         "GeometryCollection",
         "GeometryLineString",
         "GeometryMultiLineString",
         "GeometryMultiPoint",
         "GeometryMultiPolygon",
         "GeometryPoint",
         "GeometryPolygon",
         "Guid",
         "Int16",
         "Int32",
         "Int64",
         //"SByte",
         "Single",
         "String",
         "Time"
      };

      public string CLRType => ToCLRType(Type);

#pragma warning disable 168
      public bool HasValidDefault()
      {
         if (string.IsNullOrEmpty(InitialValue))
            return true;

         switch (Type)
         {
            case "Binary":
            case "Geography":
            case "GeographyCollection":
            case "GeographyLineString":
            case "GeographyMultiLineString":
            case "GeographyMultiPoint":
            case "GeographyMultiPolygon":
            case "GeographyPoint":
            case "GeographyPolygon":
            case "Geometry":
            case "GeometryCollection":
            case "GeometryLineString":
            case "GeometryMultiLineString":
            case "GeometryMultiPoint":
            case "GeometryMultiPolygon":
            case "GeometryPoint":
            case "GeometryPolygon":
               return string.IsNullOrEmpty(InitialValue);
            case "Boolean":
               return bool.TryParse(InitialValue, out bool _bool);
            case "Byte":
               return byte.TryParse(InitialValue, out byte _byte);
            case "DateTime":
               return DateTime.TryParse(InitialValue, out DateTime _dateTime);
            case "DateTimeOffset":
               return DateTimeOffset.TryParse(InitialValue, out DateTimeOffset _dateTimeOffset);
            case "Decimal":
               return decimal.TryParse(InitialValue, out decimal _decimal);
            case "Double":
               return double.TryParse(InitialValue, out double _double);
            case "Guid":
               return Guid.TryParse(InitialValue, out Guid _guid);
            case "Int16":
               return short.TryParse(InitialValue, out short _int16);
            case "Int32":
               return int.TryParse(InitialValue, out int _int32);
            case "Int64":
               return long.TryParse(InitialValue, out long _int64);
            //case "SByte":
            //   return sbyte.TryParse(InitialValue, out sbyte _sbyte);
            case "Single":
               return float.TryParse(InitialValue, out float _single);
            case "Time":
               return DateTime.TryParseExact(
                                             InitialValue,
                                             new[] { "HH:mm:ss", "H:mm:ss", "HH:mm", "H:mm", "HH:mm:ss tt", "H:mm:ss tt", "HH:mm tt", "H:mm tt" },
                                             CultureInfo.InvariantCulture,
                                             DateTimeStyles.None,
                                             out DateTime _time);
         }

         return true;
      }
#pragma warning restore 168

      /// <summary>
      /// From internal class System.Data.Metadata.Edm.PrimitiveType in System.Data.Entity
      /// </summary>
      /// <param name="typeName"></param>
      /// <returns></returns>
      public static string ToCLRType(string typeName)
      {
         switch (typeName)
         {
            case "Binary":
               return "byte[]";
            case "Boolean":
               return "bool";
            case "Byte":
               return "byte";
            case "DateTime":
               return "DateTime";
            case "Time":
               return "TimeSpan";
            case "DateTimeOffset":
               return "DateTimeOffset";
            case "Decimal":
               return "decimal";
            case "Double":
               return "double";
            case "Geography":
            case "GeographyPoint":
            case "GeographyLineString":
            case "GeographyPolygon":
            case "GeographyMultiPoint":
            case "GeographyMultiLineString":
            case "GeographyMultiPolygon":
            case "GeographyCollection":
               return "DbGeography";
            case "Geometry":
            case "GeometryPoint":
            case "GeometryLineString":
            case "GeometryPolygon":
            case "GeometryMultiPoint":
            case "GeometryMultiLineString":
            case "GeometryMultiPolygon":
            case "GeometryCollection":
               return "DbGeometry";
            case "Guid":
               return "Guid";
            case "Single":
               return "Single";
            //case "SByte":
            //   return "sbyte";
            case "Int16":
               return "short";
            case "Int32":
               return "int";
            case "Int64":
               return "long";
            case "String":
               return "string";
         }

         return typeName;
      }

      public static string FromCLRType(string typeName)
      {
         switch (typeName)
         {
            case "byte[]":
               return "Binary";
            case "bool":
               return "Boolean";
            case "byte":
               return "Byte";
            case "DateTime":
               return "DateTime";
            case "TimeSpan":
               return "Time";
            case "DateTimeOffset":
               return "DateTimeOffset";
            case "decimal":
               return "Decimal";
            case "double":
               return "Double";
            case "DbGeography":
               return "Geography";
            case "DbGeometry":
               return "Geometry";
            case "Guid":
               return "Guid";
            case "Single":
               return "Single";
            //case "sbyte":
            //   return "SByte";
            case "short":
               return "Int16";
            case "int":
               return "Int32";
            case "long":
               return "Int64";
            case "string":
               return "String";
         }

         return typeName;
      }

      [ValidationMethod(ValidationCategories.Open | ValidationCategories.Save | ValidationCategories.Menu)]
      // ReSharper disable once UnusedMember.Local
      private void StringsShouldHaveLength(ValidationContext context)
      {
         if (Type == "String" && MaxLength == 0)
            context.LogWarning("String length not specified", "MWStringNoLength", this);
      }

      #region Parse string

      // Note: gave some thought to making this be an LALR parser, but that's WAY overkill for what needs done here. Regex is good enough.

      private const string NAME = "(?<name>[A-Za-z_][A-za-z0-9_]*)";
      private const string TYPE = "(?<type>[A-Za-z_][A-za-z0-9_]*)";
      private const string LENGTH = @"(?<length>\d+)";
      private const string NULLABLE = @"(?<nullable>\?)";
      private const string STRING_TYPE = "(?<type>[Ss]tring)";
      private const string VISIBILITY = @"(?<visibility>public\s+|protected\s+)";
      private const string WS = @"\s";

      private static readonly Regex NameOnly = new Regex($"^{WS}*{VISIBILITY}?{NAME}{WS}*$", RegexOptions.Compiled);
      private static readonly Regex StringAndLengthAndName = new Regex($@"^{WS}*{VISIBILITY}?{STRING_TYPE}{NULLABLE}?\[{LENGTH}\]{WS}+{NAME}{WS}*;?{WS}*$|^{WS}*{VISIBILITY}?{STRING_TYPE}{NULLABLE}?\({LENGTH}\){WS}+{NAME}{WS}*;?{WS}*$", RegexOptions.Compiled);
      private static readonly Regex NameAndStringAndLength = new Regex($@"^{WS}*{VISIBILITY}?{NAME}{WS}*:{WS}*{STRING_TYPE}{NULLABLE}?\[{LENGTH}\]{WS}*;?{WS}*$|^{WS}*{VISIBILITY}?{NAME}{WS}*:{WS}*{STRING_TYPE}{NULLABLE}?\({LENGTH}\){WS}*;?{WS}*$", RegexOptions.Compiled);
      private static readonly Regex TypeAndName = new Regex($"^{WS}*{VISIBILITY}?{TYPE}{NULLABLE}?{WS}+{NAME}{WS}*;?{WS}*$", RegexOptions.Compiled);
      private static readonly Regex NameAndType = new Regex($"^{WS}*{VISIBILITY}?{NAME}{WS}*:{WS}*{TYPE}{NULLABLE}?{WS}*;?{WS}*$", RegexOptions.Compiled);

      private static readonly Regex[] ParseSequence =
      {
         NameOnly,
         StringAndLengthAndName,
         NameAndStringAndLength,
         TypeAndName,
         NameAndType
      };

      public class ParseResult
      {
         public SetterAccessModifier? SetterVisibility { get; set; }
         public string Name { get; set; }
         public string Type { get; set; }
         public bool? Required { get; set; }
         public int? MaxLength { get; set; }
      }

      public static ParseResult Parse(ModelRoot modelRoot, string input)
      {
         ParseResult result = new ParseResult();
         foreach (Match match in ParseSequence.Select(regex => regex.Match(input)).Where(match => match.Success))
         {
            if (match.Groups["visibility"].Success)
               result.SetterVisibility = match.Groups["visibility"].Value.Trim() == "protected" ? SetterAccessModifier.Protected : SetterAccessModifier.Public;

            if (match.Groups["name"].Success)
               result.Name = match.Groups["name"].Value.Trim();

            if (match.Groups["type"].Success)
            {
               result.Type = match.Groups["type"].Value.Trim();
               if (!ValidTypes.Contains(result.Type))
               {
                  result.Type = FromCLRType(result.Type);
                  if (!ValidTypes.Contains(result.Type) && !modelRoot.Enums.Select(e => e.Name).Contains(result.Type))
                     result.Type = null;
               }
            }

            if (match.Groups["nullable"].Success)
               result.Required = string.IsNullOrEmpty(match.Groups["nullable"].Value.Trim());

            if (result.Type == "String" && match.Groups["length"].Success && !string.IsNullOrWhiteSpace(match.Groups["length"].Value.Trim()))
               result.MaxLength = int.Parse(match.Groups["length"].Value.Trim());

            return result;
         }

         return null; // couldn't parse
      }

      #endregion Parse string
   }
}
