using Cards;

Console.WriteLine("=== GIOCO DI CARTE - POKER ===\n");

// Crea e mescola il mazzo
Mazzo mazzo = new Mazzo();
Console.WriteLine($"Mazzo creato con {mazzo.CarteRimanenti} carte");

mazzo.Mescola();
Console.WriteLine("Mazzo mescolato!\n");

// Distribuisce 3 mani
Console.WriteLine("Distribuzione di 3 mani:\n");
Mano mano1 = mazzo.Distribuisci();
Mano mano2 = mazzo.Distribuisci();
Mano mano3 = mazzo.Distribuisci();

Console.WriteLine($"Mano 1: {mano1}");
Console.WriteLine($"Mano 2: {mano2}");
Console.WriteLine($"Mano 3: {mano3}\n");

Console.WriteLine($"Carte rimanenti nel mazzo: {mazzo.CarteRimanenti}\n");

// Confronta le mani
Console.WriteLine("=== CONFRONTO MANI ===");
if (mano1.CompareTo(mano2) > 0)
    Console.WriteLine("Mano 1 batte Mano 2");
else if (mano1.CompareTo(mano2) < 0)
    Console.WriteLine("Mano 2 batte Mano 1");
else
    Console.WriteLine("Mano 1 e Mano 2 sono uguali");

Console.WriteLine("\nPremi un tasto per continuare...");
Console.ReadKey();
