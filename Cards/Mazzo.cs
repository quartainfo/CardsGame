namespace Cards;

/// <summary>
/// Rappresenta un mazzo di 52 carte da gioco
/// </summary>
public class Mazzo
{
  private List<Carta> carte;
  public IReadOnlyList<Carta> Carte => carte.AsReadOnly();
  private Random random;

  public Mazzo()
  {
    carte = new List<Carta>();
    random = new Random();
    InizializzaMazzo();
  }

  /// <summary>
  /// Inizializza il mazzo con tutte le 52 carte
  /// </summary>
  private void InizializzaMazzo()
  {
    char[] valori = { '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' };
    Seme[] semi = { Seme.Cuori, Seme.Quadri, Seme.Fiori, Seme.Picche };

    foreach (var seme in semi)
    {
      foreach (var valore in valori)
      {
        carte.Add(new Carta(seme, valore));
      }
    }
  }

  /// <summary>
  /// Mescola le carte del mazzo usando l'algoritmo Fisher-Yates
  /// </summary>
  public void Mescola()
  {
    int n = carte.Count;
    for (int i = n - 1; i > 0; i--)
    {
      int j = random.Next(i + 1);
      // Scambia carte[i] con carte[j]
      Carta temp = carte[i];
      carte[i] = carte[j];
      carte[j] = temp;
    }
  }

  /// <summary>
  /// Distribuisce una mano di 5 carte dal mazzo
  /// </summary>
  /// <returns>Una nuova mano con 5 carte</returns>
  /// <exception cref="InvalidOperationException">Se non ci sono abbastanza carte nel mazzo</exception>
  // public Mano Distribuisci()
  // {
  //   if (carte.Count < 5)
  //   {
  //     throw new InvalidOperationException("Non ci sono abbastanza carte nel mazzo per distribuire una mano.");
  //   }

  //   List<Carta> carteDistribuite = new List<Carta>();
  //   for (int i = 0; i < 5; i++)
  //   {
  //     carteDistribuite.Add(carte[0]);
  //     carte.RemoveAt(0);
  //   }

  //   return new Mano(carteDistribuite);
  // }

  /// <summary>
  /// Ottiene il numero di carte rimanenti nel mazzo
  /// </summary>
  public int CarteRimanenti => carte.Count;

  /// <summary>
  /// Ripristina il mazzo con tutte le 52 carte
  /// </summary>
  public void Ripristina()
  {
    carte.Clear();
    InizializzaMazzo();
  }
}