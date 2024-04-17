using System.Drawing;
using Microsoft.Xna.Framework.Graphics;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace MK;

public class Player : Drawable
{
    private void UpdatePosition()
    {
        Position = new Vector2(HeatBox.X, HeatBox.Y);
    }

    private int HorizontalSpeed { get; set; } = 10;
    private int VerticalSpeed { get; set; } = 10;

    private PlayerImages Images;
    private PlayerImages.ActionType Action;
    private Texture2D[] FramesAction;
    private int FrameNumber;

    private const int HeatBoxWidth = 80;
    private const int HeatBoxHeight = 130;
    public Rectangle HeatBox;

    public Player(PlayerImages images, int x, int y)
    {
        HeatBox = new Rectangle(x, y, HeatBoxWidth, HeatBoxHeight);
        UpdatePosition();

        Images = images;
        SetAction(PlayerImages.ActionType.FightingStance);
    }

    public void MoveLeft() => Move(x: HorizontalSpeed);
    public void MoveRight() => Move(x: HorizontalSpeed);
    public void MoveUp() => Move(y: VerticalSpeed);
    public void MoveDown() => Move(y: VerticalSpeed);

    public void Move(int x = 0, int y = 0)
    {
        HeatBox.X += x;
        HeatBox.Y += y;
        UpdatePosition();
    }

    private void SetAction(PlayerImages.ActionType action)
    {
        Action = action;
        FramesAction = Images.GetTexturesForAction(action);
        FrameNumber = 0;
    }

    public override void Draw(SpriteBatch spriteBatch, float scale)
    {
        Update();
        base.Draw(spriteBatch, scale);
    }

    private void Update()
    {
        Image = FramesAction[FrameNumber];
        FrameNumber = (FrameNumber + 1) % FramesAction.Length;
    }
}