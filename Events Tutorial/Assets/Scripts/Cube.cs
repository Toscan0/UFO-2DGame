using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public delegate void ChangeColor(Color newColor);
    public ChangeColor OnColorChange;

    // Start is called before the first frame update
    void Start()
    {
        OnColorChange = UpdateColor;
        OnColorChange(Color.green);

        //Event
        Main.OnTeleport += ChangePosition;
        Main.OnTeleport += Aux;

        //Action
        Main.OnTeleportByAction += ChangePosition;
    }

    public void ChangePosition(Vector3 newPos)
    {
        transform.position = newPos;
    }

    public void Aux(Vector3 newPos)
    {
        Debug.Log("Just to show that is possible to agreggate funcs");
    }

    public void UpdateColor(Color newColor)
    {
        GetComponent<MeshRenderer>().material.color = newColor;
    }

    //Always disable
    private void OnDisable()
    {
        Main.OnTeleport -= ChangePosition;
        Main.OnTeleport -= Aux;

        Main.OnTeleportByAction -= ChangePosition;
    }
}
