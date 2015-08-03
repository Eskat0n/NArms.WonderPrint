namespace NArms.WonderPrint.TypePrinters
{
    public class Int32TypePrinter : TypePrinterBase<int>
    {
        protected override string Format(int value)
        {
            return value.ToString();
        }
    }
}