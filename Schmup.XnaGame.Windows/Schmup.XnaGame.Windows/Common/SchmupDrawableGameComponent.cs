using Microsoft.Xna.Framework;

namespace Schmup.XnaGame.Common
{
    public abstract class SchmupDrawableGameComponent : DrawableGameComponent
    {
        public SchmupGame SchmupGame { get; private set; }

        public SchmupDrawableGameComponent(SchmupGame game)
            : base(game)
        {
            SchmupGame = game;
        }
    }
}
