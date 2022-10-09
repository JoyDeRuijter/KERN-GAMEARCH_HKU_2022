using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBinder
{
    private KeyCode buildKey, undoKey;
    private InputHandler inputHandler;
    private Builder builder;

    public KeyBinder(BuildingManager _buildingManager, InputHandler _inputHandler, KeyCode _buildKey, KeyCode _undoKey)
    {
        builder = _buildingManager.builder;
        inputHandler = _inputHandler;
        buildKey = _buildKey;
        undoKey = _undoKey;

        BindAllKeys();
    }

    private void BindAllKeys()
    {
        inputHandler.BindInput(buildKey, new BuildCommand(builder));
        inputHandler.BindInput(undoKey, new UndoCommand());
    }
}
