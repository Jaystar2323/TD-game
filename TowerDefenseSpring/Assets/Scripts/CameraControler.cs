using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour {
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;

    public float minVertical = -90f;
    public float maxVertical = 0f;
    public float minHorizontal = -75;
    public float maxHorizontal = 75;

    public float minRotation = .395f;
    public float maxRotation = .546f;

    private bool doMovement = true;


    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
        }
        if (!doMovement)
        {
            return;
        }
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            if(transform.position.z >= maxVertical)
            { 
                return;
            }
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            if (transform.position.z <= minVertical)
            {
                return;
            }
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            
            if (transform.position.x <= minVertical)
            {
                return;
            }
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            if (transform.position.x >= maxHorizontal)
            {
                return;
            }
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        //Debug.Log(scroll);

        Vector3 pos = transform.position;

        Quaternion rotation = transform.rotation;
        rotation.x -= scroll * 7 * Time.deltaTime;
        Debug.Log(rotation.x);
        rotation.x = Mathf.Clamp(rotation.x, minRotation, maxRotation);
        Debug.Log(rotation.x);
        transform.rotation = rotation;

        pos.y -= scroll * 500 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;

    }
}
