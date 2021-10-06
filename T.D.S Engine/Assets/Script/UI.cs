using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public static UI instance { get; private set; } = null;

    [SerializeField] private TextMeshProUGUI minionCount = null;
    [SerializeField] private Image torchImage = null;

    void Start()
    {
        if (instance != null)
        {
            DestroyImmediate(this);
            return;
        }
        instance = this;
    }

    public void SetMinionCout(int count)
    {
        minionCount.text = "Minions : " + count;
    }

    public void ActiveTorch(bool active)
    {
        torchImage.enabled = active;
    }
}
