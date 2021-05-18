using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStartGame : MenuHorizontal
{
    public override void Update()
    {
        base.Update();
    }

    public void difficultySelect(int selection)
    {
        GameVariables.difficultySelection = selection;
    }

    public void dinoSelect(int selection)
    {
        GameVariables.dinoSelection = selection;
    }

    public void musicSelect(int selection)
    {
        GameVariables.musicSelection = selection;
    }

    public void stageSelection(int selection)
    {
        GameVariables.stageSelection = selection;
        SceneManager.LoadScene("SpaceLevel");
    }
}
