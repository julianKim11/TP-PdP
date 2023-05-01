using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Renderer
    {
        public Texture Texture => texture;
        public Vector2 Offset => offset;

        private Texture texture;
        private Vector2 offset;

        public Renderer(string texturePath, Vector2 scale)
        {
            this.texture = Engine.GetTexture(texturePath);
            this.offset = new Vector2(scale.X * texture.Width / 2, scale.Y * texture.Height / 2);
        }
        public void Render(Transform transform)
        {
            Engine.Draw(texture, transform.Position.X, transform.Position.Y,
                        transform.Scale.X, transform.Scale.Y, transform.Angle, offset.X, offset.Y);
        }
    }
}
