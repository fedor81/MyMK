using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MK;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private GameModel _model;
    private GameView _view;
    private GameController _controller;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _model = new GameModel(Window.ClientBounds.Width, Window.ClientBounds.Height);
        _controller = new GameController(_model);
        _view = new GameView(_model.ObjectsToDraw);

        // Установить FPS на 20
        TargetElapsedTime = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / 20);

        Window.AllowUserResizing = true;
        Window.ClientSizeChanged += _controller.UpdateWindowSize;
        // Window.KeyDown += _controller.ProcessPressedKey;

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _model.SetBackground(new Background(Content.Load<Texture2D>("img/background/1")));

        var player = new Player(GetPlayerImages("Content/img/players/jax"), 150, 150);
        _model.players.Add(player);
        _model.ObjectsToDraw.Add(player);
        
        _model.SetWindowSize(Window.ClientBounds.Width, Window.ClientBounds.Height);
    }

    private Dictionary<string, PlayerImages> LoadAllPlayers()
    {
        var dirs = Directory.GetDirectories("Content/img/players");
        var players = new Dictionary<string, PlayerImages>();

        foreach (var playerImagesDir in dirs)
            players[Path.GetDirectoryName(playerImagesDir)!] = GetPlayerImages(playerImagesDir);

        return players;
    }

    private PlayerImages GetPlayerImages(string playerImagesDir)
    {
        var playerImages = new PlayerImages();
        var actionNames = typeof(PlayerActionTypes);

        foreach (var actionName in actionNames.GetEnumNames())
        {
            var actionArr = actionName.Split('_');
            if (actionArr.Length <= 0) continue;

            var pathList = new List<string> { playerImagesDir };
            pathList.AddRange(actionArr);
            var path = Path.Combine(pathList.ToArray());
            playerImages.SetTexturesForAction(actionName, LoadImages(path).ToArray());
        }

        return playerImages;
    }

    private IEnumerable<Texture2D> LoadImages(string pathToFolder)
    {
        const int lengthOfWordContent = 8;

        var pathWithoutContent = pathToFolder[lengthOfWordContent..];
        var files = Directory.GetFiles(pathToFolder);

        return files
            .Select(Path.GetFileNameWithoutExtension)
            .OrderBy(imageName => imageName)
            .Select(imageName => Content.Load<Texture2D>(Path.Combine(pathWithoutContent, imageName)));
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _controller.ProcessPressedKeys(Keyboard.GetState());

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _view.Draw(_spriteBatch);

        base.Draw(gameTime);
    }
}