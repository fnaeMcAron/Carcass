public class MainGameOrganizer : OrganizerBase
{
    public PlayerMovement movement;
    public override string initialStateName { get { return "MainGame"; } }

    public override void Start()
    {
        if (DungeonMaster.Instance != null)
        {
            DungeonMaster.Instance.RegisterScene(this);
        }
    }
}
