using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCommand : ICommand
{
    private Builder builder;

    public BuildCommand(Builder _builder){ builder = _builder;}

    public void Execute()
    {
        // Execute build action
        builder.BuildBuilding();
    }
}
