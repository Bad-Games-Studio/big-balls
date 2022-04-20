using System;

namespace BallMVP
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class BallModel
    {
        public int Health { get; private set; }

        public event Action OnHealthChanged;
    
    
        public BallModel(int health)
        {
            Health = health;
        }

        public void ApplyDamage()
        {
            Health--;
            OnHealthChanged?.Invoke();
        }
    }
}
