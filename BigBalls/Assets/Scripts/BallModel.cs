using System;
using UnityEngine;

public class BallModel
{
    public int Health { get; private set; }

    public event Action OnHealthChanged;
    
    
    public BallModel(int health)
    {
        Health = health;
    }

    public void OnHit()
    {
        Health--;
        OnHealthChanged?.Invoke();
    }
}
