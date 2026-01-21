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
}
