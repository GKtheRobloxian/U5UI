using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    GameManager manage;
    TrailRenderer blue;
    Vector3 mousePos;
    Camera cameras;
    bool swiping = false;

    // Start is called before the first frame update
    void Awake()
    {
        cameras = Camera.main;
        blue = GetComponent<TrailRenderer>();
        blue.enabled = false;

        manage = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manage.isGameActive)
        {
            if (Input.GetMouseButton(0))
            {
                swiping = true;
                UpdateComponents();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                swiping = false;
                UpdateComponents();
            }
            if (swiping)
            {
                UpdateMousePosition();
            }
        }
    }

    void UpdateMousePosition()
    {
        mousePos = cameras.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        transform.position = mousePos;
    }

    void UpdateComponents()
    {
        blue.enabled = swiping;
    }
}
