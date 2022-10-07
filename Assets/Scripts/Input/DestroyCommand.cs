using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ObjectChangeEventStream;

public class DestroyCommand : ICommand
{
    private Builder builder;

    public DestroyCommand(Builder _builder) { builder = _builder; }

    public void Execute()
    {
        // Execute destroy action
        builder.DestroyBuilding();
    }
}
