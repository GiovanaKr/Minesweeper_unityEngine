using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//0 = null
//9 = bomb
//10 = block view 
//11 = over view
//12 = flag
//13 = ?
public class Block : MonoBehaviour
{
    public int num;
    public LayerMask mask;
    public bool clicked;
    public int marked;

    public Sprite[] sprites = new Sprite[14];

    void Awake(){
        num = 0;
        clicked = false;
        marked = 0;
    }

    void Start(){
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[10];
        if(num != -1){
            Collider2D[] listaCol = Physics2D.OverlapCircleAll(transform.position, 1, mask);

            foreach (Collider2D col in listaCol)
            {
                if(col.GetComponent<Block>().num == -1){
                    num++;
                }            
            }
        }
    }

    void OnMouseOver(){
        if(Input.GetMouseButtonDown(0) && marked == 0){
            if(num == -1){
                GameObject mn = GameObject.Find("Manager");
                mn.GetComponent<ManagerScene>().GameOver();
            }
            else if(num == -1 && !clicked){
                Reveal();
                Debug.Log("Game Over");
            }
            else if(num == 0 && !clicked){
                Reveal();
                RevealNull();
            }
            else if(!clicked){
                Reveal();
            }
        }

        //right click
        if(Input.GetMouseButtonDown(1) && !clicked){
            //flag
            if(marked == 0){
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[12];
                marked++;
            }
            //?
            else if(marked == 1){
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[13];
                marked++;
            }
            //back to normal
            else{
                marked = 0;
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[10];
            }
        }
    }

    //reveal all null blocks around
    public void RevealNull(){
        Collider2D[] listaCol = Physics2D.OverlapCircleAll(transform.position, 1, mask);
        foreach (Collider2D col in listaCol)
        {
            if(col.GetComponent<Block>().num == 0 && !col.GetComponent<Block>().clicked){
                col.GetComponent<Block>().Reveal();
                col.GetComponent<Block>().RevealNull();
            }            
            else if(col.GetComponent<Block>().num != 0 && col.GetComponent<Block>().num != -1 && !col.GetComponent<Block>().clicked){
                col.GetComponent<Block>().Reveal();
            }
        }
    }

    public void Reveal(){
        clicked = true;

        switch (num)
        {
            case -1:
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[9];
            break;

            case 1:
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
            break;

            case 2:
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
            break;

            case 3:
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
            break;

            case 4:
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[4];
            break;

            case 5:
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[5];
            break;

            case 6:
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[6];
            break;

            case 7:
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[7];
            break;

            case 8:
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[8];
            break;

            default:
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
            break;
        }
        
    }
}
