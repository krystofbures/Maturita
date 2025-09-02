using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    //Importování častí dialogového okna pro použití v dialogovém manageru
    public GameObject DialogPanel;
    public TMP_Text DialogueName;
    public TMP_Text DialogueText;

    //Věci pro funkčnost mezi scripty a pro funkčnost tohoto scriptu [] - toto znamená POLE!!!
    private (string speaker, string line)[] dialogue; //dialogue - aktualní data dialogu která manager užívá n oa díky tomu manager nezávisí na NPC ale na poli které je ve scriptu který má načíst
    private int index; //Sleduje který řadek se zobrazuje 
    private bool isActive = false; //Kontrola zda dialog jede

    void Start()
    {
        DialogPanel.SetActive(false); //Toto udělá to že když se hra zapne tak dialogové okno není vidět
    }

    void Update()
    {
        if (isActive && Input.GetKeyDown(KeyCode.Q)) //Toto posouvá samotným dialogem 
        {
            NextLine(); //Metoda která posune na další část dialogu pomoci Q
        }
    }

    //Tato metoda nastaví index dialogu na 0 activuje dialog zobrazí dialogovou lištu a ukaže první řadek
    public void StartDialogue((string, string)[] npcDialogue)
    {
        dialogue = npcDialogue;
        index = 0;
        isActive = true;
        DialogPanel.SetActive(true);
        ShowLine();
    }

    //Tato metoda zobrazí text a taky jmeno postavy pokud ještě zbýva text jede dál pokud ne ukončí dialog
    private void ShowLine()
    {
        if (index < dialogue.Length)
        {
            DialogueName.text = dialogue[index].speaker; //Toto dodává jmeno postavy do dialogovéh okna
            DialogueText.text = dialogue[index].line; //Toto dodává text postavy do dialogovéh okna
        }
        else
        {
            EndDialogue(); //Ukončí dialog pokud už žadný text nezbývá
        }
    }

    //Přidá index a poté ukáže posunutý text podle toho indexu
    private void NextLine()
    {
        index++;
        ShowLine();
    }

    //Toto restartuje manager vypne dialog a teleportuje hráče dále pokud v dialogu je funkce OnDialogue End
    private void EndDialogue()
    {
        isActive = false;
        DialogueName.text = "";
        DialogueText.text = "";
        DialogPanel.SetActive(false);

        OnDialogueEnd();
    }
    
}
