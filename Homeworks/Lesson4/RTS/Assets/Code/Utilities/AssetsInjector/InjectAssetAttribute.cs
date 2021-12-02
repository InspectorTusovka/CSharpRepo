using System;

namespace Code.Utilities
{
    [AttributeUsage(AttributeTargets.Field)]
    public class InjectAssetsAttribute : Attribute
    {
        public readonly string AssetName;
        public InjectAssetsAttribute(string assetName = null)
        {
            AssetName = assetName;
        }
    }

}