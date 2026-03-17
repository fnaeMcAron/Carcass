using UnityEngine;

public class Organizer : MonoBehaviour
{
    [Header("Настройки контекста сцены")]
    public GameObject playerRoot;
    public Camera cam;
    public string initialStateName = "";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (DungeonMaster.Instance != null)
        {
            DungeonMaster.Instance.RegisterScene(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
