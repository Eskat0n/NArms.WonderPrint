namespace NArms.WonderPrint.Utilities
{
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    internal class ObjectWrapper : Dictionary<string, object>, IObjectWrapper
    {
        public ObjectWrapper(string name, object @object)
        {
            Name = name;
            HashCode = RuntimeHelpers.GetHashCode(@object);
        }

        public string Name { get; }
        public int HashCode { get; }
    }
}