using System.Collections.Generic;

namespace MK;

public class GameModel
{
    private List<Drawable> _objectsToDraw;
    public Player Player;
    private int windowWidth;
    private int wondowHeight;

    public GameModel(List<Drawable> objectsToDraw)
    {
        _objectsToDraw = objectsToDraw;
    }

    private void MovePlayer(Directions direction)
    {
        if (direction == Directions.Right && Player.HeatBox.Right < windowWidth)
        {
            Player.MoveRight();
            if (Player.HeatBox.Right > windowWidth)
                Player.Move();
        }

        if (direction == Directions.Left && Player.HeatBox.Left > 0)
            Player.MoveLeft();
        if (direction == Directions.Up && Player.HeatBox.Top < wondowHeight)
            Player.MoveUp();
        if (direction == Directions.Down && Player.HeatBox.Bottom > 0)
            Player.MoveDown();
    }

    private void GetPlayerWithinScreen(Player player)
    {
    }

    public void Update(ControllerData data)
    {
        MovePlayer(data.MoveDirection);
    }
}