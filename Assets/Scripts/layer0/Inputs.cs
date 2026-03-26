using UnityEngine;
using UnityEngine.InputSystem;

public class Inputs : MonoBehaviour
{
    public static Inputs Instance { get; private set; }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    //shards
    public void OnEscape(InputAction.CallbackContext context)
    {
        if(context.canceled)
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

    public void OnAttack(InputAction.CallbackContext context)
    {
        Debug.Log(context);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        DungeonMaster.Instance.LoadLevel("Menu");
    }

    public void OnCtrl(InputAction.CallbackContext context)
    {
        Debug.Log(context);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        (DungeonMaster.Instance.currentSceneContext as MainGameOrganizer)?.movement.OnJump(context);
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        Debug.Log(context);
    }

    public void OnAbility(InputAction.CallbackContext context)
    {
        Debug.Log(context);
    }

    public void OnCameraAction(InputAction.CallbackContext context)
    {
        Debug.Log(context);
    }

    public void OnScroll(InputAction.CallbackContext context)
    {
        Debug.Log(context);
    }

    public void OnCancelUI(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        DungeonMaster.Instance.LoadLevel("Test");
    }
}
