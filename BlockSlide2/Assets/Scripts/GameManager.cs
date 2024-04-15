using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static GameState gameState { get; private set; } = GameState.Playing;

    public static void GameOver() {
        gameState = GameState.GameOver;
    }

    public static void RestartGame() {
        gameState = GameState.Playing;
    }
}


public enum GameState {
    Playing,
    GameOver
}