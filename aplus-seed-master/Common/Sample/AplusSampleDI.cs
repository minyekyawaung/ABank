using aplus_back_seed.Interfaces;

namespace aplus_back_seed.Common
{
    public class AplusSampleDI : IAplusSample
    {
        public void write(string text)
        {
            Console.WriteLine(text);
        }
    }
}