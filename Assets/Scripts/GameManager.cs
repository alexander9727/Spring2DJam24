using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    PlayerCharacter player;
    // Start is called before the first frame update
    void Start()
    {
        if(player != null)
        {
            player.SetGameManager(this);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RestartLevel()
    {
        LoadLevel(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
