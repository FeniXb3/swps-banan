class PlayerClone : Player
{
    private Player mothership;

    public PlayerClone(Player mothership, string avatar) : base(mothership.name, avatar)
    {
        this.mothership = mothership;
    }

    public override string ChooseAction()
    {
        return mothership.chosenAction;
    }
}