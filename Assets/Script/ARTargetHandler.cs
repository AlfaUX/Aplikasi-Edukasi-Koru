using UnityEngine;

public class ARTargetHandler : MonoBehaviour
{
    public string panelTujuan;
    public string modePanel;

    public ARGlobalManager manager;

    public void OnTargetFound()
    {
        manager.SetTarget(panelTujuan, modePanel);
    }

    public void OnTargetLost()
    {
        manager.ClearTarget();
    }
}