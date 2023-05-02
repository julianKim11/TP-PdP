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
        private Animation asteroid;
        private Animation currentAnimation;
        private Character _player;
        private CheckCollision _checkCollision;

        private float _movementSpeed;

        public Enemy(string texturePath, Vector2 position, Vector2 scale, float angle, float movementSpeed, Vector2 direction)
        {
            _player = LevelController.Player;
            _transform = new Transform(position, scale, angle);

            _movementSpeed = movementSpeed;
            _direction = direction;

            CreateAnimation1();
            currentAnimation = asteroid;
            _renderer = new Renderer(currentAnimation, scale);
            _checkCollision = new CheckCollision();
        }
        public void CreateAnimation1()
        {
            List<Texture> idleTextures1 = new List<Texture>();

            for (int i = 0; i < 4; i++)
            {
                Texture frame = Engine.GetTexture($"Textures/Asteroid/Asteroid{i}.png");
                idleTextures1.Add(frame);
            }
            asteroid = new Animation(true, "asteroid", 0.15f, idleTextures1);
        }
        public void Update()
        {
            _checkCollision.CheckCollisions(_player, _renderer, _transform);
            currentAnimation.Update();
            _transform.Translate(_direction, _movementSpeed);
        }
        public void Render() => _renderer.Render(_transform);
    }
}