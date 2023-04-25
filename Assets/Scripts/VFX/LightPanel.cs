using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPanel : MonoBehaviour
{
    [SerializeField] private float flashSpeed = 3f;
    private Renderer rend;
    private float alpha;

    private void Start() 
    {
        rend = GetComponent<Renderer>();
        alpha = 0f;
    }

    private void Update() 
    {
        if(rend.material.color.a > 0f) {
            rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, alpha);
            alpha -= flashSpeed * Time.deltaTime;
        }

        if(alpha < 0f) {
            alpha = 0f;
            rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, alpha);
        }
    }

    public void Flash()
    {
        alpha = 0.3f;
        rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, alpha);
    }    
}
