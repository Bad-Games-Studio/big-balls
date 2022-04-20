using System;
using UnityEngine;
using UnityEngine.UI;

public class BallView : MonoBehaviour
{
    public event Action OnBoxCollision;
    
    [SerializeField]
    private Text _healthText;


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
            _healthText.text = $"Health: {health}";
            return;
        }
        
        _healthText.text = "status: ded";
    }
}
