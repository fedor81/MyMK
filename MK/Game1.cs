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

    private Texture2D background;
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
        // TODO: Add your initialization logic here
        _model = new GameModel();
        _controller = new GameController();

        Window.AllowUserResizing = true;

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here

        _view = new GameView(_spriteBatch, Window)
        {
            Background = Content.Load<Texture2D>("img/background/1")
        };

        LoadSpritesPlayers();
    }

    private PlayerImages[] LoadSpritesPlayers()
    {
        var dirs = Directory.GetDirectories("Content/img/players");
        var players = new PlayerImages[dirs.Length];
        var p = typeof(PlayerImages);

        for (var i = 0; i < dirs.Length; i++)
        {
            var playerImagesDir = dirs[i];
            var player = new PlayerImages();

            foreach (var actionDir in Directory.GetDirectories(playerImagesDir))
            {
                foreach (var actionTypeDir in Directory.GetDirectories(actionDir))
                {
                    var dirName = Path.GetDirectoryName(actionTypeDir);
                    foreach (var actionType in Directory.GetFiles(actionTypeDir))
                    {
                        // player.SetTexturesForAction();
                    }
                }
            }
            // foreach (var fieldInfo in fieldInfos.Where(fieldInfo => fieldInfo.FieldType == typeof(Texture2D[])))
            // {
            //     var path = Path.Combine(playerImagesDir, fieldInfo.Name);
            //     fieldInfo.SetValue(player, GetLoadImages(path).ToArray());
            // }
            //
            // foreach (var fieldInfo in typeof(PlayerTypesOfImages).GetFields())
            // {
            //     var path = Path.Combine(playerImagesDir, fieldInfo.Name);
            //     foreach (var dir in Directory.GetDirectories(path))
            //     {
            //     }
            // }


            players[i] = player;
        }

        return players;
    }


    private IEnumerable<Texture2D> GetLoadImages(string pathToFolder)
    {
        const int lengthOfWordContent = 8;
        var pathWithoutContent = pathToFolder[lengthOfWordContent..];
        return Directory.GetFiles(pathToFolder).Select(Path.GetFileNameWithoutExtension).OrderBy(imageName => imageName)
            .Select(imageName => Content.Load<Texture2D>(Path.Combine(pathWithoutContent, imageName)));
    }

    // public Texture2D LoadImage(string path)
    // {
    //     return Content.Load<Texture2D>(path);
    // }
    //
    // private int GetNumberImage(string pathToFile)
    // {
    //     return int.Parse(Path.GetFileNameWithoutExtension(pathToFile));
    // }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        var controllerData = _controller.Update(Keyboard.GetState());
        _model.Update(controllerData);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        // _view.Draw();
        _spriteBatch.Begin();
        _view.DrawBackground();
        _view.DrawPlayer(_model.Player);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}