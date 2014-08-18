namespace UmbracoTwenty
{
    using System;
    using System.Collections.Generic;
    using Umbraco.Core.Models;
    using Umbraco.Web;
    using Zone.UmbracoMapper;
    using UmbracoTwenty.Models;
    using Archetype.Models;
    using System.Linq;

    public class ArchetypeMapper
    {
        //public static object MapCaptionedImage(IUmbracoMapper mapper, IPublishedContent contentToMapFrom, string propName, bool isRecursive)
        //{
        //    var result = new List<CaptionedImage>();

        //    ArchetypeModel archetypeModel = contentToMapFrom.GetPropertyValue<ArchetypeModel>(propName, isRecursive, null);
        //    if (archetypeModel != null)
        //    {
        //        var archetypeAsDictionary = archetypeModel
        //            .Select(item => item.Properties.ToDictionary(m => m.Alias, m => GetTypedValue(m), StringComparer.InvariantCultureIgnoreCase))
        //            .ToList();
        //        mapper.MapCollection(archetypeAsDictionary, result);
        //    }

        //    return result;
        //}

        private static object GetTypedValue(ArchetypePropertyModel archetypeProperty)
        {
            switch (archetypeProperty.PropertyEditorAlias)
            {
                case "Umbraco.ContentPickerAlias":
                case "Umbraco.MediaPicker":
                    return archetypeProperty.GetValue<IPublishedContent>();
                case "Umbraco.MultiNodeTreePicker":
                    return archetypeProperty.GetValue<IEnumerable<IPublishedContent>>();
                default:
                    return archetypeProperty.Value;
            }
        }
    }
}