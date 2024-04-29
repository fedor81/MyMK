using System.Collections.Generic;
using System.Drawing;
using Microsoft.Xna.Framework.Graphics;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace MK;

public class Player : Drawable
{
    private static int HorizontalSpeed { get; set; }
    private static int VerticalSpeed { get; set; }

    private const int OriginalHorizontalSpeed = 8;
    private const int OriginalVerticalSpeed = 10;

    private static float PlayerImageScale { get; set; }

    protected override float Scale
    {
        get => PlayerImageScale;
    }

    public LookingSide LookingSide { get; set; } = LookingSide.Right;
    private PlayerImages Images;
    private PlayerActionTypes _playerAction;
    private Texture2D[] FramesAction;
    private int FrameNumber;

    protected override Texture2D Image
    {
        get
        {
            // TODO: Пропадают отдельные кадры
            FrameNumber++;
            
            if (FrameNumber >= FramesAction.Length)
            {
                FrameNumber = 0;
            }

            return FramesAction[FrameNumber];
        }
    }

    private const int OriginalHeatBoxWidth = 80;
    private const int OriginalHeatBoxHeight = 136;

    private static int HeatBoxWidth = OriginalHeatBoxWidth;
    private static int HeatBoxHeight = OriginalHeatBoxHeight;
    public Rectangle HeatBox;

    private static readonly List<object> Instances = new();

    public Player(PlayerImages images, int x, int y)
    {
        Instances.Add(this);
        HeatBox = new Rectangle(x, y, HeatBoxWidth, HeatBoxHeight);
        UpdatePosition();

        Images = images;
        Stand();
    }

    public void MoveLeft()
    {
        MoveHorizontal(-HorizontalSpeed, SpriteEffects.FlipHorizontally);
        LookingSide = LookingSide.Left;
    }

    public void MoveRight()
    {
        MoveHorizontal(HorizontalSpeed, SpriteEffects.None);
        LookingSide = LookingSide.Right;
    }

    public void Stand()
    {
        SetAction(PlayerActionTypes.FightingStance);
    }

    private void MoveHorizontal(int x, SpriteEffects effect)
    {
        Move(x);
        Effect = effect;
        SetAction(PlayerActionTypes.Walking);
    }

    public void MoveUp() => Move(y: -VerticalSpeed);
    public void MoveDown() => Move(y: VerticalSpeed);

    public void Move(int x = 0, int y = 0)
    {
        HeatBox.X += x;
        HeatBox.Y += y;
        UpdatePosition();
    }

    private void UpdatePosition() => Position = new Vector2(HeatBox.X, HeatBox.Y);

    private void SetAction(PlayerActionTypes playerAction)
    {
        if (_playerAction == playerAction) return;
        _playerAction = playerAction;
        FramesAction = Images.GetTexturesForAction(playerAction);
        FrameNumber = 0;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        UpdateFrame();
        base.Draw(spriteBatch);
    }

    public static void SetScale(int windowWidth, int windowHeight)
    {
        const float playerHeightRelativeToWindowHeight = 2;
        PlayerImageScale = windowHeight / (playerHeightRelativeToWindowHeight * OriginalHeatBoxHeight);

        HeatBoxHeight = (int)(PlayerImageScale * OriginalHeatBoxHeight);
        HeatBoxWidth = (int)(PlayerImageScale * OriginalHeatBoxWidth);

        HorizontalSpeed = (int)(PlayerImageScale * OriginalHorizontalSpeed);
        VerticalSpeed = (int)(PlayerImageScale * OriginalVerticalSpeed);

        foreach (var instance in Instances)
        {
            var player = instance as Player;
            player!.HeatBox.Height = HeatBoxHeight;
            player.HeatBox.Width = HeatBoxWidth;
        }
    }

    private void IsLastFrame()
    {
    }

    private void UpdateFrame()
    {
    }
}

public enum LookingSide
{
    Left,
    Right
}