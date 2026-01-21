
namespace Cards;

/// <summary>
/// Rappresenta una mano di 5 carte da poker
/// </summary>
public class Mano : IComparable<Mano>
{
  public List<Carta> Carte { get; }

  public Mano(List<Carta> carte)
  {
    if (carte.Count != 5)
    {
      throw new ArgumentException("Una mano deve contenere esattamente 5 carte.");
    }
    Carte = new List<Carta>(carte);
    Carte.Sort(); // Ordina le carte per facilitare la valutazione
  }

  /// <summary>
  /// Verifica se la mano è una Scala Reale (A, K, Q, J, T dello stesso seme)
  /// </summary>
  public bool IsScalaReale()
  {
    if (!IsColore()) return false;

    var valori = Carte.Select(c => c.ValoreNumerico).OrderBy(v => v).ToList();
    return valori.SequenceEqual(new[] { 10, 11, 12, 13, 14 });
  }

  /// <summary>
  /// Verifica se la mano è una Scala Colore (cinque carte consecutive dello stesso seme)
  /// </summary>
  public bool IsScalaColore()
  {
    return IsColore() && IsScala();
  }

  /// <summary>
  /// Verifica se la mano è un Poker (quattro carte dello stesso valore)
  /// </summary>
  public bool IsPoker()
  {
    var gruppi = Carte.GroupBy(c => c.ValoreNumerico)
                     .Select(g => g.Count())
                     .OrderByDescending(count => count)
                     .ToList();
    return gruppi[0] == 4;
  }

  /// <summary>
  /// Verifica se la mano è un Full (tris + coppia)
  /// </summary>
  public bool IsFull()
  {
    var gruppi = Carte.GroupBy(c => c.ValoreNumerico)
                     .Select(g => g.Count())
                     .OrderByDescending(count => count)
                     .ToList();
    return gruppi.Count == 2 && gruppi[0] == 3 && gruppi[1] == 2;
  }

  /// <summary>
  /// Verifica se la mano è un Colore (cinque carte dello stesso seme)
  /// </summary>
  public bool IsColore()
  {
    return Carte.Select(c => c.Seme).Distinct().Count() == 1;
  }

  /// <summary>
  /// Verifica se la mano è una Scala (cinque carte consecutive)
  /// </summary>
  public bool IsScala()
  {
    var valori = Carte.Select(c => c.ValoreNumerico).OrderBy(v => v).ToList();

    // Verifica scala normale
    bool scalaNormale = true;
    for (int i = 1; i < valori.Count; i++)
    {
      if (valori[i] != valori[i - 1] + 1)
      {
        scalaNormale = false;
        break;
      }
    }

    if (scalaNormale) return true;

    // Verifica scala con asso basso (A, 2, 3, 4, 5)
    if (valori.SequenceEqual(new[] { 2, 3, 4, 5, 14 }))
    {
      return true;
    }

    return false;
  }

  /// <summary>
  /// Verifica se la mano è un Tris (tre carte dello stesso valore)
  /// </summary>
  public bool IsTris()
  {
    var gruppi = Carte.GroupBy(c => c.ValoreNumerico)
                     .Select(g => g.Count())
                     .OrderByDescending(count => count)
                     .ToList();
    return gruppi[0] == 3 && gruppi[1] != 2;
  }

  /// <summary>
  /// Verifica se la mano è una Doppia Coppia (due coppie)
  /// </summary>
  public bool IsDoppiaCoppia()
  {
    var gruppi = Carte.GroupBy(c => c.ValoreNumerico)
                     .Where(g => g.Count() == 2)
                     .ToList();
    return gruppi.Count == 2;
  }

  /// <summary>
  /// Verifica se la mano è una Coppia (due carte dello stesso valore)
  /// </summary>
  public bool IsCoppia()
  {
    var gruppi = Carte.GroupBy(c => c.ValoreNumerico)
                     .Where(g => g.Count() == 2)
                     .ToList();
    return gruppi.Count == 1;
  }

  /// <summary>
  /// Verifica se la mano è una Carta Alta (nessuna combinazione)
  /// </summary>
  public bool IsCartaAlta()
  {
    return !IsCoppia() && !IsDoppiaCoppia() && !IsTris() && !IsScala() &&
           !IsColore() && !IsFull() && !IsPoker() && !IsScalaColore() && !IsScalaReale();
  }

  /// <summary>
  /// Ottiene il punteggio della mano per il confronto
  /// </summary>
  private int GetPunteggio()
  {
    if (IsScalaReale()) return 10;
    if (IsScalaColore()) return 9;
    if (IsPoker()) return 8;
    if (IsFull()) return 7;
    if (IsColore()) return 6;
    if (IsScala()) return 5;
    if (IsTris()) return 4;
    if (IsDoppiaCoppia()) return 3;
    if (IsCoppia()) return 2;
    return 1; // Carta Alta
  }

  /// <summary>
  /// Confronta questa mano con un'altra secondo le regole del poker
  /// </summary>
  public int CompareTo(Mano? other)
  {
    if (other == null) return 1;

    int punteggioThis = GetPunteggio();
    int punteggioOther = other.GetPunteggio();

    if (punteggioThis != punteggioOther)
    {
      return punteggioThis.CompareTo(punteggioOther);
    }

    // Se hanno lo stesso tipo di mano, confronta le carte più alte
    for (int i = Carte.Count - 1; i >= 0; i--)
    {
      int confronto = Carte[i].CompareTo(other.Carte[i]);
      if (confronto != 0) return confronto;
    }

    return 0; // Mani identiche
  }

  /// <summary>
  /// Restituisce una descrizione testuale della mano
  /// </summary>
  public override string ToString()
  {
    string tipo = GetPunteggio() switch
    {
      10 => "Scala Reale",
      9 => "Scala Colore",
      8 => "Poker",
      7 => "Full",
      6 => "Colore",
      5 => "Scala",
      4 => "Tris",
      3 => "Doppia Coppia",
      2 => "Coppia",
      _ => "Carta Alta"
    };

    return $"{tipo}: {string.Join(", ", Carte)}";
  }
}