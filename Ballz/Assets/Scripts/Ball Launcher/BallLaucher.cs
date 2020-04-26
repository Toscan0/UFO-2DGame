using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LaunchPreview))]
public class BallLaucher : MonoBehaviour
{
    [SerializeField]
    private Ball ballPrefab;

    private Vector3 startDragPosition;
    private Vector3 endDragPosition;
    private List<Ball> balls = new List<Ball>();

    private int ballsReady;

    private LaunchPreview launchPreview;
    private BlockSpawner blockSpawner;

    private void Awake()
    {
        launchPreview = GetComponent<LaunchPreview>();

        blockSpawner = FindObjectOfType<BlockSpawner>();

        CreateBall();
    }

    private void CreateBall()
    {
        var ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        balls.Add(ball);
        ballsReady++;
    }

    private void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.back * -10;

        if (Input.GetMouseButtonDown(0))
        {
            StartDrag(worldPosition);
        }
        else if (Input.GetMouseButton(0))
        {
            ContinueDrag(worldPosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EndDrag();
        }
    }

    private void EndDrag()
    {
        StartCoroutine(LaunchBalls());
    }

    private void ContinueDrag(Vector3 worldPosition)
    {
        endDragPosition = worldPosition;

        Vector3 direction = endDragPosition - startDragPosition;
        launchPreview.SetEndPoint(transform.position - direction);
    }

    private void StartDrag(Vector3 worldPosition)
    {
        startDragPosition = worldPosition;

        launchPreview.SetStartPoint(transform.position);
    }

    private IEnumerator LaunchBalls()
    {
        Vector3 direction = endDragPosition - startDragPosition;
        direction.Normalize();

        foreach (var ball in balls)
        {
            ball.transform.position = transform.position;
            ball.gameObject.SetActive(true);
            ball.GetComponent<Rigidbody2D>().AddForce(-direction);

            yield return new WaitForSeconds(0.1f);
        }

        ballsReady = 0;
    }

    public void ReturnBall()
    {
        ballsReady++;

        if (ballsReady == balls.Count)
        {
            blockSpawner.SpawnRowOfBlocks();

            CreateBall();
        }
    }
}
