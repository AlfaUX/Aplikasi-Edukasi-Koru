using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoButton : MonoBehaviour
{
    public void BukaInformasi()
    {
        if (ARGlobalManager.currentPanel == "")
        {
            Debug.Log("Tidak ada target");

            return;
        }

        // simpan ke manager lama
        ARInfoManager.namaPanel =
            ARGlobalManager.currentPanel;

        MetaManager.modePanel =
            ARGlobalManager.currentMode;

        SceneManager.LoadScene("Scene Deskripsi");
    }
}