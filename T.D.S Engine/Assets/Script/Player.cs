using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Player
{
    public static Player instance = null;

    [Header("Interaction")]
    [SerializeField] private List<GameObject> interactColliders = null;

    [HideInInspector] public bool canMove = true;
    [HideInInspector] public bool canInteract = true;
    [HideInInspector] public bool isMoving = false;
    [HideInInspector] public bool torch = false;

    //Animation
    private string currentAnimation = null;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        animationPlayer = GetComponent<AnimationPlayer>();
    }
}