using UnityEngine;
using UnityEngine.SceneManagement;

public class KategoriManager : MonoBehaviour
{
    public static string kategoriDipilih;

    public void PilihSempurna()
    {
        kategoriDipilih = "sempurna";

        SceneManager.LoadScene("pilihmeta");
    }

    public void PilihTidakSempurna()
    {
        kategoriDipilih = "tidak";

        SceneManager.LoadScene("pilihmeta");
    }
}