using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MK;

public class Background
{
    private Texture2D image;
    private int WindowWidth;

    public Background(Texture2D image)
    {
        this.image = image;
    }

    public float GetScale(int windowWidth, int windowHeight)
    {
        WindowWidth = windowWidth;
        return (float)windowHeight / image.Height;
    }

    public void Draw(SpriteBatch spriteBatch, float scale)
    {
        var effect = SpriteEffects.None;
        Rectangle? clip = null;
        var backgroundWidth = image.Width * scale;

        for (float x = 0; x < WindowWidth; x += backgroundWidth)
        {
            // if (x + backgroundWidth > Window.ClientBounds.Width)
            //     clip = new Rectangle(0, 0, (int)((Window.ClientBounds.Width - backgroundWidth) / scale), background.Height);
            GameView.DrawObject(spriteBatch, image, new Vector2(x, 0), clip, scale, effect);
            effect = effect == SpriteEffects.None ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
        }
    }
}