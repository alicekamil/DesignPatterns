using System;
using System.Collections;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class KillEnemiesAchievement
{
    private int count = 100;
    private int currentCount;

    public KillEnemiesAchievement()
    {
        Enemy.EnemyDeath += TrackKill;
    }

    public void TrackKill()
    {
        currentCount++;
        if (currentCount == count) Grant();
    }
    
    public void Grant()
    {
        
    }
}

public class Enemy
{
    public static event Action EnemyDeath;
    void OnDeath()
    {
        EnemyDeath?.Invoke();
        // Break until 14:10
    }
}

public interface ICommand
{
    void Execute();
    void Undo();
    bool Done { get; }
}

public interface IEventbus
{
    /// <summary>
    /// This enqueues a new command to the queue.
    /// It is invoked on next Execute invocation when it's at the front of the queue.
    /// optional: The event bus can wait for the ICommand to finish (currentCommand.Done == true)
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    void Enqueue<TCommand>() where TCommand : ICommand;
    /// <summary>
    /// call this e.g. on FixedUpdate
    /// </summary>
    void Execute();
}