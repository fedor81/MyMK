using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MK;

public class GameView
{
    private SpriteBatch _spriteBatch;
    private GameWindow _window;
    public Texture2D Background { get; set; }

    private float Scale => (float)_window.ClientBounds.Height / Background.Bounds.Height;

    public GameView(SpriteBatch spriteBatch, GameWindow window)
    {
        _spriteBatch = spriteBatch;
        _window = window;
    }

    public void Draw()
    {
        _spriteBatch.Begin();

        DrawBackground();

        _spriteBatch.End();
    }

    public void DrawBackground()
    {
        var scale = Scale;
        var effect = SpriteEffects.None;
        Rectangle? clip = null;
        var backgroundWidth = Background.Width * scale;
        for (float x = 0; x < _window.ClientBounds.Width; x += backgroundWidth)
        {
            // if (x + backgroundWidth > Window.ClientBounds.Width)
            //     clip = new Rectangle(0, 0, (int)((Window.ClientBounds.Width - backgroundWidth) / scale), background.Height);
            _spriteBatch.Draw(Background, new Vector2(x, 0), clip, Color.White, 0f, Vector2.Zero,
                scale, effect, 0);
            effect = effect == SpriteEffects.None ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
        }
    }

    public void DrawPlayer(Player player)
    {
        var scale = Scale;
        _spriteBatch.Draw(player.Image, new Vector2(player.X, player.Y), null, Color.White, 0f, Vector2.Zero, scale,
            SpriteEffects.None, 0);
    }

    public void Update()
    {
    }
}