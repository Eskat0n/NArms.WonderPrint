namespace NArms.WonderPrint
{
    using System.Collections.Generic;

    internal interface IEnumerableWrapper : IList<object>
    {
        string Name { get; }
        int HashCode { get; }
    }
}