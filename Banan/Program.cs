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
        if (hero.x - hero.speed >= 0)
        {
            hero.x -= hero.speed;
        }
    }
    if (pressedKey.Key == ConsoleKey.D)
    {
        if (hero.x + hero.speed <= Console.BufferWidth - 1)
        {
            hero.x += hero.speed;
        }
    }
    if (pressedKey.Key == ConsoleKey.W)
    {
        if (hero.y - hero.speed >= 0)
        {
            hero.y -= hero.speed;
        }
    }
    if (pressedKey.Key == ConsoleKey.S)
    {
        if (hero.y + hero.speed <= Console.BufferHeight - 1)
        {
            hero.y += hero.speed;
        }
    }

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
