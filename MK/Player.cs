using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MK;

public class Player : IDrawable
{
    public Texture2D Image { get; private set; }
    private int X { get; set; }
    private int Y { get; set; }
    private int HorizontalSpeed { get; set; } = 10;
    private int VerticalSpeed { get; set; } = 10;

    public Player(string pathToFolder, int x, int y)
    {
        X = x;
        Y = y;
    }

    private void LoadImages(string pathToFolder)
    {
    }

    public void MoveLeft() => X += HorizontalSpeed;
    public void MoveRight() => X -= HorizontalSpeed;
    public void MoveUp() => Y += VerticalSpeed;
    public void MoveDown() => Y -= VerticalSpeed;

    private void Move(int x, int y)
    {
        X += x;
        Y += y;
    }

    public Texture2D GetImage() => Image;
    public Vector2 GetPosition() => new(X, Y);
    
    public void Draw(SpriteBatch spriteBatch, float scale)
    {
        throw new System.NotImplementedException();
    }
}