using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    #region PRIVATE_VARIABLES


    [SerializeField]
    private int numberOfVertices = 400;
    [SerializeField]
    private float radius = 0.2f;

    private float lineWidthMultiplier = 1f;
    private float lineStartWidth = 0.02f;
    private float lineEndWidth = 0.02f;

    private LineRenderer lineRenderer;
    private Renderer holoRenderer;

    #endregion

    void Awake()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();

        lineRenderer.positionCount = numberOfVertices;
        lineRenderer.useWorldSpace = false;

        lineRenderer.widthMultiplier = lineWidthMultiplier;
        lineRenderer.startWidth = lineStartWidth;
        lineRenderer.endWidth = lineEndWidth;


        holoRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        DrawCircle();
    }

    public void DrawCircle()
    {
        lineRenderer.loop = true;

        

        // One more point so the last one be equal to the first one
        lineRenderer.positionCount = numberOfVertices + 1;

        float x;
        float y;
        float z = 0;

        float angle = 0f;

        for (int i = 0; i < (numberOfVertices + 1); i++)
        {
            //x = (float) (Math.Sin((Math.PI / 180) * angle) * radius);
            //y = (float) (Math.Cos((Math.PI / 180) * angle) * radius);

            x = (float)(radius * (1 - Math.Cos((Math.PI / 180) * angle)));
            y = (float)(radius * (Math.Sin((Math.PI / 180) * angle)));

            lineRenderer.SetPosition(i, new Vector3(x, y, z)); //new Vector3(y, z, x)

            angle += (360f / numberOfVertices);

            //Debug.Log("Pos_" + i + " ( " + x + "; " + y + "; " + z + ")");
        }

        //bigger then the ampoule
        if (radius > 0.155)
        {
            holoRenderer.material.SetFloat("_IsSecondColorOn", 1f);
        }
        else
        {
            holoRenderer.material.SetFloat("_IsSecondColorOn", 0f);
        }
    }
}
