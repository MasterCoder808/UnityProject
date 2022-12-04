using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void ChangeToMustafaLevel()
    {
        SceneManager.LoadScene("MustafaLevel");
    }
    public void ChangeToEnisLevel()
    {
        SceneManager.LoadScene("EnisLevel");
    }
    public void ChangeToBedriyeLevel()
    {
        SceneManager.LoadScene("BedriyeLevel");
    }
}
