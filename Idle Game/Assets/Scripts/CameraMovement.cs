using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 5f;
    public float scrollSens = 100;
    private Camera camera;

    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(x, y, 0) * speed * Time.deltaTime);

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        camera.fieldOfView -= scroll * scrollSens * 100f * Time.deltaTime;
    }
}
