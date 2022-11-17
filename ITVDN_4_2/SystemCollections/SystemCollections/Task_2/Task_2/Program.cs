
//Задание : Создайте коллекцию, в которую можно добавлять покупателей и категорию приобретенной ими
//продукции.Из коллекции можно получать категории товаров, которые купил покупатель или по
//категории определить покупателей.

namespace Task_2
{
    public class Buyer
    { 
        public string Name { get; set; }
        public Buyer(string Name)
        {
            this.Name = Name;
        }
    }

    public enum Category
    {
        Food,
        Clothes,
        Health,
        Sport,
        IT
    }

    public class Program
    {
        public static void Main()
        {
            Dictionary<Buyer, List<Category>> buyersWithCategory = new Dictionary<Buyer,List<Category>>();
            buyersWithCategory[new Buyer("Mikle")] = new List<Category> { Category.Food, Category.Clothes, Category.Health };
            buyersWithCategory[new Buyer("Julia")] = new List<Category> { Category.Health, Category.Sport };
            buyersWithCategory[new Buyer("Maria")] = new List<Category> { Category.Sport, Category.Clothes };
            buyersWithCategory[new Buyer("Sonya")] = new List<Category> { Category.Food};

            ShowBuyersWithCategory(buyersWithCategory);

            Console.WriteLine(new String('-', 30));

            List<Category> categories = Enum.GetValues(typeof(Category)).Cast<Category>().ToList();
            foreach(var category in categories)
                ShowBuyersByCategory(category, buyersWithCategory);
        }

        public static void ShowBuyersWithCategory(Dictionary<Buyer, List<Category>> buyersWithCategory)
        {
            foreach(var item in buyersWithCategory)
            {
                string line = "";
                string categotySeparator = ", ";

                line += item.Key.Name + "\t";

                foreach (var category in item.Value)
                    line += category + categotySeparator;

                if(line.Contains(categotySeparator))
                    line = line.Substring(0, line.LastIndexOf(categotySeparator));

                Console.WriteLine(line);
            }   
        }

        public static void ShowBuyersByCategory(Category category,Dictionary<Buyer, List<Category>> buyersWithCategory)
        {
            string line = category + "\t";
            string buyerSeparator = ", ";

            foreach (var item in buyersWithCategory)
                if(item.Value.Contains(category))
                    line += item.Key.Name + buyerSeparator;

            if(line.Contains(buyerSeparator))
                line = line.Substring(0, line.LastIndexOf(buyerSeparator));

            Console.WriteLine(line);
        }
    }

}