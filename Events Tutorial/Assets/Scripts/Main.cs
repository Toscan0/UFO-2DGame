using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    //Delegate an event
    public delegate void Teleport(Vector3 pos);
    public static event Teleport OnTeleport;

    // Same thing as the two lines above, Action === Event
    public static Action<Vector3> OnTeleportByAction;

    //Delegate a function
    public delegate int CharacterLength(string Text);

    // Same thing as the line above
    public Func<string, int> AnotherCharacterLength;

    private void Start()
    {
        int count = 0;

        CharacterLength cl = GetCharacter;
        count = cl("John");
        Debug.Log("Character count: " + count);

        AnotherCharacterLength = GetCharacter;
        count = AnotherCharacterLength("Mariana");
        Debug.Log("Character count: " + count);

        // Same thing as above
        AnotherCharacterLength = (name) => name.Length;
        count = AnotherCharacterLength("Isabel");
        Debug.Log("Character count: " + count);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(OnTeleport != null)
            {
                OnTeleport(new Vector3(0, 2, 0));
                OnTeleportByAction(new Vector3(0, 2, 0));
            }
        }
    }

    private int GetCharacter(string name)
    {
        return name.Length; 
    }
}
