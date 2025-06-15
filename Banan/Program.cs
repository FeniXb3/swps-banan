Console.CursorVisible = false;

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

NonPlayerCharacter npc = new NonPlayerCharacter("Liquid", "L");
npc.position = new Point(5, 5);

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

foreach (Player element in clones)
{
    element.Display();
}

npc.Display();

while (true)
{
    Console.SetCursorPosition(12, 0);
    Console.Write(hero.speed);
    // foreach (Player element in clones)
    for (int i = 0; i < clones.Count; i++)
    {
        Player element = clones[i];
        element.Display();
        
        string chosenAction = element.ChooseAction();
        if (!directionsMap.ContainsKey(chosenAction))
        {
            if (chosenAction == "clone")
            {
                PlayerClone clone = new PlayerClone(hero.name, "C");
                clone.position = startingPoint;
                clones.Add(clone);
            }

            continue;
        }

        RedrawCell(element.position);

        Point direction = directionsMap[chosenAction];
        element.Move(direction, level);
    }

    npc.Display();
    string npcAction = npc.ChooseAction();
    Point npcDirection = directionsMap[npcAction];
    RedrawCell(npc.position);
    npc.Move(npcDirection, level);
    npc.Display();
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