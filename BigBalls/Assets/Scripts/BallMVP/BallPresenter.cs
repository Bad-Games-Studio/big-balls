using System;
using Zenject;

namespace BallMVP
{
    public class BallPresenter : IDisposable
    {
        private readonly BallView _ballView;
        private readonly BallModel _ballModel;

        [Inject]
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
            _ballModel.ApplyDamage();
        }

        private void OnHealthChanged()
        {
            _ballView.DisplayHealth(_ballModel.Health);
        }
    }
}
