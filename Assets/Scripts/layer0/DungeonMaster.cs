using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonMaster : MonoBehaviour
{
    public static DungeonMaster Instance { get; private set; }

    [Header("Текущие ссылки и состояния")]
    public GameState currentState { get; private set; }
    public OrganizerBase currentSceneContext;

    public ShardsState shardsState = new ShardsState();
    public TerminalState terminalState = new TerminalState();
    public PauseState pauseState = new PauseState();
    public CutsceneState cutsceneState = new CutsceneState();
    public MainMenuState mainMenuState = new MainMenuState();

    [Header("DEBUG")]
    public TMP_Text text;

    GameState beforePauseState = new ShardsState();

    public void SwitchState(GameState newState)
    {
        currentState?.Exit(this);
        currentState = newState;
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
        if (currentState is PauseState)
            SwitchState(beforePauseState);
        else
        {
            beforePauseState = currentState;
            SwitchState(pauseState);
        }
    }

    public void RegisterScene(OrganizerBase context)
    {
        currentSceneContext = context;

        //продолжить на остальном контексте по мере расширения
        //rootPlayer = context.playerRoot;

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
}
