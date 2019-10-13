namespace CSharp8.Features
{
    public class StaticLocalFunctions
    {
        int DemonstrateUseOfStaticLocalFunctions()
        {
            int x = 0, y;
            LocalFunction();
            Add(x, y);
            return y;

            //Can't be static because it captures y from the enclosing scope'
            void LocalFunction() => y = 0;
            
            
            static int Add(int left, int right) => left + right;
        }
    }
}