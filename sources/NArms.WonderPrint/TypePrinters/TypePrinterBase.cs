namespace NArms.WonderPrint.TypePrinters
{
    public abstract class TypePrinterBase<T> : ITypePrinter
    {
        public string Format(object value)
        {
            return Format((T) value);
        }

        protected abstract string Format(T value);
    }
}