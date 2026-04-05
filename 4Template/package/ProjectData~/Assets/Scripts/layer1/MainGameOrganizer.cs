using UnityEngine;

public class MainGameOrganizer : OrganizerBase, IPlayerControllable
{
    public PlayerMovement movement;


    public override void Start()
    {
        if (DungeonMaster.Instance != null)
        {
            initialState = new ShardsState(this);
            DungeonMaster.Instance.RegisterScene(this);
        }
    }

    public void StopPlayer()
    {
        movement.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void ResumePlayer()
    {
        movement.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
}
