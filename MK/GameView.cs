using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MK;

public class GameView
{
    public readonly List<IDrawable> Objects = new List<IDrawable>();
    private float scale;
    public Background Background { get; set; }

    public GameView()
    {
    }

    public void SetScale(int windowWidth, int windowHeight)
    {
        scale = Background.GetScale(windowWidth, windowHeight);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();

        Background.Draw(spriteBatch, scale);

        foreach (var obj in Objects)
            obj.Draw(spriteBatch, scale);

        spriteBatch.End();
    }

    public static void DrawObject(SpriteBatch spriteBatch, Texture2D image, Vector2 position, Rectangle? rect,
        float scale, SpriteEffects effect)
    {
        spriteBatch.Draw(image, position, rect, Color.White, 0f, Vector2.Zero, scale, effect, 0);
    }
}