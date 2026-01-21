using System;
using Xunit;
using Cards;

namespace Cards.Tests;

public class ManoTestsCompleti
{
  // ===== CONSTRUCTOR TESTS =====
  [Fact]
  public void Constructor_Con5Carte_CreaManoValida()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, '2'),
      new Carta(Seme.Cuori, '3'),
      new Carta(Seme.Cuori, '4'),
      new Carta(Seme.Cuori, '5'),
      new Carta(Seme.Cuori, '6')
    };
    var mano = new Mano(carte);
    Assert.NotNull(mano);
    Assert.Equal(5, mano.Carte.Count);
  }

  [Fact]
  public void Constructor_ConMenoSpettacolo5Carte_LanciaArgumentException()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, '2'),
      new Carta(Seme.Cuori, '3'),
      new Carta(Seme.Cuori, '4')
    };
    Assert.Throws<ArgumentException>(() => new Mano(carte));
  }

  [Fact]
  public void Constructor_ConPiuDi5Carte_LanciaArgumentException()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, '2'),
      new Carta(Seme.Cuori, '3'),
      new Carta(Seme.Cuori, '4'),
      new Carta(Seme.Cuori, '5'),
      new Carta(Seme.Cuori, '6'),
      new Carta(Seme.Cuori, '7')
    };
    Assert.Throws<ArgumentException>(() => new Mano(carte));
  }

  // ===== SCALA REALE TESTS =====
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

  [Theory]
  [InlineData(Seme.Quadri)]
  [InlineData(Seme.Fiori)]
  [InlineData(Seme.Picche)]
  public void IsScalaReale_ScalaRealeConDiversiSemi_RitornaTrue(Seme seme)
  {
    var carte = new List<Carta>
    {
      new Carta(seme, 'A'),
      new Carta(seme, 'K'),
      new Carta(seme, 'Q'),
      new Carta(seme, 'J'),
      new Carta(seme, 'T')
    };
    var mano = new Mano(carte);
    Assert.True(mano.IsScalaReale());
  }

  [Fact]
  public void IsScalaReale_CarteDiversiSemi_RitornaFalse()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'A'),
      new Carta(Seme.Quadri, 'K'),
      new Carta(Seme.Cuori, 'Q'),
      new Carta(Seme.Cuori, 'J'),
      new Carta(Seme.Cuori, 'T')
    };
    var mano = new Mano(carte);
    Assert.False(mano.IsScalaReale());
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

  // ===== SCALA COLORE TESTS =====
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

  [Fact]
  public void IsScalaColore_ScalaConDiversiSemi_RitornaFalse()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, '2'),
      new Carta(Seme.Quadri, '3'),
      new Carta(Seme.Cuori, '4'),
      new Carta(Seme.Cuori, '5'),
      new Carta(Seme.Cuori, '6')
    };
    var mano = new Mano(carte);
    Assert.False(mano.IsScalaColore());
  }

  // ===== POKER TESTS =====
  [Fact]
  public void IsPoker_ManoConPoker_RitornaTrue()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'K'),
      new Carta(Seme.Quadri, 'K'),
      new Carta(Seme.Fiori, 'K'),
      new Carta(Seme.Picche, 'K'),
      new Carta(Seme.Cuori, '2')
    };
    var mano = new Mano(carte);
    Assert.True(mano.IsPoker());
  }

  [Fact]
  public void IsPoker_ManoSenzaPoker_RitornaFalse()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'K'),
      new Carta(Seme.Quadri, 'K'),
      new Carta(Seme.Fiori, 'Q'),
      new Carta(Seme.Picche, 'Q'),
      new Carta(Seme.Cuori, '2')
    };
    var mano = new Mano(carte);
    Assert.False(mano.IsPoker());
  }

  // ===== FULL TESTS =====
  [Fact]
  public void IsFull_ManoConFull_RitornaTrue()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'K'),
      new Carta(Seme.Quadri, 'K'),
      new Carta(Seme.Fiori, 'K'),
      new Carta(Seme.Picche, '2'),
      new Carta(Seme.Cuori, '2')
    };
    var mano = new Mano(carte);
    Assert.True(mano.IsFull());
  }

  [Fact]
  public void IsFull_ManoConTris_RitornaFalse()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'K'),
      new Carta(Seme.Quadri, 'K'),
      new Carta(Seme.Fiori, 'K'),
      new Carta(Seme.Picche, '2'),
      new Carta(Seme.Cuori, '3')
    };
    var mano = new Mano(carte);
    Assert.False(mano.IsFull());
  }

  // ===== COLORE TESTS =====
  [Fact]
  public void IsColore_ManoConColore_RitornaTrue()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, '2'),
      new Carta(Seme.Cuori, '5'),
      new Carta(Seme.Cuori, '7'),
      new Carta(Seme.Cuori, 'J'),
      new Carta(Seme.Cuori, 'K')
    };
    var mano = new Mano(carte);
    Assert.True(mano.IsColore());
  }

  [Fact]
  public void IsColore_ManoSenzaColore_RitornaFalse()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, '2'),
      new Carta(Seme.Quadri, '5'),
      new Carta(Seme.Cuori, '7'),
      new Carta(Seme.Cuori, 'J'),
      new Carta(Seme.Cuori, 'K')
    };
    var mano = new Mano(carte);
    Assert.False(mano.IsColore());
  }

  // ===== SCALA TESTS =====
  [Theory]
  [InlineData('2', '3', '4', '5', '6')]
  [InlineData('5', '6', '7', '8', '9')]
  [InlineData('9', 'T', 'J', 'Q', 'K')]
  public void IsScala_ManoConScalaNormale_RitornaTrue(char v1, char v2, char v3, char v4, char v5)
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, v1),
      new Carta(Seme.Quadri, v2),
      new Carta(Seme.Fiori, v3),
      new Carta(Seme.Picche, v4),
      new Carta(Seme.Cuori, v5)
    };
    var mano = new Mano(carte);
    Assert.True(mano.IsScala());
  }

  [Fact]
  public void IsScala_ManoConAssoBalto_RitornaTrue()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'A'),
      new Carta(Seme.Quadri, '2'),
      new Carta(Seme.Fiori, '3'),
      new Carta(Seme.Picche, '4'),
      new Carta(Seme.Cuori, '5')
    };
    var mano = new Mano(carte);
    Assert.True(mano.IsScala());
  }

  [Fact]
  public void IsScala_ManoSenzaScala_RitornaFalse()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, '2'),
      new Carta(Seme.Quadri, '3'),
      new Carta(Seme.Fiori, '5'),
      new Carta(Seme.Picche, '7'),
      new Carta(Seme.Cuori, 'K')
    };
    var mano = new Mano(carte);
    Assert.False(mano.IsScala());
  }

  // ===== TRIS TESTS =====
  [Fact]
  public void IsTris_ManoConTris_RitornaTrue()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'K'),
      new Carta(Seme.Quadri, 'K'),
      new Carta(Seme.Fiori, 'K'),
      new Carta(Seme.Picche, '2'),
      new Carta(Seme.Cuori, '3')
    };
    var mano = new Mano(carte);
    Assert.True(mano.IsTris());
  }

  [Fact]
  public void IsTris_ManoConFull_RitornaFalse()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'K'),
      new Carta(Seme.Quadri, 'K'),
      new Carta(Seme.Fiori, 'K'),
      new Carta(Seme.Picche, '2'),
      new Carta(Seme.Cuori, '2')
    };
    var mano = new Mano(carte);
    Assert.False(mano.IsTris());
  }

  // ===== DOPPIA COPPIA TESTS =====
  [Fact]
  public void IsDoppiaCoppia_ManoConDoppiaCoppia_RitornaTrue()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'K'),
      new Carta(Seme.Quadri, 'K'),
      new Carta(Seme.Fiori, 'Q'),
      new Carta(Seme.Picche, 'Q'),
      new Carta(Seme.Cuori, '2')
    };
    var mano = new Mano(carte);
    Assert.True(mano.IsDoppiaCoppia());
  }

  [Fact]
  public void IsDoppiaCoppia_ManoConUnaCoppia_RitornaFalse()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'K'),
      new Carta(Seme.Quadri, 'K'),
      new Carta(Seme.Fiori, 'Q'),
      new Carta(Seme.Picche, '3'),
      new Carta(Seme.Cuori, '2')
    };
    var mano = new Mano(carte);
    Assert.False(mano.IsDoppiaCoppia());
  }

  // ===== COPPIA TESTS =====
  [Fact]
  public void IsCoppia_ManoConUnaCoppia_RitornaTrue()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'K'),
      new Carta(Seme.Quadri, 'K'),
      new Carta(Seme.Fiori, 'Q'),
      new Carta(Seme.Picche, '3'),
      new Carta(Seme.Cuori, '2')
    };
    var mano = new Mano(carte);
    Assert.True(mano.IsCoppia());
  }

  [Fact]
  public void IsCoppia_ManoSenzaCoppia_RitornaFalse()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'K'),
      new Carta(Seme.Quadri, 'Q'),
      new Carta(Seme.Fiori, 'J'),
      new Carta(Seme.Picche, '3'),
      new Carta(Seme.Cuori, '2')
    };
    var mano = new Mano(carte);
    Assert.False(mano.IsCoppia());
  }

  // ===== CARTA ALTA TESTS =====
  [Fact]
  public void IsCartaAlta_ManoCartaAlta_RitornaTrue()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'K'),
      new Carta(Seme.Quadri, 'Q'),
      new Carta(Seme.Fiori, 'J'),
      new Carta(Seme.Picche, '9'),
      new Carta(Seme.Cuori, '2')
    };
    var mano = new Mano(carte);
    Assert.True(mano.IsCartaAlta());
  }

  [Fact]
  public void IsCartaAlta_ManoConCoppia_RitornaFalse()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'K'),
      new Carta(Seme.Quadri, 'K'),
      new Carta(Seme.Fiori, 'Q'),
      new Carta(Seme.Picche, '3'),
      new Carta(Seme.Cuori, '2')
    };
    var mano = new Mano(carte);
    Assert.False(mano.IsCartaAlta());
  }

  // ===== COMPARETO TESTS =====
  [Fact]
  public void CompareTo_ScalaRealeMaggioreDellaCartaAlta_RitornaPositivo()
  {
    var mano1 = new Mano(new List<Carta>
    {
      new Carta(Seme.Cuori, 'A'),
      new Carta(Seme.Cuori, 'K'),
      new Carta(Seme.Cuori, 'Q'),
      new Carta(Seme.Cuori, 'J'),
      new Carta(Seme.Cuori, 'T')
    });

    var mano2 = new Mano(new List<Carta>
    {
      new Carta(Seme.Picche, 'A'),
      new Carta(Seme.Quadri, 'K'),
      new Carta(Seme.Fiori, 'Q'),
      new Carta(Seme.Cuori, 'J'),
      new Carta(Seme.Picche, '2')
    });

    Assert.True(mano1.CompareTo(mano2) > 0);
  }

  [Fact]
  public void CompareTo_StessoRangoConCarteAlteSuccessive_RitornaPositivoPerCartePiuAlte()
  {
    var mano1 = new Mano(new List<Carta>
    {
      new Carta(Seme.Cuori, 'A'),
      new Carta(Seme.Quadri, 'Q'),
      new Carta(Seme.Fiori, 'J'),
      new Carta(Seme.Picche, '9'),
      new Carta(Seme.Cuori, '2')
    });

    var mano2 = new Mano(new List<Carta>
    {
      new Carta(Seme.Picche, 'K'),
      new Carta(Seme.Fiori, 'Q'),
      new Carta(Seme.Cuori, 'J'),
      new Carta(Seme.Quadri, '9'),
      new Carta(Seme.Picche, '2')
    });

    Assert.True(mano1.CompareTo(mano2) > 0);
  }

  [Fact]
  public void CompareTo_ManIIdentiche_RitornaZero()
  {
    var carte1 = new List<Carta>
    {
      new Carta(Seme.Cuori, 'K'),
      new Carta(Seme.Quadri, 'K'),
      new Carta(Seme.Fiori, 'Q'),
      new Carta(Seme.Picche, '3'),
      new Carta(Seme.Cuori, '2')
    };
    var carte2 = new List<Carta>
    {
      new Carta(Seme.Picche, 'K'),
      new Carta(Seme.Cuori, 'K'),
      new Carta(Seme.Quadri, 'Q'),
      new Carta(Seme.Fiori, '3'),
      new Carta(Seme.Picche, '2')
    };

    var mano1 = new Mano(carte1);
    var mano2 = new Mano(carte2);

    Assert.Equal(0, mano1.CompareTo(mano2));
  }

  // ===== TOSTRING TESTS =====
  [Fact]
  public void ToString_ManoConScalaReale_RitornaDescrizione()
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
    Assert.Contains("Scala Reale", mano.ToString());
  }

  [Fact]
  public void ToString_ManoConCoppia_RitornaDescrizione()
  {
    var carte = new List<Carta>
    {
      new Carta(Seme.Cuori, 'K'),
      new Carta(Seme.Quadri, 'K'),
      new Carta(Seme.Fiori, 'Q'),
      new Carta(Seme.Picche, '3'),
      new Carta(Seme.Cuori, '2')
    };
    var mano = new Mano(carte);
    Assert.Contains("Coppia", mano.ToString());
  }
}
