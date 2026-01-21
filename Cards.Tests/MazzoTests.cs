using Xunit;
using System;

namespace Cards.Tests;

public class MazzoTests
{
  [Fact]
  public void Mazzo_NuovoMazzo_Ha52Carte()
  {
    var mazzo = new Mazzo();
    Assert.Equal(52, mazzo.Carte.Count);
  }

  [Fact]
  public void PrimaCarta_NuovoMazzo_E2()
  {
    var mazzo = new Mazzo();
    Assert.Equal('2', mazzo.Carte[0].Valore);
    Assert.Equal(Seme.Cuori, mazzo.Carte[0].Seme);
  }
}
