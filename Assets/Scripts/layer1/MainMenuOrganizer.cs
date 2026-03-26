public class MainMenuOrganizer : OrganizerBase
{
    public override string initialStateName { get { return "MainMenu"; } }

    public override void Start()
    {
        if (DungeonMaster.Instance != null)
        {
            DungeonMaster.Instance.RegisterScene(this);
        }
    }
}
