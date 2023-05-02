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

        private float _movementSpeed;

        private Animation playerIdle;
        private Animation currentAnimation;
        private string checkDirection = "UP";

        public Transform Transform { get { return _transform; } }
        public Renderer Renderer { get { return _renderer; } }

        bool active = true;

        public Character(string texturePath, Vector2 position, Vector2 scale, float angle, float movementSpeed, Vector2 direction)
        {
            _transform = new Transform(position, scale, angle);

            _movementSpeed = movementSpeed;
            _direction = direction;

            CreateAnimation1();
            currentAnimation = playerIdle;
            _renderer = new Renderer(currentAnimation, scale);
        }
        private void IncreaseSpeed()
        {
            if (active)
            {
                _movementSpeed += 1;
            }
            if(_movementSpeed >= 1501f)
            {
                active = false;
                _movementSpeed = 0f;
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
            currentAnimation.Update();
            InputReading();
            IncreaseSpeed();
            _transform.Translate(_direction, _movementSpeed);
            Engine.Debug(ToString());
        }

        public void Render() => _renderer.Render(_transform);
        
        public void InputReading()
        {
            if(_movementSpeed > 0)
            {
                if (Engine.GetKey(Keys.W) && checkDirection == "LEFT" || Engine.GetKey(Keys.W) && checkDirection == "RIGHT")
                {
                    checkDirection = "UP";
                    _direction = new Vector2(0, -1);
                    _transform.Rotate(0f);
                }
                if (Engine.GetKey(Keys.S) && checkDirection == "LEFT" || Engine.GetKey(Keys.S) && checkDirection == "RIGHT")
                {
                    checkDirection = "DOWN";
                    _direction = new Vector2(0, 1);
                    _transform.Rotate(180f);
                }
                if (Engine.GetKey(Keys.A) && checkDirection == "UP" || Engine.GetKey(Keys.A) && checkDirection == "DOWN")
                {
                    checkDirection = "LEFT";
                    _direction = new Vector2(-1, 0);
                    _transform.Rotate(-90f);
                }
                if (Engine.GetKey(Keys.D) && checkDirection == "UP" || Engine.GetKey(Keys.D) && checkDirection == "DOWN")
                {
                    checkDirection = "RIGHT";
                    _direction = new Vector2(1, 0);
                    _transform.Rotate(90f);
                }
            }
        }
        public override string ToString() => $"Speed: {_movementSpeed}";
    }
}