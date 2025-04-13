class Player
{
    public string name;
    public Point position;
    public int speed = 1;
    public string avatar;

    public Player(string name, string avatar)
    {
        this.name = name;
        this.avatar = avatar;
    }
}


/*
Klasa Player
- dane:
    - name
    - hp
    - maxhp
    - attackStrength
    - stamina
    - maxstamina
    - weapon
    - footSize
- akcje:
    - move
    - attack
    - heal
    - dance
    - pickUpItems

*/