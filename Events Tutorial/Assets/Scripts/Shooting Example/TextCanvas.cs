using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextCanvas : MonoBehaviour
{
    private int countShoot = 0;
    private Text Text;

    // Start is called before the first frame update
    void Start()
    {
        Text = GetComponent<Text>();

        AbstracClass.OnShooting += Aux;
    }

    public void Aux()
    {
        Debug.Log("Some one shooted...");
        countShoot++;
        Text.text = countShoot.ToString();
    }

    //Always disable
    private void OnDisable()
    {
        AbstracClass.OnShooting -= Aux;
    }
}
