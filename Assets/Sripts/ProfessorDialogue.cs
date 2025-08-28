using UnityEngine;

public class ProfessorDialogue : MonoBehaviour
{
    public DialogueManager dialogueManager; //Propojí dialogový manager misto odkud se řídí celé dialogové UI s timto custom dialogem pro NPC a hrače 
    public GameObject ExclamationMark; //Přídává otazník nad postavmi když se s nimi dá interagovat

    private (string speaker, string line)[] npcDialogue = new (string, string)[] //Speaker - Jmeno postavy Line - Co ta postav říka 
    {
        ("Profesor", "Ahoj Rousi konečně...konečně..."),
        ("Profesor", "JSEM TO DOKÁZAL!!!"),
        ("Rous", "Co jeste konečně dokázal profesore?"),
        ("Profesor", "Dokázal jsme vynalézt STROJ ČASU Rousi"),
        ("Profesor", "Konečně budeme schopni zastavit tento příšerný JEV"),
        ("Profesor", "Jev jmeném Smršti déšť"),
        ("Profesor", "Déšť který nas zmenšuje..."),
        ("Profesor", "a nedovoluje nám dosahnout na nábytek"),
        ("Rous", "Ale...to...je úžasné pane profesore"),
        ("Rous", "Opravdu funguje?"),
        ("Profesor", "Nooo tak to musíš zijstit sám!"),
        ("Rous", "COŽE!?"),
        ("Profesor", "Dnes bylo na planu testovaní..."),
        ("Profesor", "no a přišel jsi jediný takže je to na tobě"),
        ("Rous", "Aha tak teda dobrá"),
        ("Profesor", "Jsou to takové malé hodinky"),
        ("Profesor", "Timto tlačítkem je zapneš..."),
        ("Profesor", "a tímto posuvníkkem nastavíš rok, čas, atd."),
        ("Profesor", "Takže chápeš jak se to ovládá?"),
        ("Rous", "No nějak tomu ovládání rotumím"),
        ("Profesor", "Nastavil jsme posun před tím než se to stalo"),
        ("Profesor", "Než se stala ta katastrova a zjevil se JEV"),
        ("Profesor", "Takže do roku 3595"),
        ("Profesor", "Výborně...tak začneme"),
        ("Profesor", "Až to odpočítam stikní tlačítko a posuň se v čase"),
        ("Profesor", "3..."),
        ("Profesor", "2.."),
        ("Profesor", "1."),
        ("Profesor", "Teď!")
    };

    private bool dialogRange = false; //Tato proměnná pomoci bool nastavuje to že když player není v NPC colideru tak s nim nemuže mluvit

    void Start()
    {
        ExclamationMark.SetActive(false); //Toto udělá to že když se hra zapne tak vykřičník nepujde vidět
    }
    void Update()
    {
        if (dialogRange && Input.GetKeyDown(KeyCode.E))
        {
            ExclamationMark.SetActive(false);
            dialogueManager.StartDialogue(npcDialogue);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogRange = true;
            Debug.Log("Stiskni E pro rozhovor");
            ExclamationMark.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogRange = false;
            ExclamationMark.SetActive(false);
        }
    }
}
