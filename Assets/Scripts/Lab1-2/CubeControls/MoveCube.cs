using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    private float _moveSpeed = 5f;

    private float _xInput;
    private float _yInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _xInput = Input.GetAxis("Horizontal");
        _yInput = Input.GetAxis("Vertical");

        transform.Translate(_xInput * _moveSpeed * Time.deltaTime * Vector3.right);
        transform.Translate(_yInput * _moveSpeed * Time.deltaTime * Vector3.forward);
    }
}
