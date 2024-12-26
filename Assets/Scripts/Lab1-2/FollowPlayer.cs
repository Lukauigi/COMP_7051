using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public static readonly Vector3 POSITION_OFFSET = new Vector3(0f, 3f, -10.45f);

    // Ref(s) to other GameObjects
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraOffset = player.transform.position + POSITION_OFFSET;
        transform.position = cameraOffset;
    }
}
