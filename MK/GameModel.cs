using System;
using System.Collections.Generic;

namespace MK;

public class GameModel
{
    public readonly List<Player> Players = new();
    private int windowWidth;
    private int windowHeight;
    private int gravitationalAcceleration { get; set; }

    public GameModel()
    {
    }

    public void SetWindowSize(int width, int height)
    {
        windowWidth = width;
        windowHeight = height;

        gravitationalAcceleration = windowHeight / 10;

        Player.SetPlayerScale(windowWidth, windowHeight);

        foreach (var player in Players)
        {
            player.SetHeatBoxSizes();
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
                    MovePlayerToScreenAreaRight(player);
                    break;
                }
                case Directions.Left when player.HeatBox.Left > 0:
                {
                    player.MoveLeft();
                    MovePlayerToScreenAreaLeft(player);
                    break;
                }
                case Directions.Up when player.HeatBox.Top > 0:
                {
                    player.MoveUp();
                    MovePlayerToScreenAreaTop(player);
                    break;
                }
                case Directions.Down when player.HeatBox.Bottom < windowHeight:
                {
                    player.MoveDown();
                    MovePlayerToScreenAreaBottom(player);
                    break;
                }
            }
        }
    }

    private void MovePlayerToScreenArea(Player player)
    {
        MovePlayerToScreenAreaRight(player);
        MovePlayerToScreenAreaLeft(player);
        MovePlayerToScreenAreaTop(player);
        MovePlayerToScreenAreaBottom(player);
    }

    private void MovePlayerToScreenAreaBottom(Player player)
    {
        if (player.HeatBox.Bottom > windowHeight)
            player.Move(y: windowHeight - player.HeatBox.Bottom);
    }

    private static void MovePlayerToScreenAreaTop(Player player)
    {
        if (player.HeatBox.Top < 0)
            player.Move(y: -player.HeatBox.Top);
    }

    private static void MovePlayerToScreenAreaLeft(Player player)
    {
        if (player.HeatBox.Left < 0)
            player.Move(x: -player.HeatBox.Left);
    }

    private void MovePlayerToScreenAreaRight(Player player)
    {
        if (player.HeatBox.Right > windowWidth)
            player.Move(x: windowWidth - player.HeatBox.Right);
    }

    public void ProssesControllerData(ControllerData data)
    {
        if (data.MoveDirections.Count > 0)
            MovePlayer(Players[0], data.MoveDirections);
        else
            Players[0].Stand();
    }
}