using UnityEngine;
using UnityEngine.InputSystem;

public interface IGameState
{
    public void Enter() { }
    public void Exit() { }
    public void Update() { }
}

public class ShardsState : IGameState, Controls.IShardsActions
{
    private MainGameOrganizer context;
    public ShardsState(MainGameOrganizer ctx) => context = ctx;

    public void Enter()
    {
        // 1. Говорим системе ввода: "Вызывай методы этого класса"
        Inputs.Instance.Controls.Shards.SetCallbacks(this);
        // 2. Включаем карту Shards
        Inputs.Instance.Controls.Shards.Enable();
    }

    public void Exit()
    {
        // Очищаем колбэки при выходе и выключаем карту
        Inputs.Instance.Controls.Shards.SetCallbacks(null);
        Inputs.Instance.Controls.Shards.Disable();
    }

    public void Update()
    {

    }

    public void OnEscape(InputAction.CallbackContext context)
    {
        if (context.canceled)
            DungeonMaster.Instance.TogglePause();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        var movement = (DungeonMaster.Instance.currentSceneContext as MainGameOrganizer)?.movement;
        if (movement == null) return;

        Vector2 input = context.ReadValue<Vector2>();
        Camera cam = DungeonMaster.Instance.currentSceneContext.cam;

        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 worldDir = (forward * input.y + right * input.x);
        movement.SetMoveDirection(worldDir);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        (DungeonMaster.Instance.currentSceneContext as MainGameOrganizer)?.movement.OnJump(context);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Debug.Log("не добавлено");
    }

    public void OnCycleTarget(InputAction.CallbackContext context)
    {
        Debug.Log("не добавлено");
    }

    public void OnSwitchCharacter0(InputAction.CallbackContext context)
    {
        Debug.Log("не добавлено");
    }

    public void OnSwitchCharacter1(InputAction.CallbackContext context)
    {
        Debug.Log("не добавлено");
    }

    public void OnSwitchCharacter2(InputAction.CallbackContext context)
    {
        Debug.Log("не добавлено");
    }

    public void OnSwitchCharacter3(InputAction.CallbackContext context)
    {
        Debug.Log("не добавлено");
    }

    public void OnSwitchCharacter4(InputAction.CallbackContext context)
    {
        Debug.Log("не добавлено");
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        Debug.Log("не добавлено");
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        Debug.Log("не добавлено");
    }

    public void OnAbility(InputAction.CallbackContext context)
    {
        Debug.Log("не добавлено");
    }

    public void OnSwitchWeapon(InputAction.CallbackContext context)
    {
        Debug.Log("не добавлено");
    }

    public void OnResetCameraANDToggleTargetLock(InputAction.CallbackContext context)
    {
        Debug.Log("не добавлено");
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        DungeonMaster.Instance.gatekeeper.LoadLevel("Menu");
    }

    public void OnD_MainMenu(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        if (context.canceled)
            if (DungeonMaster.Instance.currentState is not sub_TerminalState)
                DungeonMaster.Instance.PushState(new sub_TerminalState());
        //Debug.Log(context);
        //DungeonMaster.Instance.gatekeeper.LoadLevel("Menu");
    }
}

public class sub_PauseState : IGameState, Controls.IPauseActions
{

    public void Enter()
    {
        Time.timeScale = 0f;

        // 1. Говорим системе ввода: "Вызывай методы этого класса"
        Inputs.Instance.Controls.Pause.SetCallbacks(this);
        // 2. Включаем карту Pause
        Inputs.Instance.Controls.Pause.Enable();
    }

    public void Exit()
    {
        Time.timeScale = 1f;

        // Очищаем колбэки при выходе и выключаем карту
        Inputs.Instance.Controls.Pause.SetCallbacks(null);
        Inputs.Instance.Controls.Pause.Disable();
    }

    public void Update()
    {

    }

    public void OnD_MainMenu(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        DungeonMaster.Instance.gatekeeper.LoadLevel("Menu");
    }

    public void OnEscape(InputAction.CallbackContext context)
    {
        if (context.canceled)
            DungeonMaster.Instance.TogglePause();
    }
}

public class sub_TerminalState : IGameState, Controls.ITerminalActions
{
    private OrganizerBase _previousContext;

