using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int hits = 1;
    public int points = 10;
    public Vector3 rotator;
    public Material hitMaterial;


    Material _orgMaterial;
    Renderer _renderer;

       void Start()
    {
        _renderer = GetComponent<Renderer>();
        _orgMaterial = _renderer.sharedMaterial;
 
    }   
 
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        int v = hits--;
        GameManager.Instance.Score += points;
        if (hits <= 0)
        {
            Destroy(gameObject);
        }
        _renderer.sharedMaterial = hitMaterial;
        Invoke("RestoreMaterial" , 0.05f);
    }
    void RestoreMaterial()
    {
        _renderer.sharedMaterial = _orgMaterial;
    }
}
