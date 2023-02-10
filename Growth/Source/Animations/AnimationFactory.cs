using Growth.Source.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Growth.Source.Animations
{
    public static class AnimationFactory
    {
        public static Animation playerIdle = new Animation(Assets.Texture(@"Textures/DuckRun"), 0, 8, 1, .3f);
        public static Animation playerRun = new Animation(Assets.Texture(@"Textures/DuckRun"), 0, 8, 1, .1f);

        public static Animation spectreIdle = new Animation(Assets.Texture(@"Textures/spectre"), 0, 8, 1, .3f);
        public static Animation spectreRun = new Animation(Assets.Texture(@"Textures/spectre"), 0, 8, 1, .1f);
    }
}
