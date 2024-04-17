using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame;

public class Player
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
}

public class PlayerImages
{
    public enum TypesBeingHit
    {
        Body,
        Down,
        Head,
        Strongly,
        Throwing
    }

    public enum TypesPunching
    {
        Air,
        Down,
        Stand,
        Up
    }

    public enum TypesKicking
    {
        Air,
        Down,
        Forward,
        Right,
        Sliding,
        Trip
    }

    public enum TypesBlocking
    {
        Stand,
        Down
    }
    
    public Texture2D[] Walking;
    public Texture2D[] Throwing;
    public Texture2D[] Flip;
    public Texture2D[] Jumping;
    public Texture2D[] Running;
    public Texture2D[] Dizzy;
    public Texture2D[] Ducking;
    public Texture2D[] FallingGettingUp;
    public Texture2D[] FightingStance;
    public Dictionary<TypesBeingHit, Texture2D[]> BeingHit;
    public Dictionary<TypesPunching, Texture2D[]> Punching;
    public Dictionary<TypesBlocking, Texture2D[]> Blocking;
    public Dictionary<TypesKicking, Texture2D[]> Kicking;
}