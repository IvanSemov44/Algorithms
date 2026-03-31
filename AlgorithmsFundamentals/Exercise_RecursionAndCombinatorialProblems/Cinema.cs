using System.Text;

namespace Exercise_RecursionAndCombinatorialProblems
{
    /* 4. Cinema

  Write a program that prints all of the possible distributions of a group of friends in a cinema hall. On the first line,
  you will be given all of the friends' names separated by comma and space. Until you receive the command 
  "generate" you will be given some of those friends' names and a number of the place that they want to have. 
  (format: "{name} - {place}") So here comes the tricky part. Those friends want only to sit in the place that they 
  have chosen. They cannot sit in other places. For more clarification see the examples below.
  Output

  Print all the possible ways to distribute the friends having in mind that some of them want a particular place and 
  they will sit there only. The order of the output does not matter.
  Constrains

  • The friends' names and the number of the place will always be valid.
  Examples
  Input Output Comments

  Peter, Amy, George, Rick
  Amy - 1
  Rick - 4
  generate

  Amy Peter George Rick
  Amy George Peter Rick

  Comments:
  Amy only wants to 
  sit on the first 
  seat and Rick wants 
  to sit on the 
  fourth, so we only 
  switch the other 
  friends

  ---------------

  Garry, Liam, Teddy, Anna, Buddy, Simon
  Buddy - 3
  Liam - 5
  Simon - 1
  generate

  Simon Garry Buddy Teddy Liam Anna
  Simon Garry Buddy Anna Liam Teddy
  Simon Teddy Buddy Garry Liam Anna
  Simon Teddy Buddy Anna Liam Garry
  Simon Anna Buddy Garry Liam Teddy
  Simon Anna Buddy Teddy Liam Garry
   */
    internal class Cinema
    {
        private static List<string> nonStaticPeople;
        private static string[] people;
        private static bool[] locked;

        public static void Solution()
        {
            nonStaticPeople = Console.ReadLine().Split(", ").ToList();
            people = new string[nonStaticPeople.Count];
            locked = new bool[nonStaticPeople.Count];

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "generate") break;

                var paths = line.Split(" - ");
                var name = paths[0];
                var position = int.Parse(paths[1]) - 1;

                people[position] = name;
                locked[position] = true;

                nonStaticPeople.Remove(name);
            }
            Permute(0);
        }

        private static void Permute(int idx)
        {
            if (idx >= nonStaticPeople.Count)
            {
                PrintPermutaion();
                return;
            }

            Permute(idx + 1);

            for (int i = idx + 1; i < nonStaticPeople.Count; i++)
            {
                Swap(idx, i);
                Permute(idx + 1);
                Swap(idx, i);
            }
        }

        private static void PrintPermutaion()
        {
            var peopleIndex = 0;
            var sb = new StringBuilder();

            for (int i = 0; i < people.Length; i++)
                if (locked[i])
                    sb.Append($"{people[i]} ");
                else
                    sb.Append($"{nonStaticPeople[peopleIndex++]} ");

            Console.WriteLine(sb.ToString().Trim());
        }

        private static void Swap(int first, int second)
        {
            var temp = nonStaticPeople[first];
            nonStaticPeople[first] = nonStaticPeople[second];
            nonStaticPeople[second] = temp;
        }
    }
}
