using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class CheckCollision
    {
        public void CheckCollisions(Character _player, Renderer _renderer, Transform _transform)
        {
            float distanceX = Math.Abs(_player.Transform.Position.X) - _transform.Position.X;
            float distanceY = Math.Abs(_player.Transform.Position.Y) - _transform.Position.Y;

            float sumHalfWidths = _player.Renderer.Texture.Width / 2 + _renderer.Texture.Width / 2;
            float sumHalfHeight = _player.Renderer.Texture.Height / 2 + _renderer.Texture.Height / 2;

            if (Math.Abs(distanceX) <= sumHalfWidths && Math.Abs(distanceY) <= sumHalfHeight)
            {
                _player.LifeController.GetDamage(1);
            }
        }
    }
}
