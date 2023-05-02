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
        private Vector2 _direction;
        private Animation laser;
        private Animation currentAnimation;
        private Character _player;

        private float _movementSpeed;

        public Limit(string texturePath, Vector2 position, Vector2 scale, float angle)
        {
            _player = LevelController.Player;
            _transform = new Transform(position, scale, angle);

            CreateAnimation1();
            currentAnimation = laser;
            _renderer = new Renderer(currentAnimation, scale);
        }
        public void CheckCollision()
        {
            float distanceX = Math.Abs(_player.Transform.Position.X) - _transform.Position.X;
            float distanceY = Math.Abs(_player.Transform.Position.Y) - _transform.Position.Y;

            float sumHalfWidths = _player.Renderer.Texture.Width / 2 + _renderer.Texture.Width / 2;
            float sumHalfHeight = _player.Renderer.Texture.Height / 2 + _renderer.Texture.Height / 2;

            //if(distanceX <= sumHalfWidths && distanceY <= sumHalfHeight)
            if (Math.Abs(distanceX) <= sumHalfWidths && Math.Abs(distanceY) <= sumHalfHeight)
            {
                _player.LifeController.GetDamage(1);
                //Engine.Debug("Colision");
            }
        }
        public void CreateAnimation1()
        {
            List<Texture> idleTextures1 = new List<Texture>();

            for (int i = 0; i < 4; i++)
            {
                Texture frame = Engine.GetTexture($"Textures/Laser/Horizontal/VallaLaser{i}.png");
                idleTextures1.Add(frame);
            }
            laser = new Animation(true, "laser", 0.15f, idleTextures1);
        }

        public void Initialize() { }

        public void Update()
        {
            CheckCollision();
            currentAnimation.Update();
        }

        public void Render() => _renderer.Render(_transform);
    }
}
