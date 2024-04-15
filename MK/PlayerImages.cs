using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace MK;

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
        
        // BeingHit actions
        BeingHit_Strongly,
        BeingHit_Head,
        BeingHit_Down,
        BeingHit_Body,
        BeingHit_Throwing,
        
        // Kicking actions
        Kicking_Air,
        Kicking_Down,
        Kicking_Forward,
        Kicking_Right,
        Kicking_Sliding,
        Kicking_Trip,

        // Blocking actions
        Blocking_Stand,
        Blocking_Down,

        // Punching actions
        Punching_Down,
        Punching_Stand,
        Punching_Air,
        Punching_Up
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

    public void SetTexturesForAction(string action, Texture2D[] textures)
    {
        SetTexturesForAction(Enum.Parse<ActionType>(action), textures);
    }

    public Texture2D[] GetTexturesForAction(ActionType action)
    {
        return _actionsMap[action];
    }
}