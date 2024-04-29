using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace MK;


public class PlayerImages
{
    private readonly Dictionary<PlayerActionTypes, Texture2D[]> _actionsMap;

    public PlayerImages()
    {
        _actionsMap = new Dictionary<PlayerActionTypes, Texture2D[]>();

        foreach (PlayerActionTypes action in Enum.GetValues(typeof(PlayerActionTypes)))
        {
            _actionsMap[action] = Array.Empty<Texture2D>();
        }
    }

    public void SetTexturesForAction(PlayerActionTypes playerAction, Texture2D[] textures)
    {
        _actionsMap[playerAction] = textures;
    }

    public void SetTexturesForAction(string action, Texture2D[] textures)
    {
        SetTexturesForAction(Enum.Parse<PlayerActionTypes>(action), textures);
    }

    public Texture2D[] GetTexturesForAction(PlayerActionTypes playerAction)
    {
        return _actionsMap[playerAction];
    }
}