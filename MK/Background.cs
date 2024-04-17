using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MK;

public class Background : Drawable
{
    private int WindowWidth;
    private List<Vector2> Positions;

    public Background(Texture2D image)
    {
        Image = image;
    }

    public float GetScale(int windowWidth, int windowHeight)
    {
        WindowWidth = windowWidth;
        var scale = (float)windowHeight / Image.Height;

        var backgroundWidth = (int)(Image.Width * scale);
        Positions = new List<Vector2>();

        for (var x = 0; x < WindowWidth; x += backgroundWidth)
        {
            Positions.Add(new Vector2(x, 0));
        }

        return scale;
    }

    public override void Draw(SpriteBatch spriteBatch, float scale)
    {
        Effect = SpriteEffects.None;
        
        foreach(var position in Positions)
        {
            Position = position;
            base.Draw(spriteBatch, scale);
            Effect = Effect == SpriteEffects.None ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
        }
    }
}