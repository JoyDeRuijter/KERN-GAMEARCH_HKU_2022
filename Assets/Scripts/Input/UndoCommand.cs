using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoCommand : ICommand
{
    private Builder builder;

    public UndoCommand(Builder _builder) { builder = _builder; }

    public void Execute()
    {
        if (builder.latestBuiltBuilding != null)
        {
            GameObject.Destroy(builder.latestInstantiatedBuilding);
            EventHandler.RaiseEvent(EventType.COINS_CHANGED, Manager.Instance.amountOfCoins += builder.latestPaidPrice);
            Manager.Instance.buildingManager.DeleteBuilding(builder.latestBuiltBuilding);
        }
        else
        { 
            Debug.Log("No action to undo, can only undo once");
        }
    }
}
