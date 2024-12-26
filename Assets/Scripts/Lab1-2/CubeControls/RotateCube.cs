using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed;
    [SerializeField]
    private bool lab2 = false;
    private Vector3 _rotationAngle = new Vector3(1, 0, -1);
    private bool _isRotating = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ToggleRotation();
        ChangeColour();
        if (_isRotating == true) transform.Rotate(_rotationSpeed * Time.deltaTime * _rotationAngle);
    }

    private void ToggleRotation()
    {
        if (!lab2 && Input.GetKeyDown(KeyCode.Space))
        {
            _isRotating = !_isRotating;
        }
    }

    private void ChangeColour()
    {
        if (!lab2)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GetComponent<Renderer>().material.color = Color.red;
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                GetComponent<Renderer>().material.color = Color.green;
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                GetComponent<Renderer>().material.color = Color.blue;
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }
}
