using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    private Stack<ICommand> commandHistory = new Stack<ICommand>();
    private Stack<ICommand> redoHistory = new Stack<ICommand>();

    public MoveForwardCommand[] commandHistory2;
    public MoveForwardCommand[] redoHistory2;
    
    public void Execute(ICommand command)
    {
        redoHistory.Clear();
        command.Execute();
        commandHistory.Push(command);
        reassignFields();
    }

    void reassignFields()
    {
        commandHistory2 = commandHistory.Select(it => it as MoveForwardCommand).ToArray();
        redoHistory2 = redoHistory.Select(it => it as MoveForwardCommand).ToArray();
    }

    public void Undo()
    {
        commandHistory.Peek().Undo();
        redoHistory.Push(commandHistory.Pop());
        reassignFields();
    }

    public void Redo()
    {
        redoHistory.Peek().Execute();
        commandHistory.Push(redoHistory.Pop());
        reassignFields();
    }
}