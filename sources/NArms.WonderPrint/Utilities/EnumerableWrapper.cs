namespace NArms.WonderPrint.Utilities
{
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    internal class EnumerableWrapper : List<object>, IEnumerableWrapper
    {
        public EnumerableWrapper(string name, object @object, IEnumerable<object> collection)
            : base(collection)
        {
            Name = name;
            HashCode = RuntimeHelpers.GetHashCode(@object);
        }

        public string Name { get; }
        public int HashCode { get; }
    }
}