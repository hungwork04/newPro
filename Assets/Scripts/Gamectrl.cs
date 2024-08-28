using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamectrl : SaiMonoBehavior
{
    private static Gamectrl instance;
    public static Gamectrl Instance { get { return instance; } }

    [SerializeField] protected Camera mainCamera;
    public Camera MainCamera { get { return mainCamera; } }

    protected override void Awake()
    {
        base.Awake();
        if (Gamectrl.instance != null)
        {
            Debug.Log("Only 1 GameController allow to exit!");
        }
        Gamectrl.instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = Gamectrl.FindAnyObjectByType<Camera>();
        Debug.Log(transform.name + " :LoadCamera", gameObject);
    }
}
