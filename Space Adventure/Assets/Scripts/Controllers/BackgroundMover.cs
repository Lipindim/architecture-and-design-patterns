using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids
{
    public class BackgroundMover : IUpdateble
    {
        private readonly Transform _backTransform;
        private readonly UnityTimer _unityTimer;

        public BackgroundMover(Transform backTransform)
        {
            _backTransform = backTransform;
            _unityTimer = new UnityTimer(0.01f, 1);
        }
        public void Update(float deltaTime)
        {
            _unityTimer.Tick(deltaTime);
            if (_unityTimer.IsTimeUp)
            {
                _backTransform.position += new Vector3(0, -0.01f);
                _unityTimer.Reset();
            }
        }
    }
}
