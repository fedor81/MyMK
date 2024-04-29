namespace MK;


public enum PlayerActionTypes
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