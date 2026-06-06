using UnityEngine;
using UnityEngine.SceneManagement;

public class DetailButton : MonoBehaviour
{
    [Header("Nama Panel")]
    public string panelTujuan;

    [Header("Mode Panel")]
    public string modePanel;

    public void BukaDeskripsi()
    {
        // Simpan panel tujuan
        MetaManager.namaPanel = panelTujuan;

        // Simpan mode
        MetaManager.modePanel = modePanel;

        // Pindah scene
        SceneManager.LoadScene("Scene Deskripsi");
    }
}