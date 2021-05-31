using UnityEngine;
using UnityEngine.UI;


namespace Asteroids
{

    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Image _healthBarImage;

        public void SetHealthValue(float healthValue)
        {
            _healthBarImage.fillAmount = healthValue;
        }
    }

}
