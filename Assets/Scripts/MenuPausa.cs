using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPausa : Menu
{
    public PauseMenu Handler;

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public void ExitGameSession()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        Handler.ResumeGame();
    }
}
