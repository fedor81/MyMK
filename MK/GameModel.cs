using System.Collections.Generic;

namespace MK;

public class GameModel
{
    public readonly List<Drawable> ObjectsToDraw = new List<Drawable>();
    private Background background { get; set; }
    public List<Player> players = new();
    private int windowWidth;
    private int windowHeight;

    public GameModel(int windowWidth, int windowHeight)
    {
        SetWindowSize(windowWidth, windowHeight);
    }

    public void SetBackground(Background background)
    {
        this.background = background;
        this.background.SetScale(windowWidth, windowHeight);
        ObjectsToDraw.Add(this.background);
    }

    public void SetWindowSize(int width, int height)
    {
        windowWidth = width;
        windowHeight = height;

        if (background != null)
            background.SetScale(width, height);

        Player.SetScale(windowWidth, windowHeight);
        
        foreach (var player in players)
        {
            MovePlayerToScreenArea(player);
        }
    }

    private void MovePlayer(Player player, List<Directions> directions)
    {
        foreach (var direction in directions)
        {
            switch (direction)
            {
                case Directions.Right when player.HeatBox.Right < windowWidth:
                {
                    player.MoveRight();
                    if (player.HeatBox.Right > windowWidth)
                        player.Move(x: windowWidth - player.HeatBox.Right);
                    break;
                }
                case Directions.Left when player.HeatBox.Left > 0:
                {
                    player.MoveLeft();
                    if (player.HeatBox.Left < 0)
                        player.Move(x: -player.HeatBox.Left);
                    break;
                }
                case Directions.Up when player.HeatBox.Top > 0:
                {
                    player.MoveUp();
                    if (player.HeatBox.Top < 0)
                        player.Move(y: -player.HeatBox.Top);
                    break;
                }
                case Directions.Down when player.HeatBox.Bottom < windowHeight:
                {
                    player.MoveDown();
                    if (player.HeatBox.Bottom > windowHeight)
                        player.Move(y: windowHeight - player.HeatBox.Bottom);
                    break;
                }
                default:
                    player.Stand();
                    break;
            }
        }
    }

    private void MovePlayerToScreenArea(Player player)
    {
        if (player.HeatBox.Right > windowWidth)
            player.Move(x: windowWidth - player.HeatBox.Right);
        if (player.HeatBox.Left < 0)
            player.Move(x: -player.HeatBox.Left);
        if (player.HeatBox.Top < 0)
            player.Move(y: -player.HeatBox.Top);
        if (player.HeatBox.Bottom > windowHeight)
            player.Move(y: windowHeight - player.HeatBox.Bottom);
    }

    public void Update(ControllerData data)
    {
        MovePlayer(players[0], data.MoveDirections);
    }
}