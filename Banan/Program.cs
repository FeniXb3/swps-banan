Console.CursorVisible = false;

Dictionary<ConsoleKey, Point> directionsMap = new Dictionary<ConsoleKey, Point>();
directionsMap.Add(ConsoleKey.A, new Point(-1, 0));
directionsMap.Add(ConsoleKey.D, new Point(1, 0));
directionsMap.Add(ConsoleKey.W, new Point(0, -1));
directionsMap.Add(ConsoleKey.S, new Point(0, 1));

Player hero = new Player("Snake");
hero.speed = 1;
hero.y = 1;
hero.x = 3;


while (true)
{
    Console.SetCursorPosition(0, 0);
    Console.WriteLine($"({hero.x}, {hero.y})    ");

    Console.SetCursorPosition(hero.x, hero.y);
    Console.Write("@");

    ConsoleKeyInfo pressedKey = Console.ReadKey(true);

    if (!directionsMap.ContainsKey(pressedKey.Key))
    {
        continue;
    }

    Console.SetCursorPosition(hero.x, hero.y);
    Console.Write(" ");

    Point direction = directionsMap[pressedKey.Key];

    hero.x += direction.x * hero.speed;
    hero.y += direction.y * hero.speed;

    hero.x = Math.Clamp(hero.x, 0, Console.BufferWidth - 1);
    hero.y = Math.Clamp(hero.y, 0, Console.BufferHeight - 1);

    hero.speed += 1;
}

Console.WriteLine("Press Space to continue...");
ConsoleKeyInfo keyInfo = Console.ReadKey(true);
while (keyInfo.Key != ConsoleKey.Spacebar)
{
    keyInfo = Console.ReadKey(true);
}
