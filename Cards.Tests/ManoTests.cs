using System;
using Xunit;
using Cards;

namespace Cards.Tests;

public class ManoTests
{

  public static IEnumerable<object[]> IsPoker_TestData()
  {
    return [
      [
        new Carta(Seme.Cuori, '9'),
        new Carta(Seme.Quadri, '9'),
        new Carta(Seme.Fiori, '9'),
        new Carta(Seme.Picche, '9'),
        new Carta(Seme.Cuori, 'K')
      ],
      [
        new Carta(Seme.Cuori, 'A'),
        new Carta(Seme.Quadri, 'A'),
        new Carta(Seme.Fiori, 'A'),
        new Carta(Seme.Picche, 'A'),
        new Carta(Seme.Cuori, '2')
      ]];
  }

  [MemberData(nameof(IsPoker_TestData))]
  [Theory]
  public void IsPoker_ManoConPoker_RitornaTrue(List<Carta> carte)
  {
    var mano = new Mano(carte);
    Assert.True(mano.IsPoker());
  }

  [Fact]
  public void IsScalaReale_ManoConScalaReale_RitornaTrue()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'A'),
      new Carta(Seme.Cuori, 'K'),
      new Carta(Seme.Cuori, 'Q'),
      new Carta(Seme.Cuori, 'J'),
      new Carta(Seme.Cuori, 'T')
    };
    var mano = new Mano(carte);
    Assert.True(mano.IsScalaReale());
  }

  [Fact]
  public void IsScalaReale_ManoSenzaScalaReale_RitornaFalse()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, '9'),
      new Carta(Seme.Cuori, 'K'),
      new Carta(Seme.Cuori, 'Q'),
      new Carta(Seme.Cuori, 'J'),
      new Carta(Seme.Cuori, 'T')
    };
    var mano = new Mano(carte);
    Assert.False(mano.IsScalaReale());
  }

  [Theory]
  [InlineData('2', '3', '4', '5', '6')]
  [InlineData('9', 'T', 'J', 'Q', 'K')]
  [InlineData('T', 'J', 'Q', 'K', 'A')]
  public void IsScalaColore_ManoConScalaColore_RitornaTrue(char v1, char v2, char v3, char v4, char v5)
  {
    var carte = new List<Carta>
  {
    new Carta(Seme.Picche, v1),
    new Carta(Seme.Picche, v2),
    new Carta(Seme.Picche, v3),
    new Carta(Seme.Picche, v4),
    new Carta(Seme.Picche, v5)
  };
    var mano = new Mano(carte);
    Assert.True(mano.IsScalaColore());

  }
}
