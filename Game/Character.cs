using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Character
    {
        private Transform _transform;
        private Renderer _renderer;
        private Vector2 _direction;
        private Animation _playerIdle;
        private Animation _currentAnimation;
        private LifeController _lifeController;
        private InputManager _inputManager;
        private SpeedController _speedController;

        private float movementSpeed;
        public bool isAlive = true;
        public LifeController LifeController => _lifeController;
        public Transform Transform => _transform;
        public Renderer Renderer => _renderer;
        public Vector2 Direction { get => _direction; set => _direction = value; }
        public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
        
        public Character(string texturePath, Vector2 position, Vector2 scale, float angle, float movementSpeed, Vector2 direction, int life)
        {
            _transform = new Transform(position, scale, angle);
            _lifeController = new LifeController(life);

            CreateAnimation();
            _currentAnimation = _playerIdle;

            movementSpeed = movementSpeed;
            _direction = direction;
            _inputManager = new InputManager(this);
            _speedController = new SpeedController(this);
            _renderer = new Renderer(_currentAnimation, scale);
        }
        public void CreateAnimation()
        {
            List<Texture> idleTextures1 = new List<Texture>();

            for (int i = 0; i < 8; i++)
            {
                Texture frame = Engine.GetTexture($"Textures/Player/{i}NaveTop.png");
                idleTextures1.Add(frame);
            }
            _playerIdle = new Animation(true, "IdleTop", 0.1f, idleTextures1);
        }
        public void Update()
        {
            _speedController.IncreaseSpeed();
            _inputManager.InputReading();
            _currentAnimation.Update();
            if (GameManager.Instance.running == true)
            {
                _transform.Translate(_direction, movementSpeed);
            }
        }
        public void Render() => _renderer.Render(_transform);
    }
}