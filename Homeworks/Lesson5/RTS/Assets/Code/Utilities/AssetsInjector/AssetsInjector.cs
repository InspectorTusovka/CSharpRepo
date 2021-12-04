using System;
using System.Collections.Generic;
using System.Reflection;

namespace Code.Utilities
{
    public static class AssetsInjector
    {
        private static readonly Type _injectAssetAttributeType = typeof(InjectAssetsAttribute);
        public static T Inject<T>(this AssetsContext context, T target)
        {
            var targetType = target.GetType();
            var allFields = targetType.GetFieldsIncludeBase(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance |
                BindingFlags.FlattenHierarchy);

            for (int i = 0; i < allFields.Length; i++)
            {
                var fieldInfo = allFields[i];
                var injectAssetAttribute = fieldInfo
                    .GetCustomAttribute(_injectAssetAttributeType) as InjectAssetsAttribute;
                if (injectAssetAttribute == null)
                    continue;
                var objecttoInject = context.GetObjectOfType(fieldInfo.FieldType, injectAssetAttribute.AssetName);
                fieldInfo.SetValue(target, objecttoInject);
            }
            return target;
        }

        private static FieldInfo[] GetFieldsIncludeBase(this Type type, BindingFlags flags)
        {
            FieldInfo[] fieldInfos = type.GetFields(flags);

            if (type.BaseType == typeof(object))
                return fieldInfos;
            else
            {
                var fieldInfoList = new List<FieldInfo>(fieldInfos);
                while (type.BaseType != typeof(object))
                {
                    type = type.BaseType;
                    fieldInfos = type.GetFields(flags);

                    for(int i = 0; i < fieldInfos.Length; i++)
                    {
                        bool found = false;

                        for(var j = 0; j < fieldInfoList.Count; j++)
                        {
                            bool match =
                            (fieldInfoList[j].DeclaringType == fieldInfos[i].DeclaringType) &&
                        (fieldInfoList[j].Name == fieldInfos[i].Name);

                            if (match) { found = true; break; }
                        }

                        if (!found)
                            fieldInfoList.Add(fieldInfos[i]);
                    }
                }
                return fieldInfoList.ToArray();
            }
        }
    }

}
