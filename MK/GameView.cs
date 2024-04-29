using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace MK;

public class GameView
{
    public readonly List<Drawable> Objects;

    public GameView(List<Drawable> objects)
    {
        Objects = objects;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();

        foreach (var obj in Objects)
            obj.Draw(spriteBatch);

        spriteBatch.End();
    }
}