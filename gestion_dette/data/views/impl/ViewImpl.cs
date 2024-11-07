
namespace GesDette.Views.Impl
{
    public abstract class ViewImpl<T> : IView<T>
    {
        public void Affiche(List<T> list)
        {
            foreach (var dette in list)
            {
                Console.WriteLine(dette);
            }
        }

        public int ChoiceFilter(List<string> filtre)
        {
            int choice;
            do {
                for (int i = 0; i < filtre.Count; i++) {
                    Console.WriteLine((i+1) + "-" + filtre[i]);
                }
                Console.WriteLine("Entrer votre choix:");
                choice = Convert.ToInt32(Console.ReadLine());
            } while (choice <= 0 || choice > filtre.Count);
            return choice;
        }


        public double SaisieDouble(string msg)
        {
            Console.WriteLine(msg);
            return Convert.ToDouble(Console.ReadLine());
        }

        public int SaisieInt(string msg)
        {
            Console.WriteLine(msg);
            return Convert.ToInt32(Console.ReadLine());
        }

        public string SaisieString(string msg)
        {
            Console.WriteLine(msg);
            return Console.ReadLine();
        }
        public abstract T Saisie();

    }
}