using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{

    public float cameraspeed = 80f;
    public float camerascrollspeed = 80f;
    public float cameradragspeed = 100f;
    public float camerazoomspeed = 50f;
    public float camerarotationspeed_x = 100f;
    public float camerarotationspeed_y = 100f;
    public float scrolldistance = 2;
    public float minzoomdist = 5f;
    public float maxzoomdist = 100f;
    public float mousepos_x;
    public float mousepos_y;
    public float camerastartsize = 35;
    public float camerazoom = 35;

    public void Start()
    {
        Camera.main.orthographicSize = camerazoom;
    }

    public void Update()
    {
        //Arrow keyboard scrolling
        float translate_x = Input.GetAxis("Horizontal") * cameraspeed * Time.deltaTime;
        float translate_y = Input.GetAxis("Vertical") * cameraspeed * Time.deltaTime;
        transform.Translate(translate_x, translate_y, 0);

        //Mouse movement scrolling
        mousepos_x = Input.mousePosition.x;
        mousepos_y = Input.mousePosition.y;

        if (mousepos_x > scrolldistance)
            transform.Translate(Vector3.right * scrolldistance * camerascrollspeed * Time.deltaTime);
        if (mousepos_x <= Screen.width - scrolldistance)
            transform.Translate(Vector3.right * -scrolldistance * camerascrollspeed * Time.deltaTime);
        if (mousepos_y < scrolldistance)
            transform.Translate(Vector3.up * -scrolldistance * camerascrollspeed * Time.deltaTime);
        if (mousepos_y >= Screen.height - scrolldistance)
            transform.Translate(Vector3.up * scrolldistance * camerascrollspeed * Time.deltaTime);

        //Mousewheel pressing scrolling
        if (Input.GetMouseButton(2))
            transform.Translate(Input.GetAxis("Mouse X") * cameradragspeed * Time.deltaTime, Input.GetAxis("Mouse Y") * cameradragspeed * Time.deltaTime, 0);
        if (Input.GetMouseButtonDown(0))
            Debug.Log(Input.mousePosition);

        //Mousewheel zooming
        camerazoom -= Input.GetAxisRaw("Mouse ScrollWheel") * camerazoomspeed;
        camerazoom = Mathf.Clamp(camerazoom, minzoomdist, maxzoomdist);
        Camera.main.orthographicSize = camerazoom;


    }

}