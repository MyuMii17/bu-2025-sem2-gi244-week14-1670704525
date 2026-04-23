using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private static MainManager instance;
    public static MainManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }

    public Color TeamColor = Color.white;

    [System.Serializable]
    class SaveData
    {

    }

    public void SaveColor()
    {

    }

    public void LoadColor()
    {

    }
}
