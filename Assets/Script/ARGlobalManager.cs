using UnityEngine;

public class ARGlobalManager : MonoBehaviour
{
    public static string currentPanel = "";
    public static string currentMode = "";

    public GameObject tombolInfo;

    void Start()
    {
        tombolInfo.SetActive(false);
    }

    public void SetTarget(string panel, string mode)
    {
        currentPanel = panel;
        currentMode = mode;

        tombolInfo.SetActive(true);

        Debug.Log("Target aktif: " + panel);
    }

    public void ClearTarget()
    {
        tombolInfo.SetActive(false);
    }
}