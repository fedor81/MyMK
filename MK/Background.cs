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

    public void SetScale(int windowWidth, int windowHeight)
    {
        WindowWidth = windowWidth;
        Scale = (float)windowHeight / Image.Height;

        var backgroundWidth = (int)(Image.Width * Scale);
        Positions = new List<Vector2>();

        for (var x = 0; x < WindowWidth; x += backgroundWidth)
        {
            Positions.Add(new Vector2(x, 0));
        }
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        Effect = SpriteEffects.None;
        
        foreach(var position in Positions)
        {
            Position = position;
            base.Draw(spriteBatch);
            Effect = Effect == SpriteEffects.None ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
        }
    }
}