using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Animation
    {
        private bool isLoop;
        private string name;
        private int currentFrameIndex = 0;
        private float speed = 0.5f;
        private float currentAnimationTime;
        private List<Texture> textures;

        public Texture currentFrame => textures[currentFrameIndex];

        public Animation(bool isLoop, string name, float speed, List<Texture> textures)
        {
            this.isLoop = isLoop;
            this.name = name;
            this.speed = speed;
            this.textures = textures;
        }
        public void Update()
        {
            currentAnimationTime += Time.DeltaTime;

            if (currentAnimationTime >= speed)
            {
                currentFrameIndex++;
                currentAnimationTime = 0;

                if (currentFrameIndex >= textures.Count)
                {
                    if (isLoop)
                    {
                        currentFrameIndex = 0;
                    }
                    else
                    {
                        currentFrameIndex = textures.Count - 1;
                    }
                }
            }
        }
    }
}