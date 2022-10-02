using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLevel
{    
    public int levelNumber = 1;
    public List<GameObject> figurs = new List<GameObject>();
    public List<Vector3> figursPos = new List<Vector3>();
    public List<Vector3> figursRotation = new List<Vector3>();
    private const float smallSize = 0.5f;

    private float[] easyPercent = new float[] { 60, 63, 66, 69};
    private float[] mediumPercent = new float[] { 71, 73, 77, 79};
    private float[] hardPercent = new float[] { 82, 84, 86, 88};
    private float[] veryHardPercent = new float[] { 93, 95, 97, 99};

    public void LevelChanger(FieldController field)
    {
        Reset(field);
        ClearHelpFigurs();
        if(levelNumber <= 4)
        {
            field.complicationText.text = $"Level {levelNumber} - EASY";

            float percent = easyPercent[Random.Range(0, 3)];
            field.percentBestPlayers.text = $"Вы лучше {percent}% игроков";

            switch (levelNumber)
            {
                case 1:
                    LevelOneFiveElements(field);
                    break;              
                case 2:
                    LevelThreeFiveElements(field);
                    break;
                case 3:
                    LevelFourFiveElemants(field);
                    break; 
                case 4:
                    LevelTenFiveElements(field);
                    break;
            }
        }
        else if (levelNumber <= 28)
        {
            field.complicationText.text = $"Level {levelNumber} - EASY";

            float percent = easyPercent[Random.Range(0, 3)];
            field.percentBestPlayers.text = $"Вы лучше {percent}% игроков";

            switch (levelNumber)
            {
                case 5:
                    LevelOneFourElemants(field);
                    break;
                case 6:
                    LevelTwoFourElemants(field);
                    break;
                case 7:
                    LevelThreeFourElemants(field);
                    break;
                case 8:
                    LevelFourFourElemants(field);
                    break;
                case 9:
                    LevelFiveFourElemants(field);
                    break;
                case 10:
                    LevelSixFourElemants(field);
                    break;
                case 11:
                    LevelSevenFourElemants(field);
                    break;
                case 12:
                    LevelEightFourElemants(field);
                    break;
                case 13:
                    LevelNineFourElemants(field);
                    break;
                case 14:
                    LevelTenFourElemants(field);
                    break;
                case 15:
                    LevelElevenFourElemants(field);
                    break;
                case 16:
                    LevelTwelveFourElemants(field);
                    break;
                case 17:
                    LevelThirteenFourElemants(field);
                    break;
                case 18:
                    LevelFourteenFourElemants(field);
                    break;
                case 19:
                    LevelFifteenFourElemants(field);
                    break;
                case 20:
                    LevelSixteenFourElemants(field);
                    break;
                case 21:
                    LevelSeventeenFourElemants(field);
                    break;
                case 22:
                    LevelEighteenFourElemants(field);
                    break;
                case 23:
                    LevelNineteenFourElemants(field);
                    break;
                case 24:
                    LevelTwentyFourElemants(field);
                    break;
                case 25:
                    LevelTwentyOneFourElemants(field);
                    break;
                case 26:
                    LevelTwentyTwoFourElemants(field);
                    break;
                case 27:
                    LevelTwentyThreeFourElemants(field);
                    break;
                case 28:
                    LevelTwentyFourFourElemants(field);
                    break;
            }
        }
        else if (levelNumber <= 52)
        {
            field.complicationText.text = $"Level {levelNumber} - MEDIUM";

            float percent = mediumPercent[Random.Range(0, 3)];
            field.percentBestPlayers.text = $"Вы лучше {percent}% игроков";

            switch (levelNumber)
            {
                case 29:
                    LevelOneThreeElements(field);
                    break;
                case 30:
                    LevelTwoThreeElements(field);
                    break;
                case 31:
                    LevelThreeThreeElements(field);
                    break;
                case 32:
                    LevelFourThreeElements(field);
                    break;
                case 33:
                    LevelFiveThreeElements(field);
                    break;
                case 34:
                    LevelSixThreeElements(field);
                    break;
                case 35:
                    LevelSevenThreeElements(field);
                    break;
                case 36:
                    LevelEightThreeElements(field);
                    break;
                case 37:
                    LevelNineThreeElements(field);
                    break;
                case 38:
                    LevelTenThreeElements(field);
                    break;
                case 39:
                    LevelElevenThreeElements(field);
                    break;
                case 40:
                    LevelTwelveThreeElements(field);
                    break;
                case 41:
                    LevelThirteenThreeElements(field);
                    break;
                case 42:
                    LevelFourteenThreeElements(field);
                    break;
                case 43:
                    LevelFifteenThreeElements(field);
                    break;
                case 44:
                    LevelSixteenThreeElements(field);
                    break;
                case 45:
                    LevelSeventeenThreeElements(field);
                    break;
                case 46:
                    LevelEighteenThreeElements(field);
                    break;
                case 47:
                    LevelNineteenThreeElements(field);
                    break;
                case 48:
                    LevelTwentyThreeElements(field);
                    break;
                case 49:
                    LevelTwentyOneThreeElements(field);
                    break;
                case 50:
                    LevelTwentyTwoThreeElements(field);
                    break;
                case 51:
                    LevelTwentyThreeThreeElements(field);
                    break;
                case 52:
                    LevelTwentyFourThreeElements(field);
                    break;
            }
        }
        else if (levelNumber <= 79)
        {
            field.complicationText.text = $"Level {levelNumber} - HARD";

            float percent = hardPercent[Random.Range(0, 3)];
            field.percentBestPlayers.text = $"Вы лучше {percent}% игроков";

            switch (levelNumber)
            {
                case 53:
                    LevelOneTwoElements(field);
                    break;
                case 54:
                    LevelTwoTwoElements(field);
                    break;
                case 55:
                    LevelThreeTwoElements(field);
                    break;
                case 56:
                    LevelFourTwoElements(field);
                    break;
                case 57:
                    LevelFiveTwoElements(field);
                    break;
                case 58:
                    LevelSixTwoElements(field);
                    break;
                case 59:
                    LevelSevenTwoElements(field);
                    break;
                case 60:
                    LevelEightTwoElements(field);
                    break;
                case 61:
                    LevelNineTwoElements(field);
                    break;
                case 62:
                    LevelTenTwoElements(field);
                    break;
                case 63:
                    LevelElevenTwoElements(field);
                    break;
                case 64:
                    LevelTwelveTwoElements(field);
                    break;
                case 65:
                    LevelThirteenTwoElements(field);
                    break;
                case 66:
                    LevelFourteenTwoElements(field);
                    break;
                case 67:
                    LevelFifteenTwoElements(field);
                    break;
                case 68:
                    LevelSixteenTwoElements(field);
                    break;
                case 69:
                    LevelSeventeenTwoElements(field);
                    break;
                case 70:
                    LevelEighteenTwoElements(field);
                    break;
                case 71:
                    LevelNineteenTwoElements(field);
                    break;
                case 72:
                    LevelTwentyTwoElements(field);
                    break;
                case 73:
                    LevelTwentyOneTwoElements(field);
                    break;
                case 74:
                    LevelTwentyTwoTwoElements(field);
                    break;
                case 75:
                    LevelTwentyThreeTwoElements(field);
                    break;
                case 76:
                    LevelTwentyFourTwoElements(field);
                    break;
                case 77:
                    LevelTwentyFiveTwoElements(field);
                    break;
                case 78:
                    LevelTwentySixTwoElements(field);
                    break;
                case 79:
                    LevelTwentySevenTwoElements(field);
                    break;
            }
        }
        else if (levelNumber <= 91)
        {
            field.complicationText.text = $"Level {levelNumber} - VERY HARD";

            float percent = veryHardPercent[Random.Range(0, 3)];
            field.percentBestPlayers.text = $"Вы лучше {percent}% игроков";

            switch (levelNumber)
            {
                case 80:
                    LevelOneOneElement(field);
                    break;
                case 81:
                    LevelTwoOneElement(field);
                    break;
                case 82:
                    LevelThreeOneElement(field);
                    break;
                case 83:
                    LevelFourOneElement(field);
                    break;
                case 84:
                    LevelFiveOneElement(field);
                    break;
                case 85:
                    LevelSixOneElement(field);
                    break;
            }
        }
    }
    // FiveElements FiveElements FiveElements FiveElements FiveElements
    public void LevelOneFiveElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 15, field);
        FillingCell(15, 20, field);
        FillingCell(20, 22, field);
        FillingCell(25, 27, field);
        FillingCell(30, 31, field);

        Small(field.pink.gameObject, 1, 0);
        //move.SetTarget(new Vector3(-4f + number * 2.1f, -5f + yPos, 9));
        var rightPos = new Vector3(-4.470348e-08f, -2.16f, -1);
        var rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);        

        Small(field.green.gameObject, 3, 180);
        rightPos = new Vector3(-0.2685231f, -1.050322f, -1);
        rightRotation = new Vector3(0, 180, 240);
        PutPositionFigure(field.green.gameObject.gameObject, rightRotation, rightPos);

        field.tutorial.gameObject.SetActive(true);
        field.tutorial.StartTutorial();
    }
    /*public void LevelTwoFiveElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 15, field);
        FillingCell(16, 17, field);
        FillingCell(18, 21, field);
        FillingCell(25, 27, field);
        FillingCell(30, 34, field);

        Small(field.pink.gameObject, 1, 0);
        var rightPos = new Vector3(1.139711f, -1.074038f, -1);
        var rightRotation = new Vector3(0, 0, 120);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 2, 0);
        rightPos = new Vector3(-1.212436f, -1.039999f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);        
    }*/
    public void LevelThreeFiveElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 18, field);        
        FillingCell(20, 22, field);
        FillingCell(26, 28, field);
        FillingCell(31, 34, field);

        Small(field.red.gameObject, 1, 0);
        var rightPos = new Vector3(1.279423f, -0.4199999f, -1);
        var rightRotation = new Vector3(0, 0, 300);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 2, 0);
        rightPos = new Vector3(0.2500001f, -1.71f, -1);
        rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        
    }
    public void LevelFourFiveElemants(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 23, field);
        FillingCell(20, 23, field);
        FillingCell(26, 28, field);
        
        Small(field.cyan.gameObject, 2, 0);
        var rightPos = new Vector3(-0.08086568f, -2.851987f, -1);
        var rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.cyan.gameObject.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 3, 180);
        rightPos = new Vector3(0.731477f, -1.050322f, -1);
        rightRotation = new Vector3(180, 0, 60);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);
    }
    /*public void LevelFiveFiveElemants(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 9, field);
        FillingCell(11, 15, field);
        FillingCell(17, 20, field);
        FillingCell(23, 26, field);
        FillingCell(28, 31, field);
        FillingCell(32, 35, field);

        Small(field.red.gameObject, 1, 0);
        var rightPos = new Vector3(-1.720577f, -1.32f, -1);
        var rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 2, 0);
        rightPos = new Vector3(-1.287564f, 0.1700001f, -1);
        rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);
        
    }*/
    /*public void LevelSixFiveElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 21, field);
        FillingCell(24, 27, field);
        FillingCell(30, 31, field);        

        Small(field.pink.gameObject, 1, 0);
        var rightPos = new Vector3(5.960464e-08f, -2.16f, -1);
        var rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 2, 0);
        rightPos = new Vector3(0.2685231f, -1.050322f, -1);
        rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);
    }*/
    /*public void LevelSevenFiveElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 6, field);
        FillingCell(9, 13, field);
        FillingCell(15, 19, field);
        FillingCell(20, 24, field);
        FillingCell(26, 29, field);
        FillingCell(31, 35, field);

        Small(field.red.gameObject, 1, 0);
        var rightPos = new Vector3(2, -0.9f, -1);
        var rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 2, 180);
        rightPos = new Vector3(1.287564f, 1.57f, -1);
        rightRotation = new Vector3(0, 180, 300);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);
    }*/
    /*public void LevelEightFiveElemants(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 13, field);
        FillingCell(14, 18, field);
        FillingCell(20, 24, field);
        FillingCell(26, 29, field);
        FillingCell(31, 32, field);

        Small(field.red.gameObject, 1, 0);
        var rightPos = new Vector3(1.720577f, -0.42f, -1);
        var rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);        

        Small(field.yellow.gameObject, 3, 0);
        rightPos = new Vector3(0.7875645f, -2.44f, -1);
        rightRotation = new Vector3(0, 0, 120);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);
    }*/
    /*public void LevelNineFiveElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 12, field);
        FillingCell(15, 18, field);
        FillingCell(20, 23, field);
        FillingCell(26, 28, field);
        FillingCell(29, 30, field);
        FillingCell(31, 35, field);

        Small(field.red.gameObject, 1, 0);
        var rightPos = new Vector3(1.720577f, 0.4200001f, -1);
        var rightRotation = new Vector3(180, 180, 300);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 2, 180);
        rightPos = new Vector3(0.7314768f, -1.050322f, -1);
        rightRotation = new Vector3(180, 0, 60);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);
    }*/
    public void LevelTenFiveElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 1, field);
        FillingCell(4, 7, field);
        FillingCell(9, 13, field);
        FillingCell(15, 18, field);
        FillingCell(20, 25, field);
        FillingCell(26, 35, field);

        Small(field.blue.gameObject, 1, 0);
        var rightPos = new Vector3(1.000001f, 2.16f, -1);
        var rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 2, 180);
        rightPos = new Vector3(1.360288f, 0.2159624f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);
    }
    // FourElements FourElements FourElements FourElements FourElements
    public void LevelOneFourElemants(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 7, field);
        FillingCell(9, 12, field);
        FillingCell(15, 17, field);
        FillingCell(20, 24, field);
        FillingCell(26, 29, field);
        FillingCell(31, 32, field);

        Small(field.pink.gameObject, 1, 0);
        var rightPos = new Vector3(1.360289f, -0.2159619f, -1);
        var rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 2, 180);
        rightPos = new Vector3(0.7875645f, 1.04f, -1);
        rightRotation = new Vector3(0, 180, 240);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 3, 0);
        rightPos = new Vector3(1.360289f, -1.944038f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);
    }
    public void ResetBlue()
    {
        Small(FieldController.Instance.blue.gameObject, 3, 0);
        var rightPos = new Vector3(1.360289f, -1.944038f, -1);
        var rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(FieldController.Instance.blue.gameObject, rightRotation, rightPos);
    }
    public void LevelTwoFourElemants(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 13, field);
        FillingCell(15, 19, field);
        FillingCell(20, 22, field);
        FillingCell(26, 27, field);

        Small(field.pink.gameObject, 1, 0);
        var rightPos = new Vector3(-4.470348e-08f, -2.16f, -1);
        var rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 2, 0);
        rightPos = new Vector3(2.404423f, -0.640481f, -1);
        rightRotation = new Vector3(0, 0, 300);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 3, 180);
        rightPos = new Vector3(-0.2685231f, -1.050322f, -1);
        rightRotation = new Vector3(0, 180, 240);
        PutPositionFigure(field.green.gameObject.gameObject, rightRotation, rightPos);
    }
    public void LevelThreeFourElemants(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 15, field);
        FillingCell(16, 17, field);
        FillingCell(18, 20, field);
        FillingCell(25, 26, field);
        FillingCell(30, 31, field);

        Small(field.pink.gameObject, 1, 0);
        var rightPos = new Vector3(1.139711f, -1.074038f, -1);
        var rightRotation = new Vector3(0, 0, 120);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 2, 0);
        rightPos = new Vector3(-1.212436f, -1.039999f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 3, 0);
        rightPos = new Vector3(-0.9999996f, -2.159999f, -1);
        rightRotation = new Vector3(0, 0, 0);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);
    }
    public void LevelFourFourElemants(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 6, field);
        FillingCell(7, 8, field);
        FillingCell(9, 12, field);
        FillingCell(15, 18, field);
        FillingCell(20, 22, field);
        FillingCell(26, 28, field);
        FillingCell(31, 34, field);

        Small(field.red.gameObject, 1, 0);
        var rightPos = new Vector3(1.279423f, -0.4199999f, -1);
        var rightRotation = new Vector3(0, 0, 300);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 2, 0);
        rightPos = new Vector3(0.2500001f, -1.71f, -1);
        rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 3, 0);
        rightPos = new Vector3(0.731477f, 1.050322f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);
    }
    public void LevelFiveFourElemants(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 12, field);
        FillingCell(15, 18, field);
        FillingCell(20, 23, field);
        FillingCell(26, 28, field);

        Small(field.red.gameObject, 1, 0);
        var rightPos = new Vector3(2, 0.84f, -1);
        var rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 2, 0);
        rightPos = new Vector3(-0.08086568f, -2.851987f, -1);
        rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.cyan.gameObject.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 3, 180);
        rightPos = new Vector3(0.731477f, -1.050322f, -1);
        rightRotation = new Vector3(180, 0, 60);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);
    }
    public void LevelSixFourElemants(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 9, field);
        FillingCell(11, 15, field);
        FillingCell(17, 20, field);
        FillingCell(23, 26, field);
        FillingCell(29, 30, field);

        Small(field.red.gameObject, 1, 0);
        var rightPos = new Vector3(-1.720577f, -1.32f, -1);
        var rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 2, 0);
        rightPos = new Vector3(-1.287564f, 0.1700001f, -1);
        rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 3, 180);
        rightPos = new Vector3(1.268523f, -2.429678f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);
    }
    public void LevelSevenFourElemants(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 18, field);
        FillingCell(20, 21, field);
        FillingCell(26, 27, field);

        Small(field.red.gameObject, 1, 0);
        var rightPos = new Vector3(1.779423f, -0.4499998f, -1);
        var rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 2, 0);
        rightPos = new Vector3(5.960464e-08f, -2.16f, -1);
        rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 3, 0);
        rightPos = new Vector3(0.2685231f, -1.050322f, -1);
        rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);
    }
    public void LevelEightFourElemants(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 3, field);
        FillingCell(4, 6, field);
        FillingCell(9, 11, field);
        FillingCell(15, 17, field);
        FillingCell(20, 24, field);
        FillingCell(26, 29, field);
        FillingCell(31, 35, field);

        Small(field.red.gameObject, 1, 0);
        var rightPos = new Vector3(2, -0.9f, -1);
        var rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 2, 0);
        rightPos = new Vector3(1.095577f, 0.2374682f, -1);
        rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 3, 180);
        rightPos = new Vector3(0.6830127f, 1.556987f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);
    }
    public void LevelNineFourElemants(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 1, field);
        FillingCell(4, 8, field);
        FillingCell(9, 13, field);
        FillingCell(15, 18, field);
        FillingCell(20, 24, field);
        FillingCell(26, 29, field);
        FillingCell(31, 32, field);

        Small(field.red.gameObject, 1, 0);
        var rightPos = new Vector3(1.720577f, -0.42f, -1);
        var rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 2, 0);
        rightPos = new Vector3(1, 2.16f, -1);
        rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 3, 0);
        rightPos = new Vector3(0.7875645f, -2.44f, -1);
        rightRotation = new Vector3(0, 0, 120);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);
    }
    public void LevelTenFourElemants(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 3, field);
        FillingCell(4, 6, field);
        FillingCell(9, 11, field);
        FillingCell(15, 18, field);
        FillingCell(20, 23, field);
        FillingCell(26, 28, field);
        FillingCell(29, 30, field);
        FillingCell(31, 35, field);

        Small(field.red.gameObject, 1, 0);
        var rightPos = new Vector3(1.720577f, 1.32f, -1);
        var rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 2, 180);
        rightPos = new Vector3(0.8455772f, 0.1995192f, -1);
        rightRotation = new Vector3(0, 180, 240);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 3, 180);
        rightPos = new Vector3(0.7314768f, -1.050322f, -1);
        rightRotation = new Vector3(180, 0, 60);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);
    }
    public void LevelElevenFourElemants(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 1, field);
        FillingCell(4, 7, field);
        FillingCell(9, 13, field);
        FillingCell(15, 18, field);
        FillingCell(20, 23, field);
        FillingCell(26, 29, field);
        FillingCell(31, 34, field);

        Small(field.blue.gameObject, 1, 0);
        var rightPos = new Vector3(1.000001f, 2.16f, -1);
        var rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 2, 180);
        rightPos = new Vector3(1.360288f, 0.2159624f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 3, 180);
        rightPos = new Vector3(1.5f, -1.71f, -1);
        rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);
    }
    public void LevelTwelveFourElemants(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 1, field);
        FillingCell(4, 8, field);
        FillingCell(9, 13, field);
        FillingCell(15, 18, field);
        FillingCell(20, 23, field);
        FillingCell(26, 29, field);
        FillingCell(31, 33, field);

        Small(field.blue.gameObject, 1, 0);
        var rightPos = new Vector3(1f, 2.16f, -1);
        var rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 2, 0);
        rightPos = new Vector3(0.595577f, -1.099519f, -1);
        rightRotation = new Vector3(0, 0, 120);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 3, 180);
        rightPos = new Vector3(2, -0.3399997f, -1);
        rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);
    }
    public void LevelThirteenFourElemants(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 13, field);
        FillingCell(15, 17, field);
        FillingCell(20, 22, field);
        FillingCell(26, 28, field);
        FillingCell(31, 32, field);

        Small(field.red.gameObject, 1, 0);
        var rightPos = new Vector3(-8.583069e-07f, -0.8399997f, -1);
        var rightRotation = new Vector3(0, 0, 0);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 2, 0);
        rightPos = new Vector3(1.919134f, -0.6319871f, -1);
        rightRotation = new Vector3(0, 0, 300);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 3, 180);
        rightPos = new Vector3(1, -2.16f, -1);
        rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);
    }
    public void LevelFourteenFourElemants(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 7, field);
        FillingCell(9, 13, field);
        FillingCell(15, 17, field);
        FillingCell(20, 22, field);
        FillingCell(26, 28, field);
        FillingCell(31, 34, field);

        Small(field.red.gameObject, 1, 0);
        var rightPos = new Vector3(1.779423f, 1.29f, -1);
        var rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 2, 0);
        rightPos = new Vector3(0.2500003f, -1.77f, -1);
        rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 3, 180);
        rightPos = new Vector3(1.212436f, -0.6999998f, -1);
        rightRotation = new Vector3(180, 0, 300);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);
    }
    public void LevelFifteenFourElemants(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 16, field);
        FillingCell(18, 20, field);
        FillingCell(25, 26, field);
        FillingCell(30, 31, field);

        Small(field.red.gameObject, 1, 0);
        var rightPos = new Vector3(-1.720578f, -1.32f, -1);
        var rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 2, 0);
        rightPos = new Vector3(1.139711f, -1.074038f, -1);
        rightRotation = new Vector3(0, 0, 120);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 180);
        rightPos = new Vector3(-0.08086538f, -1.108013f, -1);
        rightRotation = new Vector3(180, 0, 300);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);
    }
    public void LevelSixteenFourElemants(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 14, field);
        FillingCell(15, 18, field);
        FillingCell(20, 22, field);
        FillingCell(26, 27, field);

        Small(field.pink.gameObject, 1, 0);
        var rightPos = new Vector3(1.360288f, -0.2159619f, -1);
        var rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 2, 0);
        rightPos = new Vector3(1.360289f, -1.944038f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 3, 180);
        rightPos = new Vector3(-0.7124355f, -1.57f, -1);
        rightRotation = new Vector3(180, 0, 60);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);
    }
    public void LevelSeventeenFourElemants(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 1, field);
        FillingCell(4, 7, field);
        FillingCell(9, 13, field);
        FillingCell(15, 18, field);
        FillingCell(20, 25, field);
        FillingCell(26, 28, field);
        FillingCell(31, 33, field);

        Small(field.pink.gameObject, 1, 0);
        var rightPos = new Vector3(1.360289f, 0.2040381f, -1);
        var rightRotation = new Vector3(0, 0, 300);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 2, 0);
        rightPos = new Vector3(1, 2.16f, -1);
        rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 3, 180);
        rightPos = new Vector3(0.779422f, -2.19f, -1);
        rightRotation = new Vector3(0, 180, 120);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);
    }
    public void LevelEighteenFourElemants(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 14, field);
        FillingCell(15, 18, field);
        FillingCell(20, 23, field);

        Small(field.pink.gameObject, 1, 0);
        var rightPos = new Vector3(1.360289f, -0.2159619f, -1);
        var rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 2, 0);
        rightPos = new Vector3(1.360289f, -1.944038f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 3, 180);
        rightPos = new Vector3(-0.2500003f, -1.77f, -1);
        rightRotation = new Vector3(180, 0, 0);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);
    }
    public void LevelNineteenFourElemants(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 15, field);
        FillingCell(16, 18, field);
        FillingCell(19, 20, field);
        FillingCell(24, 26, field);

        Small(field.yellow.gameObject, 1, 0);
        var rightPos = new Vector3(-1.212436f, -1.039999f, -1);
        var rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 2, 0);
        rightPos = new Vector3(-1f, -2.159999f, -1);
        rightRotation = new Vector3(0, 0, 0);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 3, 0);
        rightPos = new Vector3(0.7719024f, -0.9882526f, -1);
        rightRotation = new Vector3(0, 0, 0);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);
    }
    public void LevelTwentyFourElemants(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 9, field);
        FillingCell(11, 15, field);
        FillingCell(17, 20, field);
        FillingCell(23, 26, field);
        FillingCell(29, 30, field);

        Small(field.yellow.gameObject, 1, 0);
        var rightPos = new Vector3(-1.287564f, 0.1700001f, -1);
        var rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 2, 0);
        rightPos = new Vector3(-1.720577f, -1.32f, -1);
        rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 3, 180);
        rightPos = new Vector3(1.268523f, -2.429677f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);
    }
    public void LevelTwentyOneFourElemants(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 16, field);
        FillingCell(17, 18, field);
        FillingCell(19, 20, field);
        FillingCell(24, 26, field);

        Small(field.cyan.gameObject, 1, 180);
        var rightPos = new Vector3(-0.08086624f, -1.108013f, -1);
        var rightRotation = new Vector3(180, 0, 300);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 2, 0);
        rightPos = new Vector3(-1.720578f, -1.32f, -1);
        rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 3, 0);
        rightPos = new Vector3(0.7719024f, -0.9882526f, -1);
        rightRotation = new Vector3(0, 0, 0);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);
    }
    public void LevelTwentyTwoFourElemants(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 13, field);
        FillingCell(14, 19, field);
        FillingCell(20, 21, field);
        FillingCell(26, 27, field);

        Small(field.pink.gameObject, 1, 180);
        var rightPos = new Vector3(8.583069e-07f, -2.159999f, -1);
        var rightRotation = new Vector3(180, 0, 0);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 2, 180);
        rightPos = new Vector3(2, -0.3399997f, -1);
        rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 3, 0);
        rightPos = new Vector3(0.2685226f, -1.050322f, -1);
        rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);
    }
    public void LevelTwentyThreeFourElemants(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 16, field);
        FillingCell(18, 22, field);

        Small(field.cyan.gameObject, 1, 0);
        var rightPos = new Vector3(-0.4191349f, -1.498013f, -1);
        var rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 2, 180);
        rightPos = new Vector3(0.2124352f, -0.6999998f, -1);
        rightRotation = new Vector3(180, 0, 300);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 3, 0);
        rightPos = new Vector3(1.360289f, -1.944038f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);
    }
    public void LevelTwentyFourFourElemants(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 13, field);
        FillingCell(15, 16, field);
        FillingCell(20, 22, field);
        FillingCell(26, 28, field);
        FillingCell(31, 33, field);

        Small(field.cyan.gameObject, 1, 180);
        var rightPos = new Vector3(-0.4191343f, -1.501987f, -1);
        var rightRotation = new Vector3(0, 180, 300);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 2, 0);
        rightPos = new Vector3(2, -0.34f, -1);
        rightRotation = new Vector3(0, 0, 0);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 3, 0);
        rightPos = new Vector3(1.139711f, -1.085962f, -1);
        rightRotation = new Vector3(0, 0, 300);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);
    }
    //  ThreeElevements ThreeElevements ThreeElevements ThreeElevements ThreeElevements 
    public void LevelOneThreeElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 5, field);
        FillingCell(6, 9, field);
        FillingCell(12, 15, field);
        FillingCell(18, 20, field);
        FillingCell(24, 26, field);

        Small(field.red.gameObject, 1, 0);
        var rightPos = new Vector3(-0.7205772f, -2.16f, -1);
        var rightRotation = new Vector3(0, 0, 300);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 2, 180);
        rightPos = new Vector3(-2.139711f, 0.665962f, -1);
        rightRotation = new Vector3(0, 180, 120);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 3, 180);
        rightPos = new Vector3(0.6544228f, -1.069519f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(-1.5f, -0.39f, -1);
        rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);
    }
    public void LevelTwoThreeElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 2, field);
        FillingCell(4, 7, field);
        FillingCell(9, 10, field);
        FillingCell(15, 17, field);
        FillingCell(20, 22, field);
        FillingCell(26, 28, field);
        FillingCell(31, 34, field);

        Small(field.yellow.gameObject, 1, 0);
        var rightPos = new Vector3(1.667468f, 1.928013f, -1);
        var rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 2, 0);
        rightPos = new Vector3(0.7314765f, -0.6896777f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 3, 0);
        rightPos = new Vector3(0.2500003f, -1.77f, -1);
        rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(-0.08086495f, 1.111987f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);
    }
    public void LevelThreeThreeElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 6, field);
        FillingCell(7, 8, field);
        FillingCell(9, 12, field);
        FillingCell(20, 21, field);
        FillingCell(26, 27, field);
        FillingCell(31, 34, field);

        Small(field.yellow.gameObject, 1, 180);
        var rightPos = new Vector3(2f, 0.34f, -1);
        var rightRotation = new Vector3(0, 180, 180);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 2, 180);
        rightPos = new Vector3(-0.9595748f, -1.441425f, -1);
        rightRotation = new Vector3(0, 180, 120);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 3, 180);
        rightPos = new Vector3(0.6544228f, -1.069519f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(0.3602886f, -0.215962f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);
    }
    public void LevelFourThreeElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 3, field);
        FillingCell(4, 6, field);
        FillingCell(9, 11, field);
        FillingCell(15, 17, field);
        FillingCell(20, 21, field);
        FillingCell(26, 29, field);
        FillingCell(31, 33, field);

        Small(field.yellow.gameObject, 1, 180);
        var rightPos = new Vector3(1.712435f, -1.91f, -1);
        var rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 2, 180);
        rightPos = new Vector3(0.7314768f, 0.6896778f, -1);
        rightRotation = new Vector3(0, 180, 240);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 3, 180);
        rightPos = new Vector3(0.2499999f, 1.71f, -1);
        rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 0, -1.5f);
        rightPos = new Vector3(-0.08086574f, -1.111987f, -1);
        rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);
    }
    public void LevelFiveThreeElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 8, field);
        FillingCell(9, 10, field);
        FillingCell(11, 13, field);
        FillingCell(15, 16, field);
        FillingCell(20, 22, field);
        FillingCell(26, 27, field);

        Small(field.pink.gameObject, 1, 0);
        var rightPos = new Vector3(2.139711f, -0.654038f, -1);
        var rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 2, 180);
        rightPos = new Vector3(1.268523f, -2.429678f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 3, 180);
        rightPos = new Vector3(-1.139711f, -1.085962f, -1);
        rightRotation = new Vector3(0, 180, 300);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(1.5f, 0.3899999f, -1);
        rightRotation = new Vector3(180, 0, 0);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);
    }
    public void LevelSixThreeElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 13, field);
        FillingCell(15, 16, field);
        FillingCell(17, 18, field);

        Small(field.pink.gameObject, 1, 0);
        var rightPos = new Vector3(-1f, -0.4499998f, -1);
        var rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 2, 0);
        rightPos = new Vector3(-0.4174684f, -1.498974f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 3, 180);
        rightPos = new Vector3(1f, -2.17f, -1);
        rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(1.779422f, 0.4499998f, -1);
        rightRotation = new Vector3(180, 0, 60);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);
    }
    public void LevelSevenThreeElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 6, field);
        FillingCell(8, 12, field);
        FillingCell(14, 17, field);
        FillingCell(20, 21, field);
        FillingCell(26, 27, field);

        Small(field.pink.gameObject, 1, 0);
        var rightPos = new Vector3(-1.110289f, -1.095f, -1);
        var rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 2, 180);
        rightPos = new Vector3(1.720577f, -1.32f, -1);
        rightRotation = new Vector3(180, 0, 60);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 3, 0);
        rightPos = new Vector3(1.212435f, 1.04f, -1);
        rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 0, -1.5f);
        rightPos = new Vector3(0.08086538f, -1.108013f, -1);
        rightRotation = new Vector3(0, 0, 120);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);
    }
    public void LevelEightThreeElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 3, field);
        FillingCell(4, 6, field);
        FillingCell(9, 11, field);
        FillingCell(15, 17, field);
        FillingCell(20, 21, field);
        FillingCell(26, 27, field);
        FillingCell(28, 29, field);
        FillingCell(31, 34, field);

        Small(field.yellow.gameObject, 1, 180);
        var rightPos = new Vector3(1.287564f, 0.1700001f, -1);
        var rightRotation = new Vector3(0, 180, 240);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 2, 180);
        rightPos = new Vector3(1.720577f, -1.32f, -1);
        rightRotation = new Vector3(180, 0, 60);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 3, 180);
        rightPos = new Vector3(0.2500007f, 1.77f, -1);
        rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(-8.583069e-07f, -0.48f, -1);
        rightRotation = new Vector3(0, 180, 180);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);
    }
    public void LevelNineThreeElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 8, field);
        FillingCell(9, 13, field);
        FillingCell(15, 16, field);
        FillingCell(20, 22, field);

        Small(field.yellow.gameObject, 1, 180);
        var rightPos = new Vector3(0.2124355f, -0.7000002f, -1);
        var rightRotation = new Vector3(0, 180, 120);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 2, 180);
        rightPos = new Vector3(1f, -2.16f, -1);
        rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 3, 180);
        rightPos = new Vector3(1.75f, 0.4369873f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 0, -1.5f);
        rightPos = new Vector3(-0.4191343f, -1.498013f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);
    }
    public void LevelTenThreeElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 3, field);
        FillingCell(4, 6, field);
        FillingCell(9, 11, field);
        FillingCell(15, 17, field);
        FillingCell(20, 23, field);
        FillingCell(26, 28, field);
        FillingCell(31, 32, field);

        Small(field.yellow.gameObject, 1, 180);
        var rightPos = new Vector3(1.712435f, -1.91f, -1);
        var rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 2, 180);
        rightPos = new Vector3(0.731477f, 0.6896778f, -1);
        rightRotation = new Vector3(0, 180, 240);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 3, 180);
        rightPos = new Vector3(0.25f, 1.71f, -1);
        rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(0f, -1.26f, -1);
        rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);
    }
    public void LevelElevenThreeElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 1, field);
        FillingCell(4, 6, field);
        FillingCell(9, 12, field);
        FillingCell(15, 16, field);
        FillingCell(20, 22, field);
        FillingCell(26, 29, field);
        FillingCell(31, 34, field);

        Small(field.yellow.gameObject, 1, 0);
        var rightPos = new Vector3(1.712435f, 1.91f, -1);
        var rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 2, 180);
        rightPos = new Vector3(1.860289f, -1.085961f, -1);
        rightRotation = new Vector3(0, 180, 300);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 3, 0);
        rightPos = new Vector3(-0.2499999f, -0.9000001f, -1);
        rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(0.4191344f, 1.501987f, -1);
        rightRotation = new Vector3(180, 0, 300);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);
    }
    public void LevelTwelveThreeElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 3, field);
        FillingCell(4, 5, field);
        FillingCell(9, 11, field);
        FillingCell(15, 17, field);
        FillingCell(20, 23, field);
        FillingCell(26, 28, field);
        FillingCell(31, 33, field);

        Small(field.pink.gameObject, 1, 0);
        var rightPos = new Vector3(1, 0.4200001f, -1);
        var rightRotation = new Vector3(0, 0, 0);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 2, 180);
        rightPos = new Vector3(0.7794225f, -2.19f, -1);
        rightRotation = new Vector3(0, 180, 120);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 0);
        rightPos = new Vector3(0.419134f, 1.498013f, -1);
        rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 3, 0, -1.5f);
        rightPos = new Vector3(0.7314765f, -0.6896777f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);
    }
    public void LevelThirteenThreeElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 4, field);
        FillingCell(4, 7, field);
        FillingCell(9, 12, field);
        FillingCell(15, 17, field);
        FillingCell(20, 22, field);
        FillingCell(26, 27, field);
        //FillingCell(31, 33, field);

        Small(field.pink.gameObject, 1, 0);
        var rightPos = new Vector3(0.6397111f, 0.2159624f, -1);
        var rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 2, 0);
        rightPos = new Vector3(2, 0.3400002f, -1);
        rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 3, 180);
        rightPos = new Vector3(-0.7500005f, -1.71f, -1);
        rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 3, 0, -1.5f);
        rightPos = new Vector3(1.360289f, -1.944038f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);
    }
    public void LevelFourteenThreeElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 2, field);
        FillingCell(4, 7, field);
        FillingCell(9, 13, field);
        FillingCell(15, 19, field);
        FillingCell(20, 22, field);

        Small(field.pink.gameObject, 1, 0);
        var rightPos = new Vector3(2.139711f, -0.654038f, -1);
        var rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 2, 180);
        rightPos = new Vector3(1.268523f, -2.429677f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 3, 0);
        rightPos = new Vector3(-0.6544234f, -1.069519f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 3, 0, -1.5f);
        rightPos = new Vector3(1.279423f, 2.16f, -1);
        rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);
    }
    public void LevelFifteenThreeElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 4, field);
        FillingCell(4, 7, field);
        FillingCell(8, 9, field);
        FillingCell(9, 12, field);
        FillingCell(15, 17, field);
        FillingCell(21, 23, field);

        Small(field.pink.gameObject, 1, 0);
        var rightPos = new Vector3(2.139711f, 0.6659622f, -1);
        var rightRotation = new Vector3(0, 0, 120);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);
        
        Small(field.cyan.gameObject, 2, 180);
        rightPos = new Vector3(0.419134f, -1.498013f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 3, 0);
        rightPos = new Vector3(-1.000001f, -2.16f, -1);
        rightRotation = new Vector3(0, 0, 0);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 3, 0, -1.5f);
        rightPos = new Vector3(0.7205774f, -0.4200001f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);
    }
    public void LevelSixteenThreeElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 3, field);
        FillingCell(4, 6, field);
        FillingCell(9, 11, field);
        FillingCell(15, 16, field);
        FillingCell(20, 24, field);
        FillingCell(26, 28, field);
        FillingCell(31, 32, field);

        Small(field.pink.gameObject, 1, 0);
        var rightPos = new Vector3(2.139711f, -0.654038f, -1);
        var rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 2, 0);
        rightPos = new Vector3(1.5f, 1.21f, -1);
        rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 3, 180);
        rightPos = new Vector3(1.268523f, -2.429677f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 3, 0, -1.5f);
        rightPos = new Vector3(4.291534e-07f, 0.8399999f, -1);
        rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);
    }
    public void LevelSeventeenThreeElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 1, field);
        FillingCell(4, 8, field);
        FillingCell(9, 11, field);
        FillingCell(12, 13, field);
        FillingCell(15, 17, field);
        FillingCell(20, 23, field);
        FillingCell(26, 27, field);
        FillingCell(28, 29, field);

        Small(field.pink.gameObject, 1, 0);
        var rightPos = new Vector3(0.6397116f, -0.2040381f, -1);
        var rightRotation = new Vector3(0, 0, 120);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 2, 180);
        rightPos = new Vector3(2f, -0.3399997f, -1);
        rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 3, 180);
        rightPos = new Vector3(1.360289f, 1.944038f, -1);
        rightRotation = new Vector3(180, 0, 60);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(0.08086624f, -2.851987f, -1);
        rightRotation = new Vector3(180, 0, 60);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);
    }
    public void LevelEighteenThreeElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 3, field);
        FillingCell(4, 6, field);
        FillingCell(9, 11, field);
        FillingCell(15, 16, field);
        FillingCell(20, 22, field);
        FillingCell(26, 27, field);
        FillingCell(28, 29, field);
        FillingCell(31, 34, field);

        Small(field.pink.gameObject, 1, 0);
        var rightPos = new Vector3(-0.639712f, -0.2159619f, -1);
        var rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 2, 180);
        rightPos = new Vector3(1.287565f, 0.1700001f, -1);
        rightRotation = new Vector3(180, 0, 60);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 3, 180);
        rightPos = new Vector3(1.720577f, -1.32f, -1);
        rightRotation = new Vector3(0, 180, 240);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(0.2500003f, 1.77f, -1);
        rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);
    }
    public void LevelNineteenThreeElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 4, field);
        FillingCell(4, 5, field);
        FillingCell(6, 9, field);
        FillingCell(13, 15, field);
        FillingCell(20, 21, field);
        FillingCell(26, 27, field);
        FillingCell(31, 34, field);

        Small(field.pink.gameObject, 1, 0);
        var rightPos = new Vector3(-1.360289f, -0.2040381f, -1);
        var rightRotation = new Vector3(0, 0, 120);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 2, 0);
        rightPos = new Vector3(1.287564f, -0.1700001f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 0);
        rightPos = new Vector3(0, 0.48f, -1);
        rightRotation = new Vector3(0, 0, 0);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 3, 0, -1.5f);
        rightPos = new Vector3(0.2500003f, -1.77f, -1);
        rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);
    }
    public void LevelTwentyThreeElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 4, field);
        FillingCell(4, 5, field);
        FillingCell(6, 9, field);
        FillingCell(9, 10, field);
        FillingCell(11, 15, field);
        FillingCell(17, 19, field);

        Small(field.pink.gameObject, 1, 0);
        var rightPos = new Vector3(-1.360289f, 0.2159624f, -1);
        var rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 2, 180);
        rightPos = new Vector3(1.779423f, -1.289999f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 180);
        rightPos = new Vector3(0.08086624f, -2.851987f, -1);
        rightRotation = new Vector3(180, 0, 60);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(-1.268523f, -1.050322f, -1);
        rightRotation = new Vector3(180, 0, 60);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);
    }
    public void LevelTwentyOneThreeElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 4, field);
        FillingCell(4, 7, field);
        FillingCell(9, 12, field);
        FillingCell(15, 17, field);
        FillingCell(20, 23, field);

        Small(field.pink.gameObject, 1, 0);
        var rightPos = new Vector3(1.360289f, -0.2159615f, -1);
        var rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 2, 180);
        rightPos = new Vector3(0.7875639f, 1.04f, -1);
        rightRotation = new Vector3(180, 0, 60);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 3, 180);
        rightPos = new Vector3(-0.2499999f, -1.77f, -1);
        rightRotation = new Vector3(180, 0, 0);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(1f, -2.16f, -1);
        rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);
    }
    public void LevelTwentyTwoThreeElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 4, field);
        FillingCell(4, 7, field);
        FillingCell(9, 12, field);
        FillingCell(15, 18, field);
        FillingCell(21, 22, field);
        FillingCell(23, 24, field);

        Small(field.red.gameObject, 1, 0);
        var rightPos = new Vector3(1f, 0.9000001f, -1);
        var rightRotation = new Vector3(0, 0, 0);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 2, 0);
        rightPos = new Vector3(2f, -0.3399997f, -1);
        rightRotation = new Vector3(0, 0, 0);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 3, 0);
        rightPos = new Vector3(0.7500001f, -1.71f, -1);
        rightRotation = new Vector3(0, 0, 0);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(-1.360289f, -1.944038f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);
    }
    public void LevelTwentyThreeThreeElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 4, field);
        FillingCell(4, 7, field);
        FillingCell(8, 9, field);
        FillingCell(9, 11, field);
        FillingCell(13, 15, field);
        FillingCell(15, 16, field);
        FillingCell(19, 20, field);
        FillingCell(20, 21, field);

        Small(field.red.gameObject, 1, 0);
        var rightPos = new Vector3(-0.4999998f, -0.03000021f, -1);
        var rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 2, 0);
        rightPos = new Vector3(-0.4191349f, -1.498013f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 3, 0);
        rightPos = new Vector3(0.595577f, 0.640481f, -1);
        rightRotation = new Vector3(0, 0, 120);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(1f, -2.159999f, -1);
        rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);
    }
    public void LevelTwentyFourThreeElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 4, field);
        FillingCell(4, 7, field);
        FillingCell(8, 9, field);
        FillingCell(9, 12, field);
        FillingCell(15, 17, field);
        FillingCell(20, 22, field);
        //FillingCell(26, 27, field);
        //FillingCell(31, 34, field);

        Small(field.red.gameObject, 1, 0);
        var rightPos = new Vector3(0.2794231f, -2.16f, -1);
        var rightRotation = new Vector3(0, 0, 300);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 2, 0);
        rightPos = new Vector3(1.5f, -0.3899999f, -1);
        rightRotation = new Vector3(0, 0, 0);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 3, 0);
        rightPos = new Vector3(-0.6544229f, -1.069519f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(2.139711f, 0.6540384f, -1);
        rightRotation = new Vector3(180, 0, 60);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);
    }
    // TwoElements TwoElements TwoElements TwoElements TwoElements TwoElements
    public void LevelOneTwoElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 3, field);
        FillingCell(4, 7, field);
        FillingCell(11, 12, field);
        FillingCell(16, 18, field);
        FillingCell(23, 24, field);

        Small(field.red.gameObject, 1, 0);
        var rightPos = new Vector3(1.720577f, 1.32f, -1);
        var rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 2, 180);
        rightPos = new Vector3(-1.360289f, -1.944038f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 3, 0);
        rightPos = new Vector3(0.2500003f, -1.77f, -1);
        rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(-1.919135f, -0.6319871f, -1);
        rightRotation = new Vector3(0, 180, 300);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 2, 0, -1.5f);
        rightPos = new Vector3(1.287564f, -0.1700001f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);
    }
    public void LevelTwoTwoElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 5, field);
        FillingCell(6, 7, field);
        FillingCell(9, 11, field);
        FillingCell(15, 16, field);
        FillingCell(21, 22, field);

        Small(field.red.gameObject, 1, 0);
        var rightPos = new Vector3(0.2205767f, -0.4499998f, -1);
        var rightRotation = new Vector3(0, 0, 120);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 2, 180);
        rightPos = new Vector3(-1.360289f, -1.944038f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 3, 180);
        rightPos = new Vector3(2.375f, 0.6455445f, -1);
        rightRotation = new Vector3(180, 0, 300);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(0.4174684f, -1.498974f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 2, 0, -1.5f);
        rightPos = new Vector3(-0.2581972f, 1.048335f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);
    }
    public void LevelThreeTwoElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 1, field);
        FillingCell(4, 6, field);
        FillingCell(9, 12, field);
        FillingCell(15, 17, field);
        FillingCell(21, 22, field);
        FillingCell(27, 28, field);

        Small(field.yellow.gameObject, 1, 0);
        var rightPos = new Vector3(1.712435f, 1.91f, -1);
        var rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 2, 0);
        rightPos = new Vector3(-1f, -2.16f, -1);
        rightRotation = new Vector3(0, 0, 0);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 3, 0);
        rightPos = new Vector3(0.2500007f, -1.77f, -1);
        rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 0, -1.5f);
        rightPos = new Vector3(0f, 1.26f, -1);
        rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 2, 0, -1.5f);
        rightPos = new Vector3(0.7314765f, -0.6896777f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);
    }
    public void LevelFourTwoElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 3, field);
        FillingCell(5, 7, field);
        FillingCell(10, 13, field);
        FillingCell(17, 19, field);

        Small(field.yellow.gameObject, 1, 180);
        var rightPos = new Vector3(1.212435f, -1.04f, -1);
        var rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 2, 180);
        rightPos = new Vector3(1f, -2.16f, -1);
        rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 3, 0);
        rightPos = new Vector3(-2.404422f, 0.640481f, -1);
        rightRotation = new Vector3(0, 0, 120);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(1.5f, 1.71f, -1);
        rightRotation = new Vector3(180, 0, 0);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 2, 180, -1.5f);
        rightPos = new Vector3(-0.7719024f, -0.9882526f, -1);
        rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);
    }
    public void LevelFiveTwoElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 1, field);
        FillingCell(4, 8, field);
        FillingCell(10, 12, field);
        FillingCell(16, 18, field);
        FillingCell(22, 23, field);

        Small(field.yellow.gameObject, 1, 0);
        var rightPos = new Vector3(2f, -1.4f, -1);
        var rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 2, 0);
        rightPos = new Vector3(1.360289f, 1.944038f, -1);
        rightRotation = new Vector3(180, 0, 60);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 3, 180);
        rightPos = new Vector3(0.5955766f, -0.6404805f, -1);
        rightRotation = new Vector3(0, 180, 300);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(-2.139712f, -0.654038f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 2, 0, -1.5f);
        rightPos = new Vector3(-1.268524f, -2.429677f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);
    }
    public void LevelSixTwoElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 3, field);
        FillingCell(4, 6, field);
        FillingCell(9, 12, field);
        FillingCell(15, 16, field);
        FillingCell(20, 21, field);

        Small(field.yellow.gameObject, 1, 180);
        var rightPos = new Vector3(1.712435f, -1.91f, -1);
        var rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 2, 180);
        rightPos = new Vector3(1.779423f, 0.4499998f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 3, 180);
        rightPos = new Vector3(0.3455775f, -1.069519f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 3, 0, -1.5f);
        rightPos = new Vector3(0.3602885f, 1.535962f, -1);
        rightRotation = new Vector3(180, 0, 300);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 2, 180, -1.5f);
        rightPos = new Vector3(-1.728099f, -1.621747f, -1);
        rightRotation = new Vector3(180, 0, 0);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);
    }
    public void LevelSevenTwoElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 3, field);
        FillingCell(4, 7, field);
        FillingCell(9, 12, field);
        FillingCell(16, 17, field);

        Small(field.blue.gameObject, 1, 0);
        var rightPos = new Vector3(1.360289f, -1.944038f, -1);
        var rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 2, 180);
        rightPos = new Vector3(1.279423f, 1.32f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 3, 180);
        rightPos = new Vector3(-0.2500003f, -1.77f, -1);
        rightRotation = new Vector3(180, 0, 0);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(1.360289f, -0.2040381f, -1);
        rightRotation = new Vector3(180, 0, 300);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 2, 180, -1.5f);
        rightPos = new Vector3(-0.731477f, -0.6896777f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);
    }
    public void LevelEightTwoElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 1, field);
        FillingCell(4, 8, field);
        FillingCell(9, 11, field);
        FillingCell(12, 13, field);
        FillingCell(15, 16, field);
        FillingCell(20, 21, field);

        Small(field.blue.gameObject, 1, 0);
        var rightPos = new Vector3(1f, 2.16f, -1);
        var rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 2, 180);
        rightPos = new Vector3(-1.220578f, -1.29f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 0);
        rightPos = new Vector3(4.291534e-07f, -0.48f, -1);
        rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(4.291534e-07f, -2.159999f, -1);
        rightRotation = new Vector3(180, 0, 0);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 2, 0, -1.5f);
        rightPos = new Vector3(2.228099f, -0.7517471f, -1);
        rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);
    }
    public void LevelNineTwoElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 3, field);
        FillingCell(4, 5, field);
        FillingCell(9, 11, field);
        FillingCell(15, 17, field);
        FillingCell(20, 21, field);
        FillingCell(26, 27, field);

        Small(field.orange.gameObject, 1, 180);
        var rightPos = new Vector3(0.7500001f, 1.71f, -1);
        var rightRotation = new Vector3(0, 180, 180);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 2, 0);
        rightPos = new Vector3(1.279423f, -1.32f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 180);
        rightPos = new Vector3(4.291534e-07f, -0.48f, -1);
        rightRotation = new Vector3(180, 0, 0);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(0f, -2.159999f, -1);
        rightRotation = new Vector3(180, 0, 0);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 2, 180, -1.5f);
        rightPos = new Vector3(2f, 0.3400002f, -1);
        rightRotation = new Vector3(0, 180, 180);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);
    }
    public void LevelTenTwoElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 5, field);
        FillingCell(6, 7, field);
        FillingCell(9, 11, field);
        FillingCell(15, 17, field);

        Small(field.orange.gameObject, 1, 180);
        var rightPos = new Vector3(2.404423f, 0.640481f, -1);
        var rightRotation = new Vector3(0, 180, 120);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 2, 180);
        rightPos = new Vector3(-1.360289f, -1.944038f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 180);
        rightPos = new Vector3(0.4191344f, -1.498013f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 3, 0, -1.5f);
        rightPos = new Vector3(-0.2685226f, 1.050322f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 2, 0, -1.5f);
        rightPos = new Vector3(-0.2124361f, -0.6999998f, -1);
        rightRotation = new Vector3(0, 0, 120);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);
    }
    public void LevelElevenTwoElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 1, field);
        FillingCell(4, 6, field);
        FillingCell(9, 12, field);
        FillingCell(15, 17, field);
        FillingCell(20, 22, field);

        Small(field.orange.gameObject, 1, 180);
        var rightPos = new Vector3(-0.2499999f, -1.77f, -1);
        var rightRotation = new Vector3(180, 0, 0);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 2, 180);
        rightPos = new Vector3(1f, -2.159999f, -1);
        rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 180);
        rightPos = new Vector3(8.583069e-07f, 0.48f, -1);
        rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 3, 0, -1.5f);
        rightPos = new Vector3(1.268523f, 2.429678f, -1);
        rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 2, 0, -1.5f);
        rightPos = new Vector3(1.360289f, -0.2159615f, -1);
        rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);
    }
    public void LevelTwelveTwoElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 3, field);
        FillingCell(5, 8, field);
        FillingCell(10, 13, field);
        FillingCell(17, 18, field);

        Small(field.orange.gameObject, 1, 0);
        var rightPos = new Vector3(-2.404423f, 0.640481f, -1);
        var rightRotation = new Vector3(0, 0, 120);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 2, 180);
        rightPos = new Vector3(1f, -2.159999f, -1);
        rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 0);
        rightPos = new Vector3(-0.4191344f, -1.498013f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 3, 0, -1.5f);
        rightPos = new Vector3(-0.268523f, -0.6896777f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 2, 180, -1.5f);
        rightPos = new Vector3(2f, 1.4f, -1);
        rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);
    }
    public void LevelThirteenTwoElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 3, field);
        FillingCell(4, 5, field);
        FillingCell(9, 10, field);
        FillingCell(15, 17, field);
        FillingCell(20, 22, field);
        FillingCell(26, 27, field);

        Small(field.orange.gameObject, 1, 0);
        var rightPos = new Vector3(2.404423f, -0.6404805f, -1);
        var rightRotation = new Vector3(0, 0, 300);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 2, 180);
        rightPos = new Vector3(0, -2.16f, -1);
        rightRotation = new Vector3(180, 0, 0);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 0);
        rightPos = new Vector3(0.4191344f, 1.498013f, -1);
        rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(-0.268523f, -1.050323f, -1);
        rightRotation = new Vector3(0, 180, 240);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 2, 180, -1.5f);
        rightPos = new Vector3(-0.2124352f, 0.6999998f, -1);
        rightRotation = new Vector3(0, 180, 300);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);
    }
    public void LevelFourteenTwoElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 2, field);
        FillingCell(4, 6, field);
        FillingCell(9, 11, field);
        FillingCell(15, 16, field);
        FillingCell(20, 21, field);
        FillingCell(26, 27, field);
        FillingCell(31, 32, field);

        Small(field.orange.gameObject, 1, 0);
        var rightPos = new Vector3(2.404423f, 0.640481f, -1);
        var rightRotation = new Vector3(0, 0, 120);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 2, 180);
        rightPos = new Vector3(-1.360289f, -1.944038f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 0);
        rightPos = new Vector3(0.4191344f, -1.498013f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 3, 0, -1.5f);
        rightPos = new Vector3(-0.2685226f, 1.050322f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 2, 180, -1.5f);
        rightPos = new Vector3(-0.2124361f, -0.6999998f, -1);
        rightRotation = new Vector3(0, 180, 120);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);
    }
    public void LevelFifteenTwoElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 1, field);
        FillingCell(4, 7, field);
        FillingCell(9, 13, field);
        FillingCell(16, 18, field);

        Small(field.blue.gameObject, 1, 0);
        var rightPos = new Vector3(1f, 2.16f, -1);
        var rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 2, 180);
        rightPos = new Vector3(1.360289f, 0.2159624f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 0);
        rightPos = new Vector3(-0.08086624f, -2.851987f, -1);
        rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 3, 0, -1.5f);
        rightPos = new Vector3(1.268523f, -1.050322f, -1);
        rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 2, 180, -1.5f);
        rightPos = new Vector3(-2f, -0.9000001f, -1);
        rightRotation = new Vector3(180, 0, 0);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);
    }
    public void LevelSixteenTwoElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 1, field);
        FillingCell(4, 7, field);
        FillingCell(9, 13, field);
        FillingCell(15, 17, field);

        Small(field.blue.gameObject, 1, 0);
        var rightPos = new Vector3(1.000001f, 2.16f, -1);
        var rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 2, 180);
        rightPos = new Vector3(1.360289f, 0.2159624f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 180);
        rightPos = new Vector3(0.08086667f, -2.851987f, -1);
        rightRotation = new Vector3(0, 180, 240);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 3, 0, -1.5f);
        rightPos = new Vector3(-0.731477f, -1.050322f, -1);
        rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 2, 0, -1.5f);
        rightPos = new Vector3(0.7875639f, -1.04f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);
    }
    public void LevelSeventeenTwoElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 3, field);
        FillingCell(4, 5, field);
        FillingCell(9, 11, field);
        FillingCell(15, 17, field);
        FillingCell(20, 22, field);

        Small(field.orange.gameObject, 1, 0);
        var rightPos = new Vector3(2.404423f, 0.640481f, -1);
        var rightRotation = new Vector3(0, 0, 120);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 2, 180);
        rightPos = new Vector3(-1.360289f, -1.944038f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 0);
        rightPos = new Vector3(0.4191344f, -1.498013f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 3, 0, -1.5f);
        rightPos = new Vector3(-0.2685226f, 1.050322f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 2, 180, -1.5f);
        rightPos = new Vector3(-0.2124361f, -0.6999998f, -1);
        rightRotation = new Vector3(0, 180, 120);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);
    }
    public void LevelEighteenTwoElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 3, field);
        FillingCell(4, 7, field);
        FillingCell(9, 12, field);
        FillingCell(15, 16, field);

        Small(field.orange.gameObject, 1, 0);
        var rightPos = new Vector3(2.404423f, 0.640481f, -1);
        var rightRotation = new Vector3(0, 0, 120);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 2, 180);
        rightPos = new Vector3(-1.360289f, -1.944038f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 0);
        rightPos = new Vector3(0.4191344f, -1.498013f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 3, 0, -1.5f);
        rightPos = new Vector3(-0.2685226f, 1.050322f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 2, 180, -1.5f);
        rightPos = new Vector3(-0.2124361f, -0.6999998f, -1);
        rightRotation = new Vector3(0, 180, 120);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);
    }
    public void LevelNineteenTwoElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 2, field);
        FillingCell(4, 7, field);
        FillingCell(9, 12, field);
        FillingCell(15, 16, field);
        FillingCell(17, 18, field);

        Small(field.orange.gameObject, 1, 0);
        var rightPos = new Vector3(2.404423f, 0.640481f, -1);
        var rightRotation = new Vector3(0, 0, 120);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 2, 180);
        rightPos = new Vector3(-1.360289f, -1.944038f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 0);
        rightPos = new Vector3(0.4191344f, -1.498013f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 3, 0, -1.5f);
        rightPos = new Vector3(-0.2685226f, 1.050322f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 2, 180, -1.5f);
        rightPos = new Vector3(-0.2124361f, -0.6999998f, -1);
        rightRotation = new Vector3(0, 180, 120);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);
    }
    public void LevelTwentyTwoElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 4, field);

        FillingCell(4, 5, field);
        FillingCell(6, 7, field);
        FillingCell(8, 9, field);
        FillingCell(14, 15, field);
        FillingCell(19, 20, field);
        FillingCell(24, 25, field);

        Small(field.orange.gameObject, 1, 180);
        var rightPos = new Vector3(-0.2500003f, 0.9000001f, -1);
        var rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 2, 180);
        rightPos = new Vector3(-2.139711f, 0.6659622f, -1);
        rightRotation = new Vector3(180, 0, 300);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 0);
        rightPos = new Vector3(0.4191344f, -1.501987f, -1);
        rightRotation = new Vector3(0, 0, 300);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 3, 0, -1.5f);
        rightPos = new Vector3(1.712435f, -1.909999f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 2, 180, -1.5f);
        rightPos = new Vector3(-1.279423f, -1.32f, -1);
        rightRotation = new Vector3(0, 180, 240);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);
    }
    public void LevelTwentyOneTwoElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 4, field);
        FillingCell(4, 7, field);
        FillingCell(10, 12, field);
        FillingCell(16, 17, field);

        Small(field.orange.gameObject, 1, 0);
        var rightPos = new Vector3(-0.7500005f, -1.71f, -1);
        var rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 2, 180);
        rightPos = new Vector3(1f, -2.159999f, -1);
        rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 0);
        rightPos = new Vector3(4.291534e-07f, 0.48f, -1);
        rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 3, 0, -1.5f);
        rightPos = new Vector3(-2f, -0.3399997f, -1);
        rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 2, 180, -1.5f);
        rightPos = new Vector3(2.228099f, 0.7517471f, -1);
        rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);
    }
    public void LevelTwentyTwoTwoElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 4, field);
        FillingCell(4, 7, field);
        FillingCell(10, 13, field);

        Small(field.orange.gameObject, 1, 0);
        var rightPos = new Vector3(0.2500007f, -1.77f, -1);
        var rightRotation = new Vector3(0, 0, 180);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 2, 180);
        rightPos = new Vector3(-1.360289f, -1.944038f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 3, 0);
        rightPos = new Vector3(-1.360289f, -0.2040381f, -1);
        rightRotation = new Vector3(0, 0, 120);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(1.212436f, -0.6999998f, -1);
        rightRotation = new Vector3(180, 0, 300);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 2, 180, -1.5f);
        rightPos = new Vector3(2f, 0.9000001f, -1);
        rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);
    }
    public void LevelTwentyThreeTwoElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 4, field);
        FillingCell(4, 9, field);
        FillingCell(9, 10, field);

        Small(field.orange.gameObject, 1, 180);
        var rightPos = new Vector3(-0.2500003f, -1.77f, -1);
        var rightRotation = new Vector3(0, 180, 180);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 2, 180);
        rightPos = new Vector3(1f, -2.16f, -1);
        rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 3, 0);
        rightPos = new Vector3(1.360289f, -0.2159615f, -1);
        rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 0, -1.5f);
        rightPos = new Vector3(0.08086581f, 1.111987f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 2, 180, -1.5f);
        rightPos = new Vector3(-0.731477f, -0.6896777f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);
    }
    public void LevelTwentyFourTwoElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 4, field);
        FillingCell(4, 7, field);
        FillingCell(8, 9, field);
        FillingCell(11, 13, field);

        Small(field.yellow.gameObject, 1, 180);
        var rightPos = new Vector3(1.5f, -1.21f, -1);
        var rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 2, 180);
        rightPos = new Vector3(-1.360289f, -1.944038f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 3, 0);
        rightPos = new Vector3(2.139711f, 0.6659622f, -1);
        rightRotation = new Vector3(0, 0, 120);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(-1.919135f, -0.6319871f, -1);
        rightRotation = new Vector3(0, 180, 300);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 2, 180, -1.5f);
        rightPos = new Vector3(0, -0.8399997f, -1);
        rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);
    }
    public void LevelTwentyFiveTwoElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 4, field);
        FillingCell(4, 6, field);
        FillingCell(9, 11, field);
        FillingCell(15, 16, field);
        FillingCell(20, 21, field);

        Small(field.green.gameObject, 1, 180);
        var rightPos = new Vector3(2.404423f, 0.640481f, -1);
        var rightRotation = new Vector3(0, 180, 120);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 2, 180);
        rightPos = new Vector3(-1.360289f, -1.944038f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 3, 0);
        rightPos = new Vector3(0.4191344f, -1.498013f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(-0.2685226f, 1.050322f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 2, 180, -1.5f);
        rightPos = new Vector3(-0.2124361f, -0.6999998f, -1);
        rightRotation = new Vector3(0, 180, 120);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);
    }
    public void LevelTwentySixTwoElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 1, field);
        FillingCell(4, 6, field);
        FillingCell(9, 12, field);
        FillingCell(15, 17, field);
        FillingCell(20, 21, field);
        FillingCell(26, 27, field);

        Small(field.yellow.gameObject, 1, 180);
        var rightPos = new Vector3(1.212435f, -1.04f, -1);
        var rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 2, 180);
        rightPos = new Vector3(1f, -2.16f, -1);
        rightRotation = new Vector3(0, 180, 0);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 3, 0);
        rightPos = new Vector3(-1.139711f, -1.085962f, -1);
        rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(0.08086581f, 1.108013f, -1);
        rightRotation = new Vector3(0, 180, 300);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 2, 180, -1.5f);
        rightPos = new Vector3(1.5f, 1.71f, -1);
        rightRotation = new Vector3(180, 0, 0);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);
    }
    public void LevelTwentySevenTwoElements(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 3, field);

        FillingCell(4, 5, field);

        FillingCell(9, 10, field);

        FillingCell(15, 16, field);

        FillingCell(20, 22, field);

        FillingCell(26, 27, field);

        FillingCell(31, 32, field);

        Small(field.orange.gameObject, 1, 0);
        var rightPos = new Vector3(-0.5955778f, -0.6404805f, -1);
        var rightRotation = new Vector3(0, 0, 300);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 2, 180);
        rightPos = new Vector3(1.268523f, -2.429677f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 3, 0);
        rightPos = new Vector3(2.139711f, -0.654038f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 0, -1.5f);
        rightPos = new Vector3(0.4191344f, 1.498013f, -1);
        rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 2, 180, -1.5f);
        rightPos = new Vector3(0.7205774f, 0.4200001f, -1);
        rightRotation = new Vector3(0, 180, 240);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);
    }
    // OneElements OneElements OneElements OneElements OneElements OneElements
    public void LevelOneOneElement(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 2, field);
        FillingCell(4, 6, field);
        FillingCell(10, 11, field);

        Small(field.yellow.gameObject, 1, 180);
        var rightPos = new Vector3(2f, 0.3400002f, -1);
        var rightRotation = new Vector3(0, 180, 180);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 2, 180);
        rightPos = new Vector3(0.6544229f, -1.069519f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 3, 0);
        rightPos = new Vector3(-1.268523f, -2.429677f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 1, 0, -1.5f);
        rightPos = new Vector3(-2.139712f, -0.6659617f, -1);
        rightRotation = new Vector3(0, 0, 300);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 0, -1.5f);
        rightPos = new Vector3(-0.4191344f, 1.501987f, -1);
        rightRotation = new Vector3(0, 0, 120);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 2, 180, -1.5f);
        rightPos = new Vector3(1.139711f, 1.085962f, -1);
        rightRotation = new Vector3(180, 0, 300);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);
    }
    public void LevelTwoOneElement(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 1, field);
        FillingCell(5, 7, field);
        FillingCell(11, 12, field);
        FillingCell(17, 18, field);

        Small(field.yellow.gameObject, 1, 180);
        var rightPos = new Vector3(2.404423f, 0.640481f, -1);
        var rightRotation = new Vector3(0, 180, 120);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 2, 180);
        rightPos = new Vector3(2.404423f, 0.640481f, -1);
        rightRotation = new Vector3(0, 180, 120);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.green.gameObject, 3, 180);
        rightPos = new Vector3(-1.360289f, -1.944038f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 1, 0, -1.5f);
        rightPos = new Vector3(0.4191344f, -1.498013f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(-0.2685226f, 1.050322f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 2, 180, -1.5f);
        rightPos = new Vector3(-0.2124361f, -0.6999998f, -1);
        rightRotation = new Vector3(0, 180, 120);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);
    }
    public void LevelThreeOneElement(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 1, field);
        FillingCell(4, 5, field);
        FillingCell(10, 12, field);
        FillingCell(16, 17, field);

        Small(field.yellow.gameObject, 1, 180);
        var rightPos = new Vector3(2.404423f, 0.640481f, -1);
        var rightRotation = new Vector3(0, 180, 120);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 2, 180);
        rightPos = new Vector3(2.404423f, 0.640481f, -1);
        rightRotation = new Vector3(0, 180, 120);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 3, 180);
        rightPos = new Vector3(-1.360289f, -1.944038f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 1, 0, -1.5f);
        rightPos = new Vector3(0.4191344f, -1.498013f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(-0.2685226f, 1.050322f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 2, 180, -1.5f);
        rightPos = new Vector3(-0.2124361f, -0.6999998f, -1);
        rightRotation = new Vector3(0, 180, 120);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);
    }
    public void LevelFourOneElement(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 3, field);
        FillingCell(4, 6, field);

        Small(field.green.gameObject, 1, 180);
        var rightPos = new Vector3(2.404423f, 0.640481f, -1);
        var rightRotation = new Vector3(0, 180, 120);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 2, 180);
        rightPos = new Vector3(2.404423f, 0.640481f, -1);
        rightRotation = new Vector3(0, 180, 120);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 3, 180);
        rightPos = new Vector3(-1.360289f, -1.944038f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 1, 0, -1.5f);
        rightPos = new Vector3(0.4191344f, -1.498013f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(-0.2685226f, 1.050322f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 2, 180, -1.5f);
        rightPos = new Vector3(-0.2124361f, -0.6999998f, -1);
        rightRotation = new Vector3(0, 180, 120);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);
    }
    public void LevelFiveOneElement(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 3, field);
        FillingCell(5, 7, field);

        Small(field.green.gameObject, 1, 180);
        var rightPos = new Vector3(2.404423f, 0.640481f, -1);
        var rightRotation = new Vector3(0, 180, 120);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 2, 180);
        rightPos = new Vector3(2.404423f, 0.640481f, -1);
        rightRotation = new Vector3(0, 180, 120);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 3, 180);
        rightPos = new Vector3(-1.360289f, -1.944038f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.yellow.gameObject, 1, 0, -1.5f);
        rightPos = new Vector3(0.4191344f, -1.498013f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.yellow.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 180, -1.5f);
        rightPos = new Vector3(-0.2685226f, 1.050322f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 2, 180, -1.5f);
        rightPos = new Vector3(-0.2124361f, -0.6999998f, -1);
        rightRotation = new Vector3(0, 180, 120);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);
    }
    public void LevelSixOneElement(FieldController field)
    {
        ClearHelpFigurs();

        FillingCell(0, 1, field);

        FillingCell(5, 7, field);

        FillingCell(11, 13, field);

        //FillingCell(16, 17, field);

        //FillingCell(20, 22, field);

        //FillingCell(26, 27, field);

        //FillingCell(31, 32, field);

        Small(field.green.gameObject, 1, 0);
        var rightPos = new Vector3(1.268523f, -1.050322f, -1);
        var rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.green.gameObject, rightRotation, rightPos);

        Small(field.orange.gameObject, 2, 180);
        rightPos = new Vector3(-1.154424f, 0.1995192f, -1);
        rightRotation = new Vector3(180, 0, 60);
        PutPositionFigure(field.orange.gameObject, rightRotation, rightPos);

        Small(field.pink.gameObject, 3, 180);
        rightPos = new Vector3(1.360289f, 0.2159624f, -1);
        rightRotation = new Vector3(0, 180, 60);
        PutPositionFigure(field.pink.gameObject, rightRotation, rightPos);

        Small(field.red.gameObject, 1, 0, -1.5f);
        rightPos = new Vector3(-1.779423f, -1.29f, -1);
        rightRotation = new Vector3(0, 0, 60);
        PutPositionFigure(field.red.gameObject, rightRotation, rightPos);

        Small(field.cyan.gameObject, 3, 0, -1.5f);
        rightPos = new Vector3(-0.08086495f, -2.851987f, -1);
        rightRotation = new Vector3(0, 0, 240);
        PutPositionFigure(field.cyan.gameObject, rightRotation, rightPos);

        Small(field.blue.gameObject, 2, 180, -1.5f);
        rightPos = new Vector3(1.360289f, 1.944038f, -1);
        rightRotation = new Vector3(180, 0, 60);
        PutPositionFigure(field.blue.gameObject, rightRotation, rightPos);
    }
    private void FillingCell(int start, int end, FieldController field)
    {
        for (int i = start; i < end; i++)
        {
            field.fieldCellsLonpos[i].gameObject.SetActive(false);
        }
    }
    public void Small(GameObject figure, int number, float yRotation, float yPos = 0)
    {
        figure.SetActive(true);

        MoveFigurs move = figure.GetComponent<MoveFigurs>();
        move.SetTarget(new Vector3(-4f + number * 2.1f, -5f + yPos, 9)); 
        move.SetStartPos();

        figure.transform.rotation = new Quaternion(0, yRotation, 0, 0);
        figure.transform.localScale = new Vector3(smallSize, smallSize, 1);
    }
    public void PutPositionFigure(GameObject figure, Vector3 rotation, Vector3 pos)
    {
        figurs.Add(figure);
        figursPos.Add(pos);
        figursRotation.Add(rotation);
    }
    private void ClearHelpFigurs()
    {
        figurs.Clear();
        figursPos.Clear();
        figursRotation.Clear();
    }
    private void Reset(FieldController field)
    {
        field.yellow.gameObject.SetActive(false);
        field.yellow.disabled = false;

        field.red.gameObject.SetActive(false);
        field.red.disabled = false;

        field.pink.gameObject.SetActive(false);
        field.pink.disabled = false;

        field.orange.gameObject.SetActive(false);
        field.orange.disabled = false;

        field.blue.gameObject.SetActive(false);
        field.blue.disabled = false;

        field.green.gameObject.SetActive(false);
        field.green.disabled = false;

        field.cyan.gameObject.SetActive(false);
        field.cyan.disabled = false;
    }
}
