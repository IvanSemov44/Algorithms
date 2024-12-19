
namespace SolutionsFromCodewars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //"10.0.0.0", "10.0.0.50"
            ///"10.0.0.0", "10.0.1.0"
            //"20.0.0.10", "20.0.1.0"

            int[] first = "20.0.0.10".Split(".").Select(int.Parse).ToArray();
            int[] second = "20.0.1.0".Split('.').Select(int.Parse).ToArray();


            long countFirst = 0;
            long countSecond = 0;

            for (int i = 4; i >0 ; i--)
            {
                countFirst += first[i-1] - i * 256;
                countSecond += second[i-1] - i * 256;
            }
            Console.WriteLine(countSecond-countFirst);  
        }
    }
}
