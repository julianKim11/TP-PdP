using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class LimitVertical
    {
        private Transform _transform;
        private Renderer _renderer;
        private Animation _laser;
        private Animation _currentAnimation;
        private Character _player;
        private CheckCollision _checkCollision;
        public LimitVertical(Vector2 position, Vector2 scale, float angle)
        {
            _player = LevelController.Player;
            _transform = new Transform(position, scale, angle);

            CreateAnimation1();
            _currentAnimation = _laser;
            _renderer = new Renderer(_currentAnimation, scale);
            _checkCollision = new CheckCollision();
        }
        public void CreateAnimation1()
        {
            List<Texture> idleTextures1 = new List<Texture>();

            for (int i = 0; i < 4; i++)
            {
                Texture frame = Engine.GetTexture($"Textures/Laser/Vertical/LaserV{i}.png");
                idleTextures1.Add(frame);
            }
            _laser = new Animation(true, "laser", 0.15f, idleTextures1);
        }
        public void Update()
        {
            _checkCollision.CheckCollisions(_player, _renderer, _transform);
            _currentAnimation.Update();
        }
        public void Render() => _renderer.Render(_transform);
    }
}
