using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace MK;

public class Player : IDraw
{
    public Texture2D Image { get; private set; }
    public int X { get; private set; }
    public int Y { get; private set; }
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
}

public class PlayerImages
{
    public enum ActionType
    {
        Walking,
        Throwing,
        Flip,
        Jumping,
        Running,
        Dizzy,
        Ducking,
        FallingGettingUp,
        FightingStance,
        BeingHitStrongly,
        BeingHitHead,
        BeingHitDown,
        BeingHitBody,
        BeingHitThrowing,
        KickingAir,
        KickingDown,
        KickingForward,
        KickingRight,
        KickingSliding,
        KickingTrip,
        BlockingStand,
        BlockingDown,
        PunchingDown,
        PunchingStand,
        PunchingAir,
        PunchingUp
    }

    private readonly Dictionary<ActionType, Texture2D[]> _actionsMap;

    public PlayerImages()
    {
        _actionsMap = new Dictionary<ActionType, Texture2D[]>();

        foreach (ActionType action in Enum.GetValues(typeof(ActionType)))
        {
            _actionsMap[action] = Array.Empty<Texture2D>();
        }
    }

    public void SetTexturesForAction(ActionType action, Texture2D[] textures)
    {
        _actionsMap[action] = textures;
    }

    public Texture2D[] GetTexturesForAction(ActionType action)
    {
        return _actionsMap[action];
    }
}