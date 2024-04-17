using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MK;

public abstract class Drawable
{
    public virtual void Draw(SpriteBatch spriteBatch, float scale)
    {
        spriteBatch.Draw(Image, Position, Rect, Color.White, 0f, Vector2.Zero, scale, Effect, 0);
    }

    public Texture2D Image { get; set; }
    public Vector2 Position { get; set; }
    public SpriteEffects Effect { get; set; } = SpriteEffects.None;
    public Rectangle? Rect { get; set; }
}