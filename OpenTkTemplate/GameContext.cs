using OpenTkTemplate.GLBase;
using System;
using System.Collections.Generic;

namespace OpenTkTemplate
{
    public class GameContext
    {
        internal Random r = new Random();
        internal Camera camera;
        internal GameRenderer renderer = new GameRenderer();
        internal GameLogic logic = new GameLogic();
        internal List<Sprite> sprites = new List<Sprite>();
        internal List<Sprite> player = new List<Sprite>();

        public GameContext()
        {
            logic.gc = this;
            renderer.gc = this;
        }
    }
}
