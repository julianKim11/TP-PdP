using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Enemy : GameObject
    {
        private Animation asteroid;
        private Character _player;
        private CheckCollision _checkCollision;

        private float _movementSpeed;

        public Enemy(Vector2 position, Vector2 scale, float angle, float movementSpeed, Vector2 direction) : base(position, scale, angle)
        {
            _player = LevelController.Player;

            _movementSpeed = movementSpeed;
            _direction = direction;

            _checkCollision = new CheckCollision();
            
        }
        protected override void CreateAnimation()
        {
            List<Texture> idleTextures1 = new List<Texture>();

            for (int i = 0; i < 4; i++)
            {
                Texture frame = Engine.GetTexture($"Textures/Asteroid/Asteroid{i}.png");
                idleTextures1.Add(frame);
            }
            asteroid = new Animation(true, "asteroid", 0.15f, idleTextures1);
            currentAnimation = asteroid;
        }
        public void Update()
        {
            _checkCollision.CheckCollisions(_player, _renderer, _transform);
            currentAnimation.Update();
            _transform.Translate(_direction, _movementSpeed);
        }
    }
}