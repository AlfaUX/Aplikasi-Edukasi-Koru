using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMeta : MonoBehaviour
{
    public void KembaliKeMeta()
    {
        SceneManager.LoadScene("pilihmeta");
    }
}