using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        Debug.Log(context);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        Debug.Log(context);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void OnCtrl(InputAction.CallbackContext context)
    {
        Debug.Log(context);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log(context);
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
        SceneManager.LoadScene("Test", LoadSceneMode.Single);
    }
}
