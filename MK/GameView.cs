using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace MK;

public class GameView
{
    private int WindowWidth { get; set; }
    private int WindowHeight { get; set; }
    public readonly List<Drawable> ObjectsToDraw = new List<Drawable>();
    private Background background { get; set; }
    private GameModel _model;

    public GameView(GameModel model, int windowWidth, int windowHeight)
    {
        WindowWidth = windowWidth;
        WindowHeight = windowHeight;
        _model = model;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();

        foreach (var obj in ObjectsToDraw)
            obj.Draw(spriteBatch);

        spriteBatch.End();
    }

    public void SetBackground(Background background)
    {
        this.background = background;
        this.background.SetScale(WindowWidth, WindowHeight);
        ObjectsToDraw.Add(this.background);
    }

    public void SetWindowSize(int windowWidth, int windowHeight)
    {
        WindowWidth = windowWidth;
        WindowHeight = windowHeight;
        
        if (background != null)
            background.SetScale(windowWidth, windowHeight);
        
        _model.SetWindowSize(windowWidth, windowHeight);
    }
}