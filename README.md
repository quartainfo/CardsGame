# CardsGame

Questo progetto didattico serve a modellare, all'interno di una libreria (.dll), classi per rappresentare carte da gioco e valutare mani di poker. Un progetto separato (con interfaccia grafica WinForms o .NET MAUI) fornirà la rappresentazione visuale e l'interazione utente basata su questa libreria.

**Overview**

- **Scopo:** offrire una libreria riusabile che espone modelli e logica per carte, mazzi e valutazione di mani di poker.
- **Target:** scenari didattici, esercizi di programmazione orientata agli oggetti e integrazione in UI desktop (.NET).

**Caratteristiche principali**

- **Modelli core:** `Card`, `Suit`, `Rank`, `Deck`, `Hand`.
- **Valutazione poker:** rilevamento e confronto di mani (High Card, Pair, Two Pair, Three of a Kind, Straight, Flush, Full House, Four of a Kind, Straight Flush, Royal Flush).
- **API semplice:** classi e metodi pensati per essere referenziati dalla UI o da altri progetti.
- **Test unitari:** suite di test per verificare correttezza dell'algoritmo di valutazione delle mani.

**Architettura suggerita**

- `CardsGame.Core` (libreria .NET Standard/.NET 6+): contiene classi di dominio e l'algoritmo di valutazione.
- `CardsGame.UI` (WinForms o .NET MAUI): progetto separato che referenzia la libreria e fornisce interfaccia grafica.
- `CardsGame.Tests`: progetto di test con test unitari per la logica di valutazione.

**Esempio rapido d'uso**

```csharp
// Creazione di un mazzo e distribuzione di una mano
var deck = new Deck();
deck.Shuffle();
var hand = deck.Draw(5);

// Valutazione
var result = PokerEvaluator.Evaluate(hand);
Console.WriteLine($"Mano: {result.Rank} ({result.Description})");
```

**Come compilare**

- Requisiti: .NET SDK 6.0 o superiore.
- Per buildare la soluzione:

```bash
dotnet build
```

- Per eseguire i test (se presenti):

```bash
dotnet test
```

**Integrare la libreria in un progetto UI**

- Aggiungere una reference al progetto `CardsGame.Core` oppure al file `.dll` generato.
- La UI (WinForms/.NET MAUI) può usare le classi `Deck` e `Card` per creare la rappresentazione grafica delle carte e chiamare `PokerEvaluator` per aggiornare lo stato della mano.

**Contribuire**

- Fork e pull request benvenuti.
- Includere test per nuove regole o correzioni dell'algoritmo.
