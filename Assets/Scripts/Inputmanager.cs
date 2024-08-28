using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputmanager : MonoBehaviour
{
    [SerializeField] public Vector3 mouseWorldPos;


    [SerializeField]public float onFiring;
    
    private static Inputmanager instance;
    public static Inputmanager Instance { get=>instance; }
    private void Awake()
    {
        if (Inputmanager.instance != null) Debug.LogError("chi dc ton tai 1 Inputmanager");
        Inputmanager.instance = this;
    }
    void Update()
    {
        this.getMouseDown();
    }
    void FixedUpdate()
    {

        this.getMousePosition();
    }
    protected virtual void getMousePosition()
    {
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    protected virtual void getMouseDown()
    {
        this.onFiring = Input.GetAxis("Fire1");
    }
}
