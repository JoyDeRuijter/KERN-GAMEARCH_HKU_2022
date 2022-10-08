using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBinder
{
    private KeyCode buildKey, upgradeKey, destroyKey, undoKey;
    private InputHandler inputHandler;
    private Builder builder;

    public KeyBinder(BuildingManager _buildingManager, InputHandler _inputHandler, KeyCode _buildKey, KeyCode _upgradeKey, KeyCode _destroyKey, KeyCode _undoKey)
    {
        builder = _buildingManager.builder;
        inputHandler = _inputHandler;
        buildKey = _buildKey;
        upgradeKey = _upgradeKey;
        destroyKey = _destroyKey;
        undoKey = _undoKey;

        BindAllKeys();
    }

    private void BindAllKeys()
    {
        inputHandler.BindInput(buildKey, new BuildCommand(builder));
        inputHandler.BindInput(upgradeKey, new UpgradeCommand(builder));
        inputHandler.BindInput(destroyKey, new DestroyCommand(builder));
        inputHandler.BindInput(undoKey, new UndoCommand());
    }
}
