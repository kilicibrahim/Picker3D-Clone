using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerMovement : MonoBehaviour
{
    [SerializeField] float forwardSpeed = 1;
    private Vector3 _mouseButtonDownPosition;
    private float xBoarder = 4.3f;



    private Rigidbody _rigidbody;
    public static bool canMove = false;
    void Start()
    {
        GameEvents.current.onBasketExit += OnPassed;
        GameEvents.current.onLvlFinish += OnFinised;
        GameEvents.current.onLvlFinish += OnFailed; //will change after endless platforms implemented
        GameEvents.current.onFailedAttemp += OnFailed;
        GameEvents.current.onLvlStart += OnPassed; // OnPassed method makes canMove true so we can use it on the start too

        _rigidbody = GetComponent<Rigidbody>();
        _mouseButtonDownPosition = new Vector3();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            _rigidbody.MovePosition(transform.position + (Vector3.forward * forwardSpeed * Time.deltaTime)); //constantly moving forward
        }
    }
    void Update()
    {
         xRotation();
    }

    private void xRotation() //doesnt move when we randomly click somewhere in the screen, we need to hold and control to move (just like in the original game)
    {

            if (Input.GetMouseButtonDown(0))
            {
                _mouseButtonDownPosition = Input.mousePosition;
            }
            Vector3 position = transform.position;
            if (Input.GetMouseButton(0))
            {
                Vector3 offset = Input.mousePosition - _mouseButtonDownPosition;
                position = new Vector3(Mathf.Clamp(position.x + offset.x * Time.deltaTime * 2, -xBoarder-2, xBoarder-2), position.y, position.z);
                transform.position = position;
                _mouseButtonDownPosition = Input.mousePosition;
            }
        
        
    }
    private void resetPosition() //reseting position
    {
        Vector3 position = transform.position;
        transform.position = new Vector3(-2, position.y, -20);
    }


    private void OnPassed(int bN)
    {
        canMove = true;      
    }
    private void OnFailed(int bN)
    {
        resetPosition();
        //Invoke("resetPosition", 1f);
        canMove = false;
    }

    private void OnFinised(int lvlN)
    {
        resetPosition(); // will be implemented after lvl manager
    }

    private void OnDestroy()
    {
        GameEvents.current.onBasketExit -= OnPassed;
        GameEvents.current.onLvlFinish -= OnFinised;
        GameEvents.current.onLvlFinish -= OnFailed;
        GameEvents.current.onFailedAttemp -= OnFailed;
        GameEvents.current.onLvlStart -= OnPassed;
    }
}
