using System;
using Xunit;
using Cards;

namespace Cards.Tests;

public class ManoTests
{

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
