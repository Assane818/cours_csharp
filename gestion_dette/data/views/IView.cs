namespace GesDette.Views
{
    public interface IView<T>
    {
        T Saisie();
        void Affiche(List<T> list);
        int SaisieInt(String msg);
        Double SaisieDouble(String msg);
        String SaisieString(String msg);
        int ChoiceFilter(List<String> filtre);
    }
}