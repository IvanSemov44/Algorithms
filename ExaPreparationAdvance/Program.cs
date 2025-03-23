namespace ExamPreparationAdvance
{
    public class ItemShop
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Value { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //ExamsStartCode.Run();

            var items = new List<ItemShop>();

            var itemsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < itemsCount; i++)
            {
                var itemData = Console.ReadLine().Split();

                items.Add(new ItemShop
                {
                    Name = itemData[0],
                    Weight = int.Parse(itemData[1]),
                    Value = int.Parse(itemData[2])
                });
            }

            var pairs = int.Parse(Console.ReadLine());

            for (int i = 0; i < pairs; i++)
            {
                var pairData = Console.ReadLine().Split();

                var firstName = pairData[0];
                var secondName = pairData[1];

                var firstItem = items.FirstOrDefault(x => x.Name.Contains(firstName));
                var secondItem = items.FirstOrDefault(y => y.Name.Contains(secondName));

                items.Add(new ItemShop
                {
                    Name = firstItem.Name + " " + secondItem.Name,
                    Weight = firstItem.Weight + secondItem.Weight,
                    Value = firstItem.Value + secondItem.Value
                });

                items.Remove(firstItem);
                items.Remove(secondItem);
            }

            var maxCapacity = int.Parse(Console.ReadLine());
            ;

            var dp = new int[items.Count + 1, maxCapacity + 1];
            var used = new bool[items.Count + 1, maxCapacity + 1];

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                var itemIdx = row - 1;
                var item = items[itemIdx];

                for (int capacity = 0; capacity < dp.GetLength(1); capacity++)
                {
                    var excluding = dp[row - 1, capacity];

                    if (item.Weight > capacity)
                    {
                        dp[row, capacity] = excluding;
                        used[row, capacity] = true;
                        continue;
                    }

                    var including = item.Value + dp[row - 1, capacity - item.Weight];

                    if (including > excluding)
                    {
                        dp[row, capacity] = including;
                    }
                    else
                    {
                        dp[row, capacity] = excluding;
                    }
                }
            }
            Console.WriteLine(dp[items.Count, maxCapacity]);

            var currentCapacity = maxCapacity;

            var totalWeight = 0;
            var usedItems = new SortedSet<string>();
            ;
            for (int row = dp.GetLength(0) - 1; row > 0; row--)
            {
                if (!used[row, currentCapacity])
                    continue;

                var item = items[row - 1];
                totalWeight += item.Weight;
                currentCapacity -= item.Weight;
                ; 
                var names = item.Name.Split().ToArray();
                foreach (var name in names)
                    usedItems.Add(name);

                if (currentCapacity == 0)
                    break;
            }

            Console.WriteLine(totalWeight);
            Console.WriteLine(dp[items.Count, maxCapacity]);
            Console.WriteLine(string.Join(Environment.NewLine, usedItems));
        }
    }
}
