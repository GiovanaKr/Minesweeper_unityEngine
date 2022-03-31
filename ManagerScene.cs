using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ManagerScene : MonoBehaviour
{
    List<GameObject> gridList;

    int bombNum;

    public TextMeshProUGUI text;

    public Button img;
    public Sprite img1;
    public Sprite img2;

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Awake(){
        img.GetComponent<Image>().sprite = img1;

        gridList = gameObject.GetComponent<MinesweeperGrid>().gridList;

        foreach (GameObject obj in gridList)
        {
            if(obj.GetComponent<Block>().num == -1){
                bombNum++;
            }
        }

        text.SetText(bombNum.ToString());
    }

    public void GameOver(){
        foreach (GameObject Obj in gridList)
        {
            Obj.GetComponent<Block>().clicked = true;

            if(Obj.GetComponent<Block>().num == -1){
                Obj.GetComponent<Block>().Reveal();
            }
        }
        img.GetComponent<Image>().sprite = img2;
    }
}
