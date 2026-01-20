namespace Cards;

public class Mazzo
{

  private List<Carta> carte = new List<Carta>();
  private Random random = new Random();

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
    for (int i = carte.Count - 1; i > 0; i--)
    {
      int randomIndex = random.Next(i + 1);
      (carte[i], carte[randomIndex]) = (carte[randomIndex], carte[i]);
    }
  }

  public Mano Distribuisci()
  {
    List<Carta> cinque = carte.TakeLast(5).ToList();
    carte.RemoveRange(carte.Count - 5, 5);
    return new Mano(cinque);
  }

}