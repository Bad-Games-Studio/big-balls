using System;
using UnityEngine;

public class BallPresenter : IDisposable
{
    private readonly BallView _ballView;
    private readonly BallModel _ballModel;

    public BallPresenter(BallView ballView, BallModel ballModel)
    {
        _ballView = ballView;
        _ballModel = ballModel;

        _ballView.OnBoxCollision += OnCollidedWithBox;
        _ballModel.OnHealthChanged += OnHealthChanged;
        
        OnHealthChanged();
    }
    
    public void Dispose()
    {
        _ballView.OnBoxCollision -= OnCollidedWithBox;
        _ballModel.OnHealthChanged -= OnHealthChanged;
    }


    private void OnCollidedWithBox()
    {
        _ballModel.OnHit();
    }

    private void OnHealthChanged()
    {
        _ballView.DisplayHealth(_ballModel.Health);
    }
}
