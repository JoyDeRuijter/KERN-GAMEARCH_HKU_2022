using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler 
{
    private List<KeyCommand> keyCommands = new List<KeyCommand>();

    // Check for every keycommand if the key is pressed and if so, execute it's corresponding command
    public void HandleInput()
    {
        foreach (KeyCommand kc in keyCommands)
            if (Input.GetKeyDown(kc.key))
                kc.command.Execute();
    }

    // Create a new keycommand by binding a given keycode and command together
    public void BindInput(KeyCode _keyCode, ICommand _command)
    {
        keyCommands.Add(new KeyCommand()
        {
            key = _keyCode,
            command = _command
        });
    }

    // Remove a keycommand from the list of keycommands by the given keycode
    public void UnbindInput(KeyCode _keyCode)
    {
        foreach (KeyCommand kc in keyCommands)
            if (kc.key == _keyCode)
                keyCommands.Remove(kc);
    }
}
