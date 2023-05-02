using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Renderer
    {
        public Texture Texture => _texture;
        public Vector2 Offset => _offset;

        private Texture _texture;
        private Vector2 _offset;
        private Animation _animation;

        public Renderer(Animation animation, Vector2 scale)
        {
            _animation = animation;
            _texture = animation.currentFrame;

            _offset = new Vector2(
                (scale.X * _texture.Width) / 2,
                (scale.Y * _texture.Height) / 2);
        }

        public void Render(Transform transform)
        {
            _texture = _animation.currentFrame;
            Engine.Draw(
                _texture, 
                transform.Position.X, transform.Position.Y, 
                transform.Scale.X, transform.Scale.Y, 
                transform.Angle, 
                _offset.X, _offset.Y);
        }

        public override string ToString()
        {
            return $"Texture : {_texture}\n" +
                    $"Width : {_texture.Width} / Height : {_texture.Height}\n" +
                    $"Offset - X : {_offset.X} / Y : {_offset.Y}";
        }
    }
}
