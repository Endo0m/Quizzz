using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public static System.Action<CardView> OnCardClicked;
    public static System.Action OnLevelCompleted;
    public static System.Action OnGameCompleted;
    public static System.Action OnGameRestarted;
}