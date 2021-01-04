using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //amkes the variable editable from unity
    [SerializeField] float moveSpeed = 10f;

    float xMin, xMax, yMin, yMax;

    float padding = 0.6f;
    float padding2 = 1.0f;
    //Coroutine printCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        setUpMoveBoundaries();
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void setUpMoveBoundaries()
    {
        //setup the boundaries of movement according to the camera
        Camera gameCamera = Camera.main;


        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;

        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding2;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 00)).y - padding2;
    }

    private void Move()
    {
        //var is a generic varaible which chnanges its type according to value
        //deltaX is the difference the Player Ship moves in the  x-axis
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        //newXPosition = current pos in x = difference moved in x-axis
        var newXPos = transform.position.x + deltaX;

        newXPos = Mathf.Clamp(newXPos, xMin, xMax);

        //the same as said above on the y-axis
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newYPos = transform.position.y + deltaY;

        newYPos = Mathf.Clamp(newYPos, yMin, yMax);

        //move the Player Car on the x-axis (newXPos)
        transform.position = new Vector2(newXPos, newYPos);
    }
}