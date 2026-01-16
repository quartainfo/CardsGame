namespace Cards;

public class Mazzo
{

  private List<Carta> carte = new List<Carta>();

  public Mazzo()
  {
    Seme[] semi = [Seme.Cuori, Seme.Quadri, Seme.Fiori, Seme.Picche];
    char[] valori = ['2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A'];
    foreach (var seme in semi)
    {
      foreach (var valore in valori)
      {
        carte.Add(new Carta(seme, valore));
      }
    }
  }

  public void Mescola()
  {

  }

}