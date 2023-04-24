using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{

    public GameObject blue;
    Vector3 mousePos;
    Camera cameras;
    Vector3 worldPos;

    // Start is called before the first frame update
    void Start()
    {
        cameras = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
            mousePos.z = 1.5f;
            worldPos = cameras.ScreenToWorldPoint(mousePos);
            Instantiate(blue, worldPos, Quaternion.identity);
        }
    }
}
