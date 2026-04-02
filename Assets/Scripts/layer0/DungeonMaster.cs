using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonMaster : MonoBehaviour
{
    public static DungeonMaster Instance { get; private set; }

    [Header("Текущие ссылки и состояния")]
    public GameState currentState { get; private set; }
    public OrganizerBase currentSceneContext;

    public ShardsState shardsState = new ShardsState();
    public sub_TerminalState terminalState = new sub_TerminalState();
    public sub_PauseState pauseState = new sub_PauseState();
    public sub_CutsceneState cutsceneState = new sub_CutsceneState();
    public MainMenuState mainMenuState = new MainMenuState();

    [Header("DEBUG")]
    public TMP_Text text;

    private Stack<GameState> stateStack = new Stack<GameState>();

    public void SwitchState(GameState newState)
    {
        currentState?.Exit(this);
        stateStack.Clear();
        currentState = newState;
        currentState?.Enter(this);
    }

    public void PushState(GameState newState)
    {
        currentState?.Exit(this);
        stateStack.Push(currentState);
        currentState = newState;
        currentState?.Enter(this);
    }

    public void PopState()
    {
        currentState?.Exit(this);
        currentState = stateStack.Count > 0 ? stateStack.Pop() : shardsState;
        currentState?.Enter(this);
    }

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

    void Start()
    {
        SwitchState(shardsState);
        Application.targetFrameRate = 8000;
    }

    void Update()
    {
        currentState?.Update(this);
        text.text = $"{currentState}";
    }

    public void TogglePause()
    {
        if (currentState is sub_PauseState) 
            PopState();
        else 
            PushState(pauseState);
    }

    public void RegisterScene(OrganizerBase context)
    {
        currentSceneContext = context;

        Debug.Log("Контекст сцены принят");

        switch (context.initialStateName)
        {
            case "MainMenu":
                SwitchState(mainMenuState);
                break;
            case "MainGame":
                SwitchState(shardsState);
                break;
        }
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

    public void LoadLevelAdditive(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
    }

    public void UnloadLevel(string name)
    {
        SceneManager.UnloadSceneAsync(name);
    }
}
