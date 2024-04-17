using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MK;

public class GameView
{
    public readonly List<Drawable> Objects = new List<Drawable>();
    private float scale;
    private Background Background { get; set; }

    public GameView()
    {
    }

    public void SetScale(int windowWidth, int windowHeight)
    {
        scale = Background.GetScale(windowWidth, windowHeight);
    }

    public void SetBackbround(Background background, int windowWidth, int windowHeight)
    {
        Background = background;
        SetScale(windowWidth, windowHeight);
        Objects.Add(Background);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();

        foreach (var obj in Objects)
            obj.Draw(spriteBatch, scale);

        spriteBatch.End();
    }
}