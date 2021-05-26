using UnityEngine;
using UnityEngine.UI;


namespace Asteroids
{
    public class BackgroundMover : IUpdateble
    {

        #region Fields
        
        private readonly IScreen _screen;
        private readonly GameObject _background;
        private readonly RectTransform _rectTransform;

        private bool _readyMove = false;
        private float _deltyY;

        #endregion


        #region ClassLifeCycles

        public BackgroundMover(GameObject background, IScreen screen)
        {
            _screen = screen;
            _background = background;
            _rectTransform = background.GetComponent<RectTransform>();
            
        }

        #endregion


        #region Methods

        public void SetBackgroundImage(Sprite sprite, float duration)
        {
            Image image = _background.GetComponent<Image>();
            image.sprite = sprite;
            float proportionsCoefficient = sprite.rect.height / sprite.rect.width;
            float newHeight = proportionsCoefficient * _rectTransform.rect.width;
            _rectTransform.sizeDelta = new Vector2(_rectTransform.sizeDelta.x, newHeight);
            _rectTransform.anchoredPosition = new Vector2(_rectTransform.anchoredPosition.x, newHeight / 2);
            _deltyY = (newHeight - _screen.GetPixelHeight()) / duration;
            _readyMove = true;
        }

        #endregion


        #region IUpdateble

        public void Update(float deltaTime)
        {
            if (_readyMove)
                _rectTransform.anchoredPosition += new Vector2(0, -_deltyY * deltaTime);
        }

        #endregion

    }
}
