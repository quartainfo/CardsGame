namespace Cards;

/// <summary>
/// Rappresenta una carta da gioco con seme e valore
/// </summary>
public class Carta : IComparable<Carta>
{
  public Seme Seme { get; }
  // Valore rappresentato come singolo carattere: '2'..'9', 'T' (Dieci), 'J', 'Q', 'K', 'A'
  public char Valore { get; }

  public Carta(Seme seme, char valore)
  {
    Seme = seme;
    Valore = valore;
  }

  public override string ToString()
  {
    var nomeValore = Valore switch
    {
      'T' => "Dieci",
      'J' => "Jack",
      'Q' => "Regina",
      'K' => "Re",
      'A' => "Asso",
      _ => Valore.ToString()
    };

    return $"{nomeValore} di {Seme}";
  }

  public int CompareTo(Carta? other)
  {
    throw new NotImplementedException();
  }

  /// <summary>
  /// Ottiene il valore numerico della carta per il calcolo del punteggio poker
  /// </summary>
  public int ValoreNumerico
  {
    get
    {
      return Valore switch
      {
        '2' => 2,
        '3' => 3,
        '4' => 4,
        '5' => 5,
        '6' => 6,
        '7' => 7,
        '8' => 8,
        '9' => 9,
        'T' => 10,
        'J' => 11,
        'Q' => 12,
        'K' => 13,
        'A' => 14,
        _ => throw new InvalidOperationException($"Valore carta non valido: {Valore}")
      };
    }
  }
}

