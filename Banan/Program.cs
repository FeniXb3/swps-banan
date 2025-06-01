Console.CursorVisible = false;

Dictionary<ConsoleKey, string> keyActionMap = new Dictionary<ConsoleKey, string>();
keyActionMap.Add(ConsoleKey.A, "moveLeft");
keyActionMap.Add(ConsoleKey.D, "moveRight");
keyActionMap.Add(ConsoleKey.W, "moveUp");
keyActionMap.Add(ConsoleKey.S, "moveDown");

Dictionary<string, Point> directionsMap = new Dictionary<string, Point>();
directionsMap.Add("moveLeft", new Point(-1, 0));
directionsMap.Add("moveRight", new Point(1, 0));
directionsMap.Add("moveUp", new Point(0, -1));
directionsMap.Add("moveDown", new Point(0, 1));

Point startingPoint = new Point(13, 1);
Player hero = new Player("Snake", "@");
hero.speed = 1;
hero.position = startingPoint;

List<Player> clones = new List<Player>();
clones.Add(hero);

string[] level =
[
    "#####################################",
    "#...................................#",
    "#....#...............&.....##########",
    "#..............................#",
    "#..........................#####",
    "#........#.................#",
    "#..........................#",
    "#..........................#",
    "#..........................#",
    "#..........................#",
    "#..........................#",
    "#..........................#",
    "#..............#...........#",
    "#..............#...........#",
    "#..............#...........#",
    "############################",
];

foreach (string row in level)
{
    Console.WriteLine(row);
}

while (true)
{
    Console.SetCursorPosition(12, 0);
    Console.Write(hero.speed);
    foreach (Player element in clones)
    {
        Console.SetCursorPosition(element.position.x, element.position.y);
        Console.Write(element.avatar);
    }

    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
    string chosenAction = keyActionMap.GetValueOrDefault(pressedKey.Key, "pass");

    if (!directionsMap.ContainsKey(chosenAction))
    {
        if (pressedKey.Key == ConsoleKey.C)
        {
            Player clone = new Player(hero.name, "C");
            clone.position = startingPoint;
            clones.Add(clone);
        }

        continue;
    }

    foreach (Player element in clones)
    {
        RedrawCell(element.position);

        Point direction = directionsMap[chosenAction];
        element.Move(direction, level);
    }
}

Console.WriteLine("Press Space to continue...");
ConsoleKeyInfo keyInfo = Console.ReadKey(true);
while (keyInfo.Key != ConsoleKey.Spacebar)
{
    keyInfo = Console.ReadKey(true);
}

void RedrawCell(Point position)
{
    Console.SetCursorPosition(position.x, position.y);
    string row = level[position.y];
    char cellValue = row[position.x];
    Console.Write(cellValue);
}