

using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MenuScript : MonoBehaviour {

    public bool Debug_Mode = false;
    public Image fadeImage;
    public GameObject endPanel;
    public Text MoneyRecord;
    public GameObject exitPanel;
    public Toggle debugModeTggl;
    private float fadeTime = 4.5f;
    private string ended;
    private int money;
    private bool exitActive = false;
    private bool clickedStart = false;
    private bool fade = false;
    public int massnum;
    string lastwords;
    public Text[] menutext;
    public GameObject Static_pan;
    public Text[] Correct_answer_rec;
    public Text mon;
    public Sprite[] images;
    public GameObject kar;
    void Awake()
    {
        if (!PlayerPrefs.HasKey("sim")) { PlayerPrefs.SetInt("sim", 0); }
        if (!PlayerPrefs.HasKey("grif")) { PlayerPrefs.SetInt("grif", 0); }
        if (!PlayerPrefs.HasKey("ram")) { PlayerPrefs.SetInt("ram", 0); }
        if (PlayerPrefs.HasKey("lan")) { PlayerPrefs.SetInt("lan", 0); }
        if (PlayerPrefs.HasKey("1") == true) { PlayerPrefs.DeleteKey("1"); }



        if (PlayerPrefs.HasKey("Ended?"))
        {
            ended = PlayerPrefs.GetString("Ended?");
            money = PlayerPrefs.GetInt("MR");
        }
        if (ended == "Ended")
        {
            endPanel.SetActive(true);
        }
        else
        {
            endPanel.SetActive(false);
        }
        //if (0 < PlayerPrefs.GetInt("coranswer") && PlayerPrefs.GetInt("coranswer") <= 5) { lastwords = "Для начала сойдет :)"; }
        //if (5 < PlayerPrefs.GetInt("coranswer") && PlayerPrefs.GetInt("coranswer") <= 10) { lastwords = "Не плохой результат, но можно еще  лучше"; }
        //if (10 < PlayerPrefs.GetInt("coranswer") && PlayerPrefs.GetInt("coranswer") <= 15) { lastwords = "Любитиль"; }
        //if (15 < PlayerPrefs.GetInt("coranswer") && PlayerPrefs.GetInt("coranswer") <= 19) { lastwords = "Знаток"; }
        //if (PlayerPrefs.GetInt("coranswer") == 20) { lastwords = "Настояший фанат"; }

        //       Correct_answer_rec[0].text = "Лучший результат: " + PlayerPrefs.GetInt("ram") + " из " + "20 "+"\n  " + lastwords;

        if ((PlayerPrefs.GetInt("M") < 10))
        {
            mon.text = "Читер. Вы где-то не ответили на вопрос";
        }
        else if ((PlayerPrefs.GetInt("M") >= 10) && PlayerPrefs.GetInt("M") <= 16)
        { mon.text = "Вы Кастиэль"; kar.GetComponent<Image>().sprite = images[0]; }
        else if ((PlayerPrefs.GetInt("M") > 16) && PlayerPrefs.GetInt("M") <= 21)
               { mon.text = "Вы Сэм"; kar.GetComponent<Image>().sprite = images[6]; }
        else if ((PlayerPrefs.GetInt("M") > 21) && PlayerPrefs.GetInt("M") <= 25)
        { mon.text = "Вы Бобби"; kar.GetComponent<Image>().sprite = images[2]; }
        else if ((PlayerPrefs.GetInt("M") > 25) && PlayerPrefs.GetInt("M") <= 29)
        { mon.text = "Вы Бог"; kar.GetComponent<Image>().sprite = images[9]; }
        else if ((PlayerPrefs.GetInt("M") > 29) && PlayerPrefs.GetInt("M") <= 31)
        { mon.text = "Вы Чарли"; kar.GetComponent<Image>().sprite = images[4]; }
        else if ((PlayerPrefs.GetInt("M") > 31) && PlayerPrefs.GetInt("M") <= 33)
        { mon.text = "Вы Дин"; kar.GetComponent<Image>().sprite = images[5]; }
        else if ((PlayerPrefs.GetInt("M") > 33) && PlayerPrefs.GetInt("M") <= 35)
        { mon.text = "Вы Ева"; kar.GetComponent<Image>().sprite = images[1]; }
        else if ((PlayerPrefs.GetInt("M") > 35) && PlayerPrefs.GetInt("M") <= 37)
        { mon.text = "Вы Джон"; kar.GetComponent<Image>().sprite = images[7]; }
        else if ((PlayerPrefs.GetInt("M") > 37) && PlayerPrefs.GetInt("M") <= 39)
          { mon.text = "Вы Ровена"; kar.GetComponent<Image>().sprite = images[3]; }
        else if ( PlayerPrefs.GetInt("M") >= 40)
        { mon.text = "Вы Кроули"; kar.GetComponent<Image>().sprite = images[8]; }
    }
    void Start()
    {



    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (exitPanel.activeSelf == false)
            {
                exitPanel.SetActive(true);
                //Static_pan.SetActive(true);
                exitActive = true;
            }
            else
            {
                exitPanel.SetActive(false);
                //Static_pan.SetActive(false);
                exitActive = false;
            }

        }
        if (clickedStart == true)
        {
            PlayerPrefs.DeleteKey("wQ");
            PlayerPrefs.DeleteKey("M");
            PlayerPrefs.DeleteKey("Ended?");
            PlayerPrefs.DeleteKey("i");
            PlayerPrefs.SetInt("1", massnum);

        }

        if (clickedStart && PlayerPrefs.HasKey("Ended?"))
        {
            PlayerPrefs.DeleteKey("wQ");
            PlayerPrefs.DeleteKey("M");
            PlayerPrefs.DeleteKey("Ended?");
            PlayerPrefs.DeleteKey("i");
            PlayerPrefs.SetInt("1", massnum);
        }

    
         menutext[0].text = "Выйти?"; 
        menutext[1].text = "да"; 
menutext[2].text = "Нет"; 
        //if (PlayerPrefs.GetInt("lan") == 1) { menutext[0].text = "Exit ?"; menutext[1].text = "yes"; menutext[2].text = "no"; }
    }
    void FixedUpdate()
    {
        if (fade == true)
        {
            fadeImage.color = Color.Lerp(fadeImage.color, Color.black, fadeTime * Time.deltaTime);
        }
        if (fadeImage.color == Color.black)
        {
            Application.LoadLevel(1);
        }
    }

    public void OnClickStart(int i)
    {
        PlayerPrefs.DeleteKey("wQ");
        PlayerPrefs.DeleteKey("M");
        PlayerPrefs.DeleteKey("Ended?");
        PlayerPrefs.DeleteKey("i");
        PlayerPrefs.DeleteKey("coranswer");
        PlayerPrefs.DeleteAll();      //PlayerPrefs.DeleteAll();
        
        
         PlayerPrefs.SetInt("lan", i); 
      
        fade = true;
        clickedStart = true;
    } 

    public void OnClickExit()
    {
        Application.Quit();

    }
    public void OnClickBack()
    {
        exitPanel.SetActive(false);
        exitActive = false;
    }
    public void OnClickContinue()
    {
        PlayerPrefs.DeleteKey("Ended");
        endPanel.SetActive(false);
    }
   
    public void exitpanactive()
    {
        //if (exitActive == false)
        //{
            exitPanel.SetActive(true);
        //    exitActive = true;
        //}
        //else
        //{
        //    exitPanel.SetActive(false);
        //    exitActive = false;
        //}
    }
}