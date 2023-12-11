using UnityEngine;

public class MoveForwardCommand : MonoBehaviour, ICommand
{
    public GameObject _player;

    public void Execute()
    {
        _player.transform.position += _player.transform.forward;
        this.Done = true;
    }

    public void Undo(){
    
        _player.transform.position -= _player.transform.forward;
    }

    public bool Done { get; private set; }
}