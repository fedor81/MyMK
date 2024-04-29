using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MK;

public abstract class Drawable
{
    public virtual void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Image, Position, Rect, Color.White, 0f, Vector2.Zero, Scale, Effect, 0);
    }

    protected virtual Texture2D Image { get; set; }
    protected Vector2 Position { get; set; }
    protected SpriteEffects Effect { get; set; } = SpriteEffects.None;
    protected Rectangle? Rect { get; set; }
    protected virtual float Scale { get; set; }
}