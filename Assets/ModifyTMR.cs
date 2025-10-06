using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;

public class ModifyTMR : MonoBehaviour
{

    public TMP_Text canvasText;
    public GameObject funFact;

    public string[] ffsVariable;
    public float interval = 10f;

    private Coroutine ffRoutine;
    private bool isRunning = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ffsVariable = getFunFacts();
        funFact.SetActive(false);
        ffRoutine = StartCoroutine(ShowFunFacts());
        isRunning = true;
    }

    IEnumerator ShowFunFacts() 
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);

            //to get random fun fact
            if (ffsVariable.Length > 0)
            {
                string randomFact = ffsVariable[Random.Range(0, ffsVariable.Length)];
                canvasText.text = randomFact;
            }
            canvasText.canvasRenderer.SetAlpha(0f);
            funFact.SetActive(true);
            canvasText.CrossFadeAlpha(1.0f, 0.05f, false);
            yield return new WaitForSeconds(7f);
            canvasText.CrossFadeAlpha(0.0f, 0.05f, false);
            //might need to wait again (yield return...)
            funFact.SetActive(false);
        }
    }

    public void StopFunFacts()
    {
        if(isRunning && ffRoutine != null)
        {
            StopCoroutine(ffRoutine);
            funFact.SetActive(false);
            isRunning = false;
        }
    }

    string[] getFunFacts ()
    {
        string[] facts = { "The outershell for this habitat is a carbon fiber reinforced polymers. Since the payload is precious, it MUST meet the following requirements: withstand intense temperature changes of a 300K difference, skin friction of around 17,000N at the max, good damping abilities to not damage the crew members hearing, and staying within the alloted budget.",
                           "The reason to have this exercise equipment is since the crew is experiencing very low gravity the long term effects of that on the human body can be very dangerous, leading to bone degeneration and a weaker heart.",
                           "The sleeping area should be on the top level so as not to be disturbed by noise from others in case one astronaut needs to always be operating the habitat",
                           "The space suit should go near the airlock since that should be the only reason to put on the suit.",
                           "Waste collection should be at the bottom of the spacecraft to avoid it getting caught up in the habitat after be thrown out the vacuum shoot",
                           "Airlocks allow astronauts to move between the habitat's pressure and space's almost 0 pressure environemtn without having to depressurize the whole habitat.",
                           "To save space in the cabin these beds are fold out/murphy style to save space and allow the bedroom to also be used to get dressed, do stretches, and other morning routines"};
        return facts;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
