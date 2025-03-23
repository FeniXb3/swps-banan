Console.CursorVisible = false;
Player hero = new Player("Snake");
hero.speed = 5;
hero.y = 1;
hero.x = 3;

Console.SetCursorPosition(0, 0);
Console.WriteLine($"({hero.x}, {hero.y})    ");

Console.SetCursorPosition(hero.x, hero.y);
Console.Write("@");

while (true)
{
    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
    Console.SetCursorPosition(hero.x, hero.y);
    Console.Write(" ");
    if (pressedKey.Key == ConsoleKey.A)
    {
        hero.x -= hero.speed;
    }
    else if (pressedKey.Key == ConsoleKey.D)
    {
        hero.x += hero.speed;
    }
    else if (pressedKey.Key == ConsoleKey.W)
    {
        hero.y -= hero.speed;
    }
    else if (pressedKey.Key == ConsoleKey.S)
    {
        hero.y += hero.speed;
    }

    hero.x = Math.Clamp(hero.x, 0, Console.BufferWidth - 1);
    hero.y = Math.Clamp(hero.y, 0, Console.BufferHeight - 1);

    Console.SetCursorPosition(0, 0);
    Console.WriteLine($"({hero.x}, {hero.y})    ");

    Console.SetCursorPosition(hero.x, hero.y);
    Console.Write("@");
}

Console.WriteLine("Press Space to continue...");
ConsoleKeyInfo keyInfo = Console.ReadKey(true);
while (keyInfo.Key != ConsoleKey.Spacebar)
{
    keyInfo = Console.ReadKey(true);
}
