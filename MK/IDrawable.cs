using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MK;

public interface IDrawable
{
    public void Draw(SpriteBatch spriteBatch, float scale);
}