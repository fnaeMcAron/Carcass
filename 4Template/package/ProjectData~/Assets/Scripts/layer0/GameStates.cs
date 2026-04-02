using UnityEngine;
using UnityEngine.InputSystem;

public abstract class GameState
{
    public virtual void Enter(DungeonMaster dm) { }
    public virtual void Exit(DungeonMaster dm) { }
    public virtual void Update(DungeonMaster dm) { }
}

public class ShardsState : GameState
{
    public override void Enter(DungeonMaster dm)
    {
        dm.GetComponent<PlayerInput>().SwitchCurrentActionMap("Shards");
    }

    public override void Exit(DungeonMaster dm)
    {

    }

    public override void Update(DungeonMaster dm)
    {

    }
}

public class TerminalState : GameState
{
    public override void Enter(DungeonMaster dm)
    {
        dm.GetComponent<PlayerInput>().SwitchCurrentActionMap("Terminal");
        //(dm.currentSceneContext as MainGameOrganizer)?.movement.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        var organizer = dm.currentSceneContext as MainGameOrganizer;
        if (organizer != null)
        {
            organizer.movement.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
        dm.LoadLevelAdditive("TerminalGame");
    }

    public override void Exit(DungeonMaster dm)
    {
        //(dm.currentSceneContext as MainGameOrganizer)?.movement.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        var organizer = dm.currentSceneContext as MainGameOrganizer;
        if (organizer != null)
        {
            organizer.movement.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
        dm.UnloadLevel("TerminalGame");
    }

    public override void Update(DungeonMaster dm)
    {

    }
}

public class PauseState : GameState
{
    public override void Enter(DungeonMaster dm)
    {
        dm.GetComponent<PlayerInput>().SwitchCurrentActionMap("Pause");
        Time.timeScale = 0f;
    }

    public override void Exit(DungeonMaster dm)
    {
        Time.timeScale = 1f;
    }

    public override void Update(DungeonMaster dm)
    {

    }
}

public class CutsceneState : GameState
{
    public override void Enter(DungeonMaster dm)
    {

    }

    public override void Exit(DungeonMaster dm)
    {

    }

    public override void Update(DungeonMaster dm)
    {

    }
}

public class MainMenuState : GameState
{
    public override void Enter(DungeonMaster dm)
    {
        dm.GetComponent<PlayerInput>().SwitchCurrentActionMap("UI");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public override void Exit(DungeonMaster dm)
    {

    }

    public override void Update(DungeonMaster dm)
    {

    }
}

public class memRTSState : GameState
{
    public override void Enter(DungeonMaster dm)
    {

    }

    public override void Exit(DungeonMaster dm)
    {

    }

    public override void Update(DungeonMaster dm)
    {

    }
}

public class memShooterState : GameState
{
    public override void Enter(DungeonMaster dm)
    {

    }

    public override void Exit(DungeonMaster dm)
    {

    }

    public override void Update(DungeonMaster dm)
    {

    }
}

public class memRaceState : GameState
{
    public override void Enter(DungeonMaster dm)
    {

    }

    public override void Exit(DungeonMaster dm)
    {

    }

    public override void Update(DungeonMaster dm)
    {

    }
}

public class memHorrorState : GameState
{
    public override void Enter(DungeonMaster dm)
    {

    }

    public override void Exit(DungeonMaster dm)
    {

    }

    public override void Update(DungeonMaster dm)
    {

    }
}

public class memStealthState : GameState
{
    public override void Enter(DungeonMaster dm)
    {

    }

    public override void Exit(DungeonMaster dm)
    {

    }

    public override void Update(DungeonMaster dm)
    {

    }
}

public class memPuzzleState : GameState
{
    public override void Enter(DungeonMaster dm)
    {

    }

    public override void Exit(DungeonMaster dm)
    {

    }

    public override void Update(DungeonMaster dm)
    {

    }
}