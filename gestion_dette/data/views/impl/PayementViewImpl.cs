using GesDette.Data.Entities;

namespace GesDette.Views.Impl
{
    public class PayementViewImpl : ViewImpl<Payement>, IPayementView
    {
        public override Payement Saisie()
        {
            throw new NotImplementedException();
        }

        public Payement SaisiePayement(Dette dette)
        {
            Payement payement = new ();
            do {
                Console.WriteLine("Entrer le montant a verser");
                payement.MontantPayer = Convert.ToDouble(Console.ReadLine());
            } while (payement.MontantPayer <= 0 || payement.MontantPayer > (dette.Montant - dette.MontantVerser));
            dette.MontantVerser = dette.MontantVerser + payement.MontantPayer;
            payement.Dette = dette;
            dette.Payements.Add(payement);
            return payement;
        }
    }
}