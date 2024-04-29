using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MK;

public class GameController
{
    private GameModel _model;
    private GameView _view;
    private Dictionary<Keys, Directions> _keyToDirection = new Dictionary<Keys, Directions>()
    {
        [Keys.A] = Directions.Left,
        [Keys.D] = Directions.Right,
        [Keys.W] = Directions.Up,
        [Keys.S] = Directions.Down
    };

    public GameController(GameModel model, GameView view)
    {
        _model = model;
        _view = view;
    }

    public void ProcessPressedKeys(KeyboardState keyboard)
    {
        var sendData = new ControllerData();
        
        foreach (var keyValuePair in _keyToDirection)
        {
            if (keyboard.IsKeyDown(keyValuePair.Key))
            {
                sendData.MoveDirections.Add(keyValuePair.Value);
            }
        }

        _model.ProssesControllerData(sendData);
    }

    public void ProcessPressedKey(object sender, InputKeyEventArgs inputKeyEventArgs)
    {
        var sendData = new ControllerData();

        if (_keyToDirection.TryGetValue(inputKeyEventArgs.Key, out var direction))
            sendData.MoveDirections.Add(direction);
        
        _model.ProssesControllerData(sendData);
    }

    public void UpdateWindowSize(object sender, EventArgs eventArgs)
    {
        var window = sender as GameWindow;
        // TODO: Задать минимальный размер окна
        // if (window.ClientBounds.Width < window.ClientBounds.Height)
        
        _view.SetWindowSize(window.ClientBounds.Width, window.ClientBounds.Height);
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
    public List<Directions> MoveDirections { get; set; } = new List<Directions>(4);

    public ControllerData()
    {
    }
}