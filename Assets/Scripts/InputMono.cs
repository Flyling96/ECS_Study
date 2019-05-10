using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMono : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var deltaTime = Time.deltaTime;
        var speed = 5.0f;
        var vector = new Vector3(horizontal, 0, vertical);
        transform.Translate(vector * deltaTime * speed);
    }
}
