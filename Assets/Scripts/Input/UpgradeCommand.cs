using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCommand : ICommand
{
    private Builder builder;

    public UpgradeCommand(Builder _builder) { builder = _builder; }

    public void Execute()
    {
        // Execute upgrade action
        builder.UpgradeBuilding();
    }
}
