namespace NArms.WonderPrint.Extensions
{
    public static class PrintExtensions
    {
        public static IPrinter Print(this object value)
        {
            return WonderPrint.Print.This(value);
        }
    }
}