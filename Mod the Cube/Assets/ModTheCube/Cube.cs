using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private Material _material;

    void Start()
    {
        transform.position = Vector3.zero;
        transform.localScale = Vector3.one * 2.5f;
        
        _material = Renderer.material;

        var randomColor = Random.ColorHSV();
        _material.color = new Color(randomColor.r, randomColor.g, randomColor.b, 0.25f);
    }
    
    void Update()
    {
        transform.Rotate(0.0f, 20.0f * Time.deltaTime, 0.0f);

        var oldColor = _material.color;
        var alpha = Mathf.PingPong(Time.time * .25f, 1f);
        _material.color = new Color(oldColor.r, oldColor.g, oldColor.b, alpha);
    }
}
