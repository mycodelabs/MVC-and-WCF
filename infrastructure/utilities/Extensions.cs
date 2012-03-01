using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Xml.Linq;

namespace infrasrtucture.utilities
{
    public static class Extensions
    {
        public static IEnumerable<T> MapToDomainObject<T>(this IEnumerable<XElement> nodes)
        {
            var domainObj = _getExpandoFromXml(nodes);
            ExpandoUtilities.ToConcrete<T>(domainObj);
            return XmlNodesIterator<T>(nodes);
        }

        private static IEnumerable<T> XmlNodesIterator<T>(IEnumerable<XElement> nodes)
        {
            var objects = new List<T>();
            foreach (var xElement in nodes)
            {
                object domainObj = GetProperties<T>(xElement);
                //T domain = ExpandoUtilities.ToConcrete<T>(domainObj);
                //objects.Add(domain);
            }

            return objects.AsEnumerable();
        }

        private static object GetProperties<T>(XElement xElement)
        {
            dynamic domainObj = new ExpandoObject();
            foreach (var node in xElement.Descendants())
            {
                if (!node.HasAttributes)
                {
                    var property = domainObj as IDictionary<string, object>;
                    property[node.Name.ToString()] = node.Value.Trim();
                }
            }
            return domainObj;
        }


        private static dynamic _getExpandoFromXml(IEnumerable<XElement> nodes)
        {
            dynamic result = new ExpandoObject();


            foreach (var gn in nodes) 
            {
                var skip = false;
                skip = (from a in gn.Attributes()
                        where a.Name.LocalName.ToLower() == "type"
                        select a.Value.ToLower()).FirstOrDefault() == "list" ? true :
                           gn.Elements().GroupBy(n => n.Name.LocalName).Count() == 1;

                var p = result as IDictionary<String, dynamic>;
                var values = new List<dynamic>();
                
                if (skip)
                    foreach (var item in gn.Descendants())
                    {
                        values.Add((item.HasElements) ? _getExpandoFromXml(item.Descendants()) :
                            item.Value.Trim());
                    }
                else
                    values.Add((gn.HasElements) ? _getExpandoFromXml(gn.Descendants()) :
                        gn.Value.Trim());

                p[gn.Name.LocalName] = skip ? values : values.FirstOrDefault();
            }
            return result;
        }
    }




}