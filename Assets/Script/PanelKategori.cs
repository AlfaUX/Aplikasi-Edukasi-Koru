using UnityEngine;

public class PanelKategori : MonoBehaviour
{
    public GameObject panelSempurna;
    public GameObject panelTidakSempurna;

    void Awake()
    {
        panelSempurna.SetActive(false);
        panelTidakSempurna.SetActive(false);

        // Dari menu kategori awal
        if (KategoriManager.kategoriDipilih == "sempurna")
        {
            panelSempurna.SetActive(true);
        }
        else if (KategoriManager.kategoriDipilih == "tidak")
        {
            panelTidakSempurna.SetActive(true);
        }

        // Dari tombol back deskripsi
        if (MetaManager.modePanel == "sempurna")
        {
            panelSempurna.SetActive(true);
        }
        else if (MetaManager.modePanel == "tidak")
        {
            panelTidakSempurna.SetActive(true);
        }
    }
}