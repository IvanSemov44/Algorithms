
namespace ExamPreparation
{
    internal class Strings_Mashup2
    {
        public static void Solution()
        {
            string str = Console.ReadLine();
            str = str.ToUpper();
            Console.WriteLine(str);
            Combin(str.ToCharArray(), 0);
        }

        private static void Combin(char[] str, int idx)
        {
            for (int i = idx; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                    continue;

                if (char.IsLower(str[i]))
                    continue;

                str[i] = char.ToLower(str[i]);
                Console.WriteLine(string.Join("",str));
            }
        }
    }
}
