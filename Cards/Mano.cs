namespace Cards;

public class Mano : IComparable<Mano>
{
  private List<Carta> carte;

  public Mano(List<Carta> carte)
  {
    this.carte = carte.OrderByDescending(c => c.Valore).ToList();
  }

  public bool IsScalaReale()
  {
    return IsScalaColore() && carte[0].Valore == 'A' && carte[4].Valore == '5';
  }

  public bool IsScalaColore()
  {
    return IsScala() && IsColore();
  }

  public bool IsPoker()
  {
    var grouped = carte.GroupBy(c => c.Valore).ToList();
    return grouped.Any(g => g.Count() == 4);
  }

  public bool IsFull()
  {
    var grouped = carte.GroupBy(c => c.Valore).ToList();
    return grouped.Count() == 2 && grouped.Any(g => g.Count() == 3) && grouped.Any(g => g.Count() == 2);
  }

  public bool IsColore()
  {
    return carte.GroupBy(c => c.Seme).Count() == 1;
  }

  public bool IsScala()
  {
    var valoriOrdine = new Dictionary<char, int> { { '2', 2 }, { '3', 3 }, { '4', 4 }, { '5', 5 }, { '6', 6 }, { '7', 7 }, { '8', 8 }, { '9', 9 }, { 'T', 10 }, { 'J', 11 }, { 'Q', 12 }, { 'K', 13 }, { 'A', 14 } };
    var valori = carte.Select(c => valoriOrdine[c.Valore]).OrderBy(v => v).ToList();
    
    // Check normal sequence
    if (valori.SequenceEqual(new[] { valori[0], valori[0] + 1, valori[0] + 2, valori[0] + 3, valori[0] + 4 }))
      return true;
    
    // Check A-2-3-4-5 (wheel)
    if (valori.SequenceEqual(new[] { 2, 3, 4, 5, 14 }))
      return true;
    
    return false;
  }

  public bool IsTris()
  {
    var grouped = carte.GroupBy(c => c.Valore).ToList();
    return grouped.Any(g => g.Count() == 3) && grouped.Count() == 3;
  }

  public bool IsDoppiaCoppia()
  {
    var grouped = carte.GroupBy(c => c.Valore).ToList();
    return grouped.Count(g => g.Count() == 2) == 2;
  }

  public bool IsCoppia()
  {
    var grouped = carte.GroupBy(c => c.Valore).ToList();
    return grouped.Count(g => g.Count() == 2) == 1 && grouped.Count() == 4;
  }

  public bool IsCartaAlta()
  {
    return !IsScalaReale() && !IsScalaColore() && !IsPoker() && !IsFull() && !IsColore() && !IsScala() && !IsTris() && !IsDoppiaCoppia() && !IsCoppia();
  }

  public int CompareTo(Mano? other)
  {
    if (other == null) return 1;

    int[] thisRank = GetHandRank();
    int[] otherRank = other.GetHandRank();

    for (int i = 0; i < thisRank.Length; i++)
    {
      if (thisRank[i] != otherRank[i])
        return otherRank[i].CompareTo(thisRank[i]);
    }
    return 0;
  }

  private int[] GetHandRank()
  {
    if (IsScalaReale()) return new[] { 10, 0 };
    if (IsScalaColore()) return new[] { 9, GetHighCard() };
    if (IsPoker()) return new[] { 8, GetQuadValue() };
    if (IsFull()) return new[] { 7, GetTrioValue(), GetPairValue() };
    if (IsColore()) return new[] { 6, GetHighCard() };
    if (IsScala()) return new[] { 5, GetHighCard() };
    if (IsTris()) return new[] { 4, GetTrioValue() };
    if (IsDoppiaCoppia()) return new[] { 3, GetPairValues()[0], GetPairValues()[1] };
    if (IsCoppia()) return new[] { 2, GetPairValue() };
    return new[] { 1, GetHighCard() };
  }

  private int GetHighCard() => GetCardValue(carte[0].Valore);
  private int GetQuadValue() => GetCardValue(carte.GroupBy(c => c.Valore).First(g => g.Count() == 4).Key);
  private int GetTrioValue() => GetCardValue(carte.GroupBy(c => c.Valore).First(g => g.Count() == 3).Key);
  private int GetPairValue() => GetCardValue(carte.GroupBy(c => c.Valore).First(g => g.Count() == 2).Key);
  private int[] GetPairValues() => carte.GroupBy(c => c.Valore).Where(g => g.Count() == 2).Select(g => GetCardValue(g.Key)).OrderByDescending(v => v).ToArray();

  private int GetCardValue(char valore)
  {
    return valore switch
    {
      '2' => 2, '3' => 3, '4' => 4, '5' => 5, '6' => 6, '7' => 7, '8' => 8, '9' => 9,
      'T' => 10, 'J' => 11, 'Q' => 12, 'K' => 13, 'A' => 14,
      _ => 0
    };
  }
}
