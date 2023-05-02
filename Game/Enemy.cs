using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Enemy
    {
        private Transform _transform;
        private Renderer _renderer;
        private Vector2 _direction;
        private Animation playerIdle;
        private Animation currentAnimation;
        private Character _player;

        private float _movementSpeed;

        public Enemy(string texturePath, Vector2 position, Vector2 scale, float angle, float movementSpeed, Vector2 direction)
        {
            _player = Program.Player;
            _transform = new Transform(position, scale, angle);

            _movementSpeed = movementSpeed;
            _direction = direction;

            CreateAnimation1();
            currentAnimation = playerIdle;
            _renderer = new Renderer(currentAnimation, scale);
        }
        public void CheckCollision()
        {
            float distanceX = Math.Abs(_player.Transform.Position.X) - _transform.Position.X;
            float distanceY = Math.Abs(_player.Transform.Position.Y) - _transform.Position.Y;

            float sumHalfWidths = _player.Renderer.Texture.Width / 2 + _renderer.Texture.Width / 2;
            float sumHalfHeight = _player.Renderer.Texture.Height / 2 + _renderer.Texture.Height / 2;

            if(distanceX <= sumHalfWidths && distanceY <= sumHalfHeight)
            {
                Engine.Debug("Colision");
            }
        }
        public void CreateAnimation1()
        {
            List<Texture> idleTextures1 = new List<Texture>();

            for (int i = 0; i < 8; i++)
            {
                Texture frame = Engine.GetTexture($"Textures/Player/{i}NaveTop.png");
                idleTextures1.Add(frame);
            }
            playerIdle = new Animation(true, "IdleTop", 0.1f, idleTextures1);
        }

        public void Initialize() { }

        public void Update()
        {
            CheckCollision();
            currentAnimation.Update();
            _transform.Translate(_direction, _movementSpeed);
            Engine.Debug(ToString());
        }

        public void Render() => _renderer.Render(_transform);

        public override string ToString() => $"Speed: {_movementSpeed}";
    }
}
