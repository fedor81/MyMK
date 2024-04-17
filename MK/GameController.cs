using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace MK;

public class GameController
{
    private Dictionary<Keys, Directions> _keyToDirection = new Dictionary<Keys, Directions>();
    
    public GameController()
    {
    }

    public ControllerData Update(KeyboardState keyboardState)
    {
        var sendData = new ControllerData();

        if (keyboardState.IsKeyDown(Keys.A))
            sendData.MoveDirection = Directions.Right;
        if (keyboardState.IsKeyDown(Keys.D))
            sendData.MoveDirection = Directions.Left;
        if (keyboardState.IsKeyDown(Keys.W))
            sendData.MoveDirection = Directions.Up;
        if (keyboardState.IsKeyDown(Keys.S))
            sendData.MoveDirection = Directions.Down;
        
        return sendData;
    }
}

public enum Directions
{
    Left,
    Right,
    Down,
    Up
}

public class ControllerData
{
    public Directions MoveDirection { get; set; }

    public ControllerData()
    {
    }
}