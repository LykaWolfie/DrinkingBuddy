using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MemoryGame : MonoBehaviour {
    public EventSystem ES;
    int clickNum,tries = 5;
    bool ended, coroutine;
    public GameObject MemoryBlock;
    int[] sequence = {0,1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
    
    private void Start() {
        for(int i = 0; i < sequence.Length; i++) {
            var rand = Random.Range(0, i);
            var tmp = sequence[i];
            sequence[i] = sequence[rand];
            sequence[rand] = tmp;

            Debug.Log(sequence[i]);
        }
        //spawn
        for (int x = 0; x < sequence.Length; x++) {
            GameObject block = Instantiate(MemoryBlock) as GameObject;
            block.SetActive(true);
            block.name = x.ToString();
            //Anchors the objects to the screen to avoid displacement
            block.transform.SetParent(this.transform);
            //Sets the position of the object relative to the anchor(Top-center)
            block.GetComponent<RectTransform>().anchoredPosition = new Vector2(((x%4)+1)*(800/5), -(((x/4)+1)*(1280/5)));
        }
        StartCoroutine(ShowSequence());
    }

    IEnumerator ShowSequence() {
        coroutine = true;
        for(int i = 0; i < sequence.Length; i++) {
            transform.Find(sequence[i].ToString()).GetComponent<Image>().color = Color.yellow;
            yield return new WaitForSeconds(0.5f);
            transform.Find(sequence[i].ToString()).GetComponent<Image>().color = Color.white;
        }
        coroutine = false;
    }

    public void BlockClick() {
        Debug.Log("Hello");
        if (!coroutine) {
            if (ES.currentSelectedGameObject.name == sequence[clickNum].ToString()) {
                clickNum++;
            }
            else {
                tries--;
                clickNum = 0;
                StartCoroutine(ShowSequence());
            }
        }       
    }
    void OnGUI() {
        //prints the current score and the game instructions
        GUI.Label(new Rect((Screen.width / 2) - 20, (Screen.height / 2) - 220, 600, 600), "TRIES: " + tries);
        GUI.Label(new Rect((Screen.width / 2) - 90, (Screen.height / 2) - 200, 600, 600), "The KITTY gets the MILKSHAKE");
        GUI.Label(new Rect((Screen.width / 2) - 85, (Screen.height / 2) - 180, 600, 600), "The BUNNY gets the PANCAKE");

        if (clickNum >= 15){
            GUI.Label((new Rect((Screen.width / 2) - 20, (Screen.height / 2) - 240, 600, 600)), "YOU PASS!");   
            //this is to avoid multiple calls of EndGame
            if (!ended) {
                //flips bit so that it wont enter this conditional again
                ended = !ended;
                //calls EndGame after 3 seconds
                Invoke("EndGame", 3);
            }
        }
        else if(tries <= 0) {
            if (!StartGame.Practice()) {
                SendSMS.Send("Hello!");

            }
            if (!ended) {
                //flips bit so that it wont enter this conditional again
                ended = !ended;
                //calls EndGame after 3 seconds
                Invoke("EndGame", 3);
            }
        }
    }

    /**Method Name: EndGame
    * Parameters: N/A
    * Returns: N/A
    * 
    * Loads the next scene, effectively ending the game
    * */
    void EndGame() {
        StartGame.LoadNext();
    }
}
