using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Character : GameObject, IDamageable
    {
        private Animation _playerIdle;
        private LifeController _lifeController;
        private InputManager _inputManager;
        private SpeedController _speedController;
        private float _movementSpeed;
        public bool isAlive = true;
        public LifeController LifeController => _lifeController;
        public float MovementSpeed { get => _movementSpeed; set => _movementSpeed = value; }
        
        public Character(Vector2 position, Vector2 scale, float angle, float movementSpeed, Vector2 direction, int life) : base(position,scale,angle)
        {
            _transform = new Transform(position, scale, angle);
            _lifeController = new LifeController(life);

            _movementSpeed = movementSpeed;
            _direction = direction;
            _inputManager = new InputManager(this);
            _speedController = new SpeedController(this);
           
        }
        protected override void CreateAnimation()
        {
            List<Texture> idleTextures1 = new List<Texture>();

            for (int i = 0; i < 8; i++)
            {
                Texture frame = Engine.GetTexture($"Textures/Player/{i}NaveTop.png");
                idleTextures1.Add(frame);
            }
            _playerIdle = new Animation(true, "IdleTop", 0.1f, idleTextures1);
            currentAnimation = _playerIdle;
        }
        public void Update()
        {
            _speedController.IncreaseSpeed();
            _inputManager.InputReading();
            currentAnimation.Update();
            if (GameManager.Instance.running == true)
            {
                _transform.Translate(_direction, _movementSpeed);
            }
        }
    }
}