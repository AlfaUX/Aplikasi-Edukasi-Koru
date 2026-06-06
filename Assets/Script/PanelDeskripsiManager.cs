using UnityEngine;

public class PanelDeskripsiManager : MonoBehaviour
{
    public GameObject kupu_d;
    public GameObject katak_d;
    public GameObject nyamuk_d;
    public GameObject belalang_d;
    public GameObject capung_d;
    public GameObject kecoa_d;

    void Awake()
    {
        // Matikan semua
        kupu_d.SetActive(false);
        katak_d.SetActive(false);
        nyamuk_d.SetActive(false);
        belalang_d.SetActive(false);
        capung_d.SetActive(false);
        kecoa_d.SetActive(false);

        // Ambil dari AR atau pilihmeta
        string panel = "";

        if (!string.IsNullOrEmpty(ARInfoManager.namaPanel))
        {
            panel = ARInfoManager.namaPanel;
        }

        if (!string.IsNullOrEmpty(MetaManager.namaPanel))
        {
            panel = MetaManager.namaPanel;
        }

        Debug.Log("Buka panel: " + panel);

        switch (panel)
        {
            case "Kupu_d":
                kupu_d.SetActive(true);
                break;

            case "Katak_d":
                katak_d.SetActive(true);
                break;

            case "Nyamuk_d":
                nyamuk_d.SetActive(true);
                break;

            case "Belalang_d":
                belalang_d.SetActive(true);
                break;

            case "Capung_d":
                capung_d.SetActive(true);
                break;

            case "Kecoa_d":
                kecoa_d.SetActive(true);
                break;
        }
    }
}