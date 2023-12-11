using UnityEngine;

public class PlayerControllerCmd : MonoBehaviour
{
    private CommandManager _commandManager;

    void Start()
    {
        _commandManager = gameObject.AddComponent<CommandManager>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            var command = new GameObject("Cmd").AddComponent<MoveForwardCommand>();
            command._player = this.gameObject;
            _commandManager.Execute(command);   
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _commandManager.Undo(); 
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            _commandManager.Redo(); 
        }
    }
}