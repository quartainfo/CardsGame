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

  // Test IsPoker
  [Fact]
  public void IsPoker_ManoConPoker_RitornaTrue()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'A'),
      new Carta(Seme.Picche, 'A'),
      new Carta(Seme.Quadri, 'A'),
      new Carta(Seme.Fiori, 'A'),
      new Carta(Seme.Cuori, 'K')
    };
    var mano = new Mano(carte);
    Assert.True(mano.IsPoker());
  }

  [Fact]
  public void IsPoker_ManoSenzaPoker_RitornaFalse()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'A'),
      new Carta(Seme.Picche, 'A'),
      new Carta(Seme.Quadri, 'K'),
      new Carta(Seme.Fiori, 'K'),
      new Carta(Seme.Cuori, 'Q')
    };
    var mano = new Mano(carte);
    Assert.False(mano.IsPoker());
  }

  // Test IsFull
  [Fact]
  public void IsFull_ManoConFull_RitornaTrue()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'A'),
      new Carta(Seme.Picche, 'A'),
      new Carta(Seme.Quadri, 'A'),
      new Carta(Seme.Fiori, 'K'),
      new Carta(Seme.Cuori, 'K')
    };
    var mano = new Mano(carte);
    Assert.True(mano.IsFull());
  }

  [Fact]
  public void IsFull_ManoSenzaFull_RitornaFalse()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'A'),
      new Carta(Seme.Picche, 'A'),
      new Carta(Seme.Quadri, 'K'),
      new Carta(Seme.Fiori, 'Q'),
      new Carta(Seme.Cuori, 'J')
    };
    var mano = new Mano(carte);
    Assert.False(mano.IsFull());
  }

  // Test IsColore
  [Fact]
  public void IsColore_ManoConColore_RitornaTrue()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'A'),
      new Carta(Seme.Cuori, 'K'),
      new Carta(Seme.Cuori, 'Q'),
      new Carta(Seme.Cuori, '9'),
      new Carta(Seme.Cuori, '2')
    };
    var mano = new Mano(carte);
    Assert.True(mano.IsColore());
  }

  [Fact]
  public void IsColore_ManoSenzaColore_RitornaFalse()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'A'),
      new Carta(Seme.Picche, 'K'),
      new Carta(Seme.Quadri, 'Q'),
      new Carta(Seme.Fiori, '9'),
      new Carta(Seme.Cuori, '2')
    };
    var mano = new Mano(carte);
    Assert.False(mano.IsColore());
  }

  // Test IsScala
  [Theory]
  [InlineData('2', '3', '4', '5', '6')]
  [InlineData('9', 'T', 'J', 'Q', 'K')]
  [InlineData('A', '2', '3', '4', '5')]
  public void IsScala_ManoConScala_RitornaTrue(char v1, char v2, char v3, char v4, char v5)
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, v1),
      new Carta(Seme.Picche, v2),
      new Carta(Seme.Quadri, v3),
      new Carta(Seme.Fiori, v4),
      new Carta(Seme.Cuori, v5)
    };
    var mano = new Mano(carte);
    Assert.True(mano.IsScala());
  }

  [Fact]
  public void IsScala_ManoSenzaScala_RitornaFalse()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'A'),
      new Carta(Seme.Picche, 'K'),
      new Carta(Seme.Quadri, 'Q'),
      new Carta(Seme.Fiori, '9'),
      new Carta(Seme.Cuori, '2')
    };
    var mano = new Mano(carte);
    Assert.False(mano.IsScala());
  }

  // Test IsTris
  [Fact]
  public void IsTris_ManoConTris_RitornaTrue()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'A'),
      new Carta(Seme.Picche, 'A'),
      new Carta(Seme.Quadri, 'A'),
      new Carta(Seme.Fiori, 'K'),
      new Carta(Seme.Cuori, 'Q')
    };
    var mano = new Mano(carte);
    Assert.True(mano.IsTris());
  }

  [Fact]
  public void IsTris_ManoSenzaTris_RitornaFalse()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'A'),
      new Carta(Seme.Picche, 'A'),
      new Carta(Seme.Quadri, 'K'),
      new Carta(Seme.Fiori, 'K'),
      new Carta(Seme.Cuori, 'Q')
    };
    var mano = new Mano(carte);
    Assert.False(mano.IsTris());
  }

  // Test IsDoppiaCoppia
  [Fact]
  public void IsDoppiaCoppia_ManoConDoppiaCoppia_RitornaTrue()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'A'),
      new Carta(Seme.Picche, 'A'),
      new Carta(Seme.Quadri, 'K'),
      new Carta(Seme.Fiori, 'K'),
      new Carta(Seme.Cuori, 'Q')
    };
    var mano = new Mano(carte);
    Assert.True(mano.IsDoppiaCoppia());
  }

  [Fact]
  public void IsDoppiaCoppia_ManoSenzaDoppiaCoppia_RitornaFalse()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'A'),
      new Carta(Seme.Picche, 'A'),
      new Carta(Seme.Quadri, 'K'),
      new Carta(Seme.Fiori, 'Q'),
      new Carta(Seme.Cuori, 'J')
    };
    var mano = new Mano(carte);
    Assert.False(mano.IsDoppiaCoppia());
  }

  // Test IsCoppia
  [Fact]
  public void IsCoppia_ManoConCoppia_RitornaTrue()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'A'),
      new Carta(Seme.Picche, 'A'),
      new Carta(Seme.Quadri, 'K'),
      new Carta(Seme.Fiori, 'Q'),
      new Carta(Seme.Cuori, 'J')
    };
    var mano = new Mano(carte);
    Assert.True(mano.IsCoppia());
  }

  [Fact]
  public void IsCoppia_ManoSenzaCoppia_RitornaFalse()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'A'),
      new Carta(Seme.Picche, 'K'),
      new Carta(Seme.Quadri, 'Q'),
      new Carta(Seme.Fiori, 'J'),
      new Carta(Seme.Cuori, 'T')
    };
    var mano = new Mano(carte);
    Assert.False(mano.IsCoppia());
  }

  // Test IsCartaAlta
  [Fact]
  public void IsCartaAlta_ManoConCartaAlta_RitornaTrue()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'A'),
      new Carta(Seme.Picche, 'K'),
      new Carta(Seme.Quadri, 'Q'),
      new Carta(Seme.Fiori, 'J'),
      new Carta(Seme.Cuori, '9')
    };
    var mano = new Mano(carte);
    Assert.True(mano.IsCartaAlta());
  }

  [Fact]
  public void IsCartaAlta_ManoConCombinazione_RitornaFalse()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'A'),
      new Carta(Seme.Picche, 'A'),
      new Carta(Seme.Quadri, 'K'),
      new Carta(Seme.Fiori, 'Q'),
      new Carta(Seme.Cuori, 'J')
    };
    var mano = new Mano(carte);
    Assert.False(mano.IsCartaAlta());
  }

  // Test constructor
  [Fact]
  public void Constructor_CarteNonUgualiA5_LanceaEccezione()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'A'),
      new Carta(Seme.Picche, 'K'),
      new Carta(Seme.Quadri, 'Q')
    };
    Assert.Throws<ArgumentException>(() => new Mano(carte));
  }
}

