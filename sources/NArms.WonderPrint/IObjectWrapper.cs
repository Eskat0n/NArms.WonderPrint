namespace NArms.WonderPrint
{
    using System.Collections.Generic;

    internal interface IObjectWrapper : IDictionary<string, object>
    {
        string Name { get; }
        int HashCode { get; }
    }
}