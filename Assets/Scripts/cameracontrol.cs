using UnityEngine;
using System.Collections;

public class Cameracontrol : MonoBehaviour
{

    public float cameraspeed = 40f;
    public float camerascrollspeed = 40f;
    public float cameradragspeed = 100f;
    public float camerazoomspeed = 5f;
    public float camerarotationspeed_x = 100f;
    public float camerarotationspeed_y = 100f;
    public float scrolldistance = 5;
    public float cameraborder_east = 497.0f;
    public float cameraborder_west = -2.0f;
    public float cameraborder_north = 499.9f;
    public float cameraborder_south = 0f;
    public float minzoomdist = 5f;
    public float maxzoomdist = 50f;
    public float mousepos_x;
    public float mousepos_y;
    public float camerazoom = 35;
    private float camerastartangle_x = 50f;
    private float camerastartangle_z = -0.5f;
    private float camerastartangle_y = 0.5f;
    public float camerarotationspeed = 45f;
    private Vector3 camerarotationaxis;
    public Vector3 standardpos = new Vector3(230f, 300f, -40f);
    public Vector3 camerastartpos;
    public Vector3 cameraboundaries_max;
    public Vector3 cameraboundaries_min;
    public Quaternion startrotationpos = Quaternion.Euler(50.0f, 0.5f, 0.4f);
    public TerrainData terraindata;
    public bool withinboundaries = true;


    public void Awake()
    {
        //Standard zoom for the camera
        Camera.main.orthographicSize = camerazoom;
        TerrainData terraindata = GetComponent<TerrainData>();
    }

    public void Start()
    {

        //Starting position for the camera
        camerastartpos = transform.position;

        //Starting rotation position for camera 
        startrotationpos = Quaternion.Euler(50.0f, 0.5f, 0.4f);

    }

    public void Update()
    {

        //Ray variables
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        
        /*
        //Arrow keyboard scrolling  
        float translate_x = Input.GetAxisRaw("Left") * cameraspeed * Time.deltaTime;
        float translate_y = Input.GetAxisRaw("Vertical") * cameraspeed * Time.deltaTime;
        transform.Translate(translate_x, translate_y, 0);

        //Mouse movement edge scrolling
        mousepos_x = Input.mousePosition.x;
        mousepos_y = Input.mousePosition.y;

        //if (mousepos_x > scrolldistance)
        //transform.Translate(Vector3.right * scrolldistance * camerascrollspeed * Time.deltaTime);
        if (mousepos_x <= Screen.width - scrolldistance)
            transform.Translate(Vector3.right * -scrolldistance * camerascrollspeed * Time.deltaTime);
        if (mousepos_y < scrolldistance)
            transform.Translate(Vector3.up * -scrolldistance * camerascrollspeed * Time.deltaTime);
        if (mousepos_y >= Screen.height - scrolldistance)
            transform.Translate(Vector3.up * scrolldistance * camerascrollspeed * Time.deltaTime);
    }

    //For north boundaries 
    if (hit.point.z >= cameraboundaries_max.z)
    {
        //Arrow keyboard scrolling  
        float translate_x = Input.GetAxisRaw("Horizontal") * cameraspeed * Time.deltaTime;
        float translate_y = Input.GetAxisRaw("Down") * cameraspeed * Time.deltaTime;
        transform.Translate(translate_x, translate_y, 0);

        //Mouse movement edge scrolling
        mousepos_x = Input.mousePosition.x;
        mousepos_y = Input.mousePosition.y;

        if (mousepos_x > scrolldistance)
            transform.Translate(Vector3.right * scrolldistance * camerascrollspeed * Time.deltaTime);
        if (mousepos_x <= Screen.width - scrolldistance)
            transform.Translate(Vector3.right * -scrolldistance * camerascrollspeed * Time.deltaTime);
        if (mousepos_y < scrolldistance)
            transform.Translate(Vector3.up * -scrolldistance * camerascrollspeed * Time.deltaTime);
        //if (mousepos_y >= Screen.height - scrolldistance)
        //transform.Translate(Vector3.up * scrolldistance * camerascrollspeed * Time.deltaTime);
    }
}
*/
        //All commands are allowed between these boundaries
        if (Physics.Raycast(ray, out hit))
        {
            withinboundaries = true;
            if (withinboundaries == true)
            {
                //Arrow keyboard scrolling
                float translate_x = Input.GetAxisRaw("Horizontal") * cameraspeed * Time.deltaTime;
                float translate_y = Input.GetAxisRaw("Vertical") * cameraspeed * Time.deltaTime;
                transform.Translate(translate_x, translate_y, 0);

                //Mouse movement edge scrolling
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

                //Mousewheel press scrolling
                if (Input.GetMouseButton(2))
                    transform.Translate(Input.GetAxis("Mouse X") * cameradragspeed * Time.deltaTime, Input.GetAxis("Mouse Y") * cameradragspeed * Time.deltaTime, 0);

                //Mousewheel zooming
                camerazoom -= Input.GetAxisRaw("Mouse ScrollWheel");
                camerazoom = Mathf.Clamp(camerazoom, minzoomdist, maxzoomdist);
                Camera.main.orthographicSize = camerazoom;

                //Camera rotation

                //Stores the position of the camera only when the rotational euler angles at the coordinate y (the one that changes when rotation is performed) are the starting ones
                if (startrotationpos.eulerAngles == transform.rotation.eulerAngles)
                    camerastartpos = transform.position;

                //Raycasting to set the point the camera rotates around the place at which the camera es looking (centre)
                if (Input.GetKeyDown("page down") && Physics.Raycast(ray, out hit))
                {
                    Debug.Log(hit.point);
                    camerarotationaxis = new Vector3(0, 0 + camerarotationspeed, 0);
                    transform.RotateAround(hit.point, camerarotationaxis, camerarotationspeed);
                }
                if (Input.GetKeyDown("page up") && Physics.Raycast(ray, out hit))
                {
                    Debug.Log(hit.point);
                    camerarotationaxis = new Vector3(0, 0 - camerarotationspeed, 0);
                    transform.RotateAround(hit.point, camerarotationaxis, camerarotationspeed);
                }
                if (Input.GetKeyDown(KeyCode.Home))
                {
                    transform.position = camerastartpos;
                    transform.rotation = startrotationpos;
                }
                Debug.Log(transform.position);
            }
        }
        else 
        {
            //Map-bound borders for the camera
            withinboundaries = false;

            while (withinboundaries == false)
            {

                //For east boundaries 
                if (transform.position.x <= cameraborder_west)
                {
                    Debug.Log("LELELEL");
                    Debug.Log(transform.position);
                    float translate_x = Input.GetAxisRaw("Right") * cameraspeed * Time.deltaTime;
                    float translate_y = Input.GetAxisRaw("Vertical") * cameraspeed * Time.deltaTime;
                    transform.Translate(translate_x, translate_y, 0);
                }
                
                //For west boundaries
                if (transform.position.x >= cameraborder_east)
                {
                    Debug.Log("LELELEL");
                    Debug.Log(transform.position);

                    /*
                    float translate_x = Input.GetAxisRaw("Left") * cameraspeed * Time.deltaTime;
                    float translate_y = Input.GetAxisRaw("Vertical") * cameraspeed * Time.deltaTime;
                    transform.Translate(translate_x, translate_y, 0);
                    */
                    
                }
                break;
            }

           
        }
}
}



        
