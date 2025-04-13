Console.CursorVisible = false;
Player hero = new Player("Snake");
hero.speed = 5;
hero.y = 1;
hero.x = 3;

Dictionary<ConsoleKey, Point> directionsMap = new Dictionary<ConsoleKey, Point>();
directionsMap.Add(ConsoleKey.A, new Point(-hero.speed, 0));
directionsMap.Add(ConsoleKey.D, new Point(hero.speed, 0));
directionsMap.Add(ConsoleKey.W, new Point(0, -hero.speed));
directionsMap.Add(ConsoleKey.S, new Point(0, hero.speed));

Console.SetCursorPosition(0, 0);
Console.WriteLine($"({hero.x}, {hero.y})    ");

Console.SetCursorPosition(hero.x, hero.y);
Console.Write("@");

while (true)
{
    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
    Console.SetCursorPosition(hero.x, hero.y);
    Console.Write(" ");
    Point direction = directionsMap[pressedKey.Key];

    hero.x += direction.x;
    hero.y += direction.y;

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
