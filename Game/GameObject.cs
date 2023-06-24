using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class GameObject
    {
        protected Transform _transform;
        protected Renderer _renderer;
        protected Vector2 _direction;
        protected Animation currentAnimation;
        public Transform Transform => _transform;
        public Renderer Renderer => _renderer;
        public Vector2 Direction { get => _direction; set => _direction = value; }

        public GameObject(Vector2 position, Vector2 scale, float angle)
        {
            _transform = new Transform(position, scale, angle);
            CreateAnimation();
            _renderer = new Renderer(currentAnimation, scale);
        }

        public void Render()
        {
            _renderer.Render(_transform);
        }
        protected abstract void CreateAnimation();
    }
}
