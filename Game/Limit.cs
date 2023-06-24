using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Limit
    {
        private Transform _transform;
        private Renderer _renderer;
        private Animation _laser;
        private Animation _currentAnimation;
        private Character _player;
        private CheckCollision _checkCollision;
        public Limit(Vector2 position, Vector2 scale, float angle)
        {
            _player = LevelController.Player;
            _transform = new Transform(position, scale, angle);

            CreateAnimation();
            _currentAnimation = _laser;
            _renderer = new Renderer(_currentAnimation, scale);
            _checkCollision = new CheckCollision();
        }
        
        public void CreateAnimation()
        {
            List<Texture> idleTextures1 = new List<Texture>();

            for (int i = 0; i < 4; i++)
            {
                Texture frame = Engine.GetTexture($"Textures/Laser/Horizontal/VallaLaser{i}.png");
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
