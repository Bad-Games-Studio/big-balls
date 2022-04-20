using System;
using CollisionTag;
using UnityEngine;
using UnityEngine.UI;

namespace BallMVP
{
    public class BallView : MonoBehaviour
    {
        public event Action OnBoxCollision;
    
        [SerializeField] private Text healthText;


        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.transform.TryGetComponent<BoxCollisionTag>(out _))
            {
                return;
            }
        
            OnBoxCollision?.Invoke();
        }

        public void DisplayHealth(int health)
        {
            if (health > 0)
            {
                healthText.text = $"Health: {health}";
                return;
            }
        
            healthText.text = "status: ded";
        }
    }
}