    public void Enter()
    {
        // 1. Говорим системе ввода: "Вызывай методы этого класса"
        Inputs.Instance.Controls.Terminal.SetCallbacks(this);
        // 2. Включаем карту Shards
        Inputs.Instance.Controls.Terminal.Enable();

        _previousContext = DungeonMaster.Instance.currentSceneContext;

        if (DungeonMaster.Instance.currentSceneContext is IPlayerControllable controllable)
        {
            controllable.StopPlayer();
        }

        DungeonMaster.Instance.gatekeeper.LoadLevelAdditive("TerminalGame");
    }

    public void Exit()
    {
        // Очищаем колбэки при выходе и выключаем карту
        Inputs.Instance.Controls.Terminal.SetCallbacks(null);
        Inputs.Instance.Controls.Terminal.Disable();

        DungeonMaster.Instance.currentSceneContext = _previousContext;

        if (DungeonMaster.Instance.currentSceneContext is IPlayerControllable controllable)
        {
            controllable.ResumePlayer();
        }

        DungeonMaster.Instance.gatekeeper.UnloadLevel("TerminalGame");
    }

    public void Update()
    {

    }

    public void OnAbility(InputAction.CallbackContext context)
    {
        Debug.Log("не добавлено");
    }

    public void OnEscape(InputAction.CallbackContext context)
    {
        if (context.canceled)
            DungeonMaster.Instance.PopState();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("не добавлено");
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("не добавлено");
    }

    public void OnOpenDoc(InputAction.CallbackContext context)
    {
        Debug.Log("не добавлено");
    }

    public void OnSuicide(InputAction.CallbackContext context)
    {
        Debug.Log("не добавлено");
    }
}

public class sub_CutsceneState : IGameState, Controls.ICutsceneActions
{
    public void Enter()
    {
        // 1. Говорим системе ввода: "Вызывай методы этого класса"
        Inputs.Instance.Controls.Cutscene.SetCallbacks(this);
        // 2. Включаем карту Pause
        Inputs.Instance.Controls.Cutscene.Enable();
    }

    public void Exit()
    {
        // Очищаем колбэки при выходе и выключаем карту
        Inputs.Instance.Controls.Cutscene.SetCallbacks(null);
        Inputs.Instance.Controls.Cutscene.Disable();
    }

    public void Update()
    {

    }

    public void OnHide(InputAction.CallbackContext context)
    {
        Debug.Log("не добавлено");
    }

    public void OnRead(InputAction.CallbackContext context)
    {
        Debug.Log("не добавлено");
    }

    public void OnSkip(InputAction.CallbackContext context)
    {
        Debug.Log("не добавлено");
    }
}

public class MainMenuState : IGameState, Controls.IUIActions
{
    private MainMenuOrganizer context;
    public MainMenuState(MainMenuOrganizer ctx) => context = ctx;

    public void Enter()
    {
        // 1. Говорим системе ввода: "Вызывай методы этого класса"
        Inputs.Instance.Controls.UI.SetCallbacks(this);
        // 2. Включаем карту Shards
        Inputs.Instance.Controls.UI.Enable();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Exit()
    {
        // Очищаем колбэки при выходе и выключаем карту
        Inputs.Instance.Controls.UI.SetCallbacks(null);
        Inputs.Instance.Controls.UI.Disable();
    }

    public void Update()
    {

    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        DungeonMaster.Instance.gatekeeper.LoadLevel("Game");
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        Debug.Log("не добавлено");
    }

    public void OnMiddleClick(InputAction.CallbackContext context)
    {
        Debug.Log("не добавлено");
    }

    public void OnNavigate(InputAction.CallbackContext context)
    {
        Debug.Log("не добавлено");
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        Debug.Log("не добавлено");
    }

    public void OnRightClick(InputAction.CallbackContext context)
    {
        Debug.Log("не добавлено");
    }

    public void OnScrollWheel(InputAction.CallbackContext context)
    {
        Debug.Log("не добавлено");
    }

    public void OnSubmit(InputAction.CallbackContext context)
    {
        Debug.Log("не добавлено");
    }

    public void OnTrackedDeviceOrientation(InputAction.CallbackContext context)
    {
        Debug.Log("не добавлено");
    }

    public void OnTrackedDevicePosition(InputAction.CallbackContext context)
    {
        Debug.Log("не добавлено");
    }
}

// rts, shooter, race, horror, stealth, puzzle