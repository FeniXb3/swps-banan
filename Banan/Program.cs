Player hero = new Player("Snake");

Console.WriteLine(hero.x);

while (true)
{
    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
    if (pressedKey.Key == ConsoleKey.A)
    {
        hero.x -= 1;
    }
    if (pressedKey.Key == ConsoleKey.D)
    {
        hero.x += 1;
    }
    if (pressedKey.Key == ConsoleKey.W)
    {
        hero.y -= 1;
    }
    if (pressedKey.Key == ConsoleKey.S)
    {
        hero.y += 1;
    }

    Console.Clear();
    Console.SetCursorPosition(0, 0);
    Console.WriteLine($"({hero.x}, {hero.y})");

    Console.SetCursorPosition(hero.x, hero.y);
    Console.Write("@");
}

Console.WriteLine("Press Space to continue...");
ConsoleKeyInfo keyInfo = Console.ReadKey(true);
while (keyInfo.Key != ConsoleKey.Spacebar)
{
    keyInfo = Console.ReadKey(true);
}
