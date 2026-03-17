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
    }

    public override void Exit(DungeonMaster dm)
    {

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
    }

    public override void Exit(DungeonMaster dm)
    {

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