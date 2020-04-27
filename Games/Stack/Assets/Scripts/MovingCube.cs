using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingCube : MonoBehaviour
{
    public static MovingCube CurrentCube { get; private set; }
    public static MovingCube LastCube { get; private set; }
    public MoveDirection MoveDirection { get; set; }

    [SerializeField]
    private float moveSpeed = 1f;

    private Color color;

    public void Stop()
    {
        if (gameObject.name == "StartCube")
        {
            return;
        }

        moveSpeed = 0;

        float hangOver = GetHangOver();

        float max = MoveDirection == MoveDirection.Z ? 
            LastCube.transform.localScale.z : LastCube.transform.localScale.x;

        if (Mathf.Abs(hangOver) >= max)
        {
            LastCube = null;
            CurrentCube = null;
            SceneManager.LoadScene(0);
        }

        float direction = hangOver > 0 ? 1f : -1f;

        if (MoveDirection == MoveDirection.Z)
        {
            SplitCubeOnZ(hangOver, direction);
        }
        else
        {
            SplitCubeOnX(hangOver, direction);
        }

        LastCube = this;
    }

    private float GetHangOver()
    {
        if(MoveDirection == MoveDirection.Z)
        {
            return transform.position.z - LastCube.transform.position.z;
        }
        else
        {
            return transform.position.x - LastCube.transform.position.z;
        }
        
    }

    private void OnEnable()
    {
        if(LastCube == null)
        {
            //LastCube = this;
            LastCube = GameObject.Find("StartCube").GetComponent<MovingCube>();
        }

        CurrentCube = this;

        color = GetRandomColor();
        GetComponent<Renderer>().material.color = color;

        transform.localScale = new Vector3(LastCube.transform.localScale.x, 
            transform.localScale.y,
            LastCube.transform.localScale.z);
    }

    private void Update()
    {
        if(MoveDirection == MoveDirection.Z)
        {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }
        else {
            transform.position += transform.right * Time.deltaTime * moveSpeed;
        }
    }

    private Color GetRandomColor()
    {
        return new Color(UnityEngine.Random.Range(0f, 1f),
            UnityEngine.Random.Range(0f, 1f), 
            UnityEngine.Random.Range(0f, 1f));
    }

    private void SplitCubeOnX(float hangOver, float direction)
    {
        float newXSize = LastCube.transform.localScale.x - Mathf.Abs(hangOver);
        float fallingBlockSize = transform.localScale.x - newXSize;

        float newXPosition = LastCube.transform.position.x + (hangOver / 2f);

        transform.localScale = new Vector3(newXSize,
            transform.localScale.y,
            transform.localScale.z);
        transform.position = new Vector3(newXPosition,
            transform.position.y,
            transform.position.z);

        float cubeEdge = transform.position.x + (newXSize / 2f * direction);
        float fallingBlockXPosition = cubeEdge + fallingBlockSize / 2f * direction;

        SpawnDropCube(fallingBlockXPosition, fallingBlockSize);
    }

    private void SplitCubeOnZ(float hangOver, float direction)
    {
        float newZSize = LastCube.transform.localScale.z - Mathf.Abs(hangOver);
        float fallingBlockSize = transform.localScale.z - newZSize;

        float newZPosition = LastCube.transform.position.z + (hangOver / 2f);

        transform.localScale = new Vector3(transform.localScale.x,
            transform.localScale.y,
            newZSize);
        transform.position = new Vector3(transform.position.x,
            transform.position.y,
            newZPosition);

        float cubeEdge = transform.position.z + (newZSize / 2f * direction);
        float fallingBlockZPosition = cubeEdge + fallingBlockSize / 2f * direction;

        SpawnDropCube(fallingBlockZPosition, fallingBlockSize);
    }

    private void SpawnDropCube(float fallingBlockZPosition, float fallingBlockSize)
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        if(MoveDirection == MoveDirection.Z)
        {
            cube.transform.localScale = new Vector3(transform.localScale.x,
            transform.localScale.y,
            fallingBlockSize);
            cube.transform.position = new Vector3(transform.position.x,
                transform.position.y,
                fallingBlockZPosition);
        }
        else
        {
            cube.transform.localScale = new Vector3(fallingBlockSize,
            transform.localScale.y,
            transform.localScale.z);
            cube.transform.position = new Vector3(fallingBlockZPosition,
                transform.position.y,
                transform.position.z);
        }

        cube.AddComponent<Rigidbody>();
        cube.GetComponent<Renderer>().material.color = color;

        Destroy(cube, 1f);
    }
}
