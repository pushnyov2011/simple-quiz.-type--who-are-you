
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using GoogleMobileAds.Api;




public class GameScript : MonoBehaviour
{
    int x = 0;
    private InterstitialAd ad;
    public Text timeText;
    public Text quastion;
    public Text[] answers;
    public Text[] Stats;

    public Button[] Bttns;
    public Sprite trueAnswer;
    public Sprite falseAnswer;
    public Sprite clickedAnswerS;
    public Image fadeImage;
    public Image[] bttnsImages;
    public Animator statsAnimation;
    public GameObject pausePanel;
    public int wQ;
    private int clickedAnswer = -1;
    private int money = 0;
    private int trueint = -1;
    private int debugTggl = 0;
    private int timeEq = 10;
    private float fadeTime = 4.5f;
    private float timeF = 0;
    private bool getMoney = false;
    private bool lose = false;
    private bool goFadeIn = false;
    private bool goFadeOut = false;

    private bool ended = false;
    private bool pauseActive = false;
    private bool isLoaded = false;
    private bool trueA = false;
    private bool falseA = false;

    public Sprite[] kartinka;
    public Image main_imag;
    public int massnum;
    private const string gameover = "";
    private const string banner = "";
    public GameObject starspanel;
    string adUnitId  = "";
    private BannerView bannerView;
    string adUnitId2 = "";
    private BannerView bannerView2;
    //string adUnitId3 = "ca-app-pub-9974352663449666/9433051329";
    //private BannerView bannerView3;
    //string adUnitId4 = "ca-app-pub-9974352663449666/7928397965";
    //private BannerView bannerView4;
   
   
    public Text[] pausetext;
    public bool getsocre = false;

    public int i;

    void Start()
    {
        string appId = "";
        MobileAds.Initialize(appId);

        this.RequestBanner();
        //this.RequestBanner2();
        //this.RequestBanner3();
        //this.RequestBanner4();
    }
    void Awake()
    {
       
        //if (PlayerPrefs.GetInt("lan") == 0) { 
        pausetext[0].text = "Пауза"; pausetext[1].text = "Меню"; pausetext[2].text = "Выйти";
        //if (PlayerPrefs.GetInt("lan") == 1) { pausetext[0].text = "Pause"; pausetext[1].text = "Menu"; pausetext[2].text = "Exit"; }
        //BannerView bannerv = new BannerView(banner,AdSize.Banner, AdPosition.Bottom);
        //AdRequest request = new AdRequest.Builder().Build();
        //ad.LoadAd(request);
        //ad.OnAdLoaded += onAdLoad;
        fadeImage.enabled = true;
        goFadeOut = true;
        //massnum = PlayerPrefs.GetInt("1");

        if (PlayerPrefs.HasKey("wQ"))
        {
            //massnum = PlayerPrefs.GetInt("Mas");
           // money = PlayerPrefs.GetInt("M");
            wQ = PlayerPrefs.GetInt("wQ");
            i = PlayerPrefs.GetInt("i");
           // wQ = i;
        }
        
        else
        {
            
            PlayerPrefs.SetInt("wQ", 1);
          //  PlayerPrefs.SetInt("M", 0);
            PlayerPrefs.SetInt("i", 1);
            //wQ = i;




        }

    }
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseActive == false)
            {
                pausePanel.SetActive(true);
                pauseActive = true;
            }
            else
            {
                pausePanel.SetActive(false);
                pauseActive = false;
            }
        }
       

        timeText.text = timeEq.ToString();
        timeF += Time.deltaTime;
        if (timeF >= 1.2)
        {
            if (clickedAnswer == -1)
            {
                if (pauseActive == false)
                {
                    timeEq--;
                    timeF = 0;
                }
            }

            if (timeEq <= 0)
            {
                timeText.text = "Время истекло";

                //if (PlayerPrefs.GetInt("lan") == 0) { timeText.text = "Время истекло"; };
                //if (PlayerPrefs.GetInt("lan") == 1) { timeText.text = "Time out"; };
                overTime();
            }
            if (timeEq <= 2)
            {
                timeText.color = Color.red;
            }
            if (wQ == 1)
            {
                RQ1();
            }
            else if (wQ == 2)
            {
                RQ2();
            }
            else if (wQ == 3)
            {
                RQ3();
            }
            else if (wQ == 4)
            {
                RQ4();
            }
            else if (wQ == 5)
            {
                RQ5();
            }
            else if (wQ == 6)
            {
                RQ6();
            }
            else if (wQ == 7)
            {
                RQ7();
            }
            else if (wQ == 8)
            {
                RQ8();
            }
            else if (wQ == 9)
            {
                RQ9();
            }
            else if (wQ == 10)
            {
                RQ10();
            }
         
        }
    }
    //public void mas( )
    //{
    //    for (int w = 0; w < 25; w++)
    //    {
    //        int a = Random.Range(2, 26);
    //        if (!quest.Contains(a))
    //        {
    //            quest[w] = a;
    //        }

    //        else
    //            w--;
    //    }




    void FixedUpdate()
    {
        if (goFadeIn == true)
        {
            fadeImage.color = Color.Lerp(fadeImage.color, Color.black, fadeTime * Time.deltaTime);
        }
        else if (goFadeOut == true)
        {
            fadeImage.color = Color.Lerp(fadeImage.color, Color.clear, fadeTime * Time.deltaTime);
        }
        if (fadeImage.color == Color.black)
        {
            if (isLoaded == false)
            {
                continueLoad();
            }
        }

    }

    private void RQ1()
    {
        //trueint = 1;
        quastion.text = "Чего ты боишься больше всего на свете?" ;
        answers[0].text = "летать на самолете";
        answers[1].text = "потерять дорого сердцу человека";
        answers[2].text = "клоунов";
        answers[3].text = "мать";
      

        if (clickedAnswer == 0 || clickedAnswer == 1 || clickedAnswer == 2 || clickedAnswer == 3)
        {

            StartCoroutine(waitForMagic());

        }
    }
    private void RQ2()
    {
        quastion.text = "твой выбор оружия";
        answers[0].text = "пистолет";
        answers[1].text = "нож";
        answers[2].text = "сила слова";
        answers[3].text = "гугл";

        //trueint = 1;
        if (clickedAnswer == 0 || clickedAnswer == 1 || clickedAnswer == 2 || clickedAnswer == 3)
        {

            StartCoroutine(waitForMagic());

        }
    }
    private void RQ3()
    {
        quastion.text = "Твой любимый сериад";
        answers[0].text = "Доктор кто";
        answers[1].text = "санта-барбара";
        answers[2].text = "скорая помощь";
        answers[3].text = "секретные материалы";

        //trueint = 1;
        if (clickedAnswer == 0 || clickedAnswer == 1 || clickedAnswer == 2 || clickedAnswer == 3)
        {

            StartCoroutine(waitForMagic());

        }
    }
    private void RQ4()
    {
        quastion.text = "где бы ты хотел жить?";
        answers[0].text = "В простой хижине в лесу";
        answers[1].text = "В кравсивом доме с газоном";
        answers[2].text = "на острове";
        answers[3].text = "неважно, я часто переезжаю";

        //trueint = 1;
        if (clickedAnswer == 0 || clickedAnswer == 1 || clickedAnswer == 2 || clickedAnswer == 3)
        {

            StartCoroutine(waitForMagic());

        }
    }
    private void RQ5()
    {
        quastion.text = "Незнакомец просит вас о помощи, твоя реакция?";
        answers[0].text = "Ты бросаешься на помощь";
        answers[1].text = "ты слабо веришь в рассказ незнакомца";
        answers[2].text = "Сначало внимательно выслушаешь";
        answers[3].text = "купишь его душу";

        //trueint = 1;
        if (clickedAnswer == 0 || clickedAnswer == 1 || clickedAnswer == 2 || clickedAnswer == 3)
        {

            StartCoroutine(waitForMagic());

        }
    }
    private void RQ6() // Смотрите на вопрос 1.
    {
       
            quastion.text = "Какие бы силы ты хотел себе?";
            answers[0].text = "Летать";
            answers[1].text = "Воскрешать из мертвых";
            answers[2].text = "путешествовать во времени";
            answers[3].text = "телекинез";

        //trueint = 1;
        if (clickedAnswer == 0 || clickedAnswer == 1 || clickedAnswer == 2 || clickedAnswer == 3)
        {

            StartCoroutine(waitForMagic());

        }
    }
    private void RQ7()
    {
            quastion.text = "твой любимый цвет?";
            answers[0].text = "белый";
            answers[1].text = "черный";
            answers[2].text = "синий";
            answers[3].text = "красный";

        //trueint = 1;
        if (clickedAnswer == 0 || clickedAnswer == 1 || clickedAnswer == 2 || clickedAnswer == 3)
        {

            StartCoroutine(waitForMagic());

        }
    }
    private void RQ8()
    {
        //if (PlayerPrefs.GetInt("lan") == 0)
        //{
        //    quastion.text = "Мое первое железное правило: надеясь на лучшее, планируй худшее.";
        //    answers[0].text = "Джейсон Борн";
        //    answers[1].text = "Ультиматум Борна ";
        //    answers[2].text = "Идентификация Борна";
        //    answers[3].text = "Превосходство Борна";

        //}


        //if (PlayerPrefs.GetInt("lan") == 1)
        //{
        //    quastion.text = "Ладненько. Я умею убивать оборотней, чинить старые авто и печь пирожки. Будь я проклят, если не смогу словить дзэн";
        //    answers[0].text = "Адвокат";
        //    answers[1].text = "Сверхъестественное";
        //    answers[2].text = "Дневники Вампира";
        //    answers[3].text = "Я - Зомби";
        //}
        //if (PlayerPrefs.GetInt("lan") == 2) //  рик и морти
        //{
        //quastion.text = "Как звали школьного хулигана, который угрожал Морти?";
        quastion.text = "Ты добро или зло?";
        answers[0].text = "я белый и пушистый";
        answers[1].text = "Чистый ангел";
        answers[3].text = "Трудно ответь";
        answers[2].text = "Чистое зло";

        //trueint = 1;
       

        if (clickedAnswer == 0 || clickedAnswer == 1 || clickedAnswer == 2 || clickedAnswer == 3)
        {

            StartCoroutine(waitForMagic());

        }
    }
    private void RQ9()
    {
        quastion.text = "Как ты появился на свет";
        answers[0].text = "Родился, как все нормальные люди";
        answers[1].text = "У меня очень сложная биография";
        answers[2].text = "Меня создал Господь Бог";
        answers[3].text = "Лучше вам не знать";

        //trueint = 1;
        if (clickedAnswer == 0 || clickedAnswer == 1 || clickedAnswer == 2 || clickedAnswer == 3)
        {

            StartCoroutine(waitForMagic());

        }
    }
    private void RQ10()
    {
        quastion.text = "Выбери фразу, описывающую тебя";
        answers[0].text = "У меня много масок";
        answers[1].text = "О спорт - ты мир";
        answers[2].text = "Малыш с крылышками";
        answers[3].text = "сколько душ я загубил";

        //trueint = 1;
     
        if (clickedAnswer == 0 || clickedAnswer == 1 || clickedAnswer == 2 || clickedAnswer == 3)
        {
            
            StartCoroutine(waitForMagic());
            
        }
        ended = true;
    }

    


    IEnumerator waitForMagic()
    {
        Bttns[0].interactable = false;
        Bttns[1].interactable = false;
        Bttns[2].interactable = false;
        Bttns[3].interactable = false;
        trueA = true;
        bttnsImages[clickedAnswer].sprite = clickedAnswerS;
        yield return new WaitForSeconds(0.1f);
        bttnsImages[clickedAnswer].overrideSprite = trueAnswer;
        yield return new WaitForSeconds(0.2f); //
        StatsWindow();
        starspanel.SetActive(true);
        StopCoroutine(waitForMagic());
    }
    IEnumerator waitForDestroy() // Корутина проигрыша.
    {

        Bttns[0].interactable = false;
        Bttns[1].interactable = false;
        Bttns[2].interactable = false;
        Bttns[3].interactable = false;
        bttnsImages[clickedAnswer].sprite = clickedAnswerS;
        falseA = true;
        yield return new WaitForSeconds(0.5f);
        bttnsImages[clickedAnswer].overrideSprite = falseAnswer;
        bttnsImages[trueint].sprite = trueAnswer;

        yield return new WaitForSeconds(0.5f);
        StatsWindow();


        starspanel.SetActive(true);
        StopCoroutine(waitForDestroy());

    }


    private void overTime()
    {
        Bttns[0].interactable = false;
        Bttns[1].interactable = false;
        Bttns[2].interactable = false;
        Bttns[3].interactable = false;
        starspanel.SetActive(true);
        StatsWindow();
    }
    private void StatsWindow()
    {
        if (trueA == true)
        {
            if (getMoney == false)
            {
                PlayerPrefs.SetInt("MR", money);
           //     PlayerPrefs.SetInt("M", money);
                PlayerPrefs.Save();
            }
            lose = false;
            
                Stats[0].text = "Круто!";
                Stats[1].text = "вопрос " + wQ + " из 10";
               // Stats[2].text = "Очки: " + money.ToString();
            
            //if (PlayerPrefs.GetInt("lan") == 1)
            //{
            //    Stats[0].text = "Correct answer ";

            //    Stats[1].text = "question " + (i + 1) + " of 20";
            //    Stats[2].text = "Points:" + money.ToString();
            //}
        }
        else if (falseA == true)
        {
            
            lose = false;
            //if (PlayerPrefs.GetInt("lan") == 0)
            
                Stats[0].text = "Неправильный ответ";
                Stats[1].text = "вопрос " + (i + 1) + " из 20";
                Stats[2].text = "Очки: " + money.ToString();
            
            //if (PlayerPrefs.GetInt("lan") == 1)
            //{
            //    Stats[0].text = "Incorrect answer";
            //    Stats[1].text = "question " + (i + 1) + " of 20";
            //    Stats[2].text = "Score:" + money.ToString();
            //}
            PlayerPrefs.SetInt("MR", money);
         //   PlayerPrefs.SetInt("M", money);
            PlayerPrefs.Save();
        }
        else if (trueA == false && falseA == false)
        {

            lose = true;
            //if (PlayerPrefs.GetInt("lan") == 0)
            //{
                Stats[1].text = "Не спи :)";
               // Stats[1].enabled = false;
             //  Stats[1].text = "вопрос " + (i + 1) + " из 20";
              //  Stats[2].text = " Очки : " + money.ToString();
            
            //if (PlayerPrefs.GetInt("lan") == 1)
            //{
            //    Stats[0].text = "Time out";
            //   // Stats[1].enabled = false;
            //    Stats[1].text = "question " + (i + 1) + " of 20";
            //    Stats[2].text = " Score: " + money.ToString();
            //}
            Stats[4].enabled = true;
            PlayerPrefs.SetInt("MR", money);
          //  PlayerPrefs.SetInt("M", money);
            PlayerPrefs.Save();
        }
        statsAnimation.SetTrigger("Do");
    }
    private void RequestBanner()
    {
        //#if UNITY_ANDROID

        //#elif UNITY_IPHONE
        //            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
        //#else
        //            string adUnitId = "unexpected_platform";
        //#endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);
        bannerView.Show();

    }

    private void RequestBanner2()
    {
        //#if UNITY_ANDROID

        //#elif UNITY_IPHONE
        //            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
        //#else
        //            string adUnitId = "unexpected_platform";
        //#endif

        // Create a 320x50 banner at the top of the screen.
        bannerView2 = new BannerView(adUnitId2, AdSize.Banner, AdPosition.Top);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView2.LoadAd(request);
        bannerView2.Show();

    }

    //private void RequestBanner3()
    //{
    //    //#if UNITY_ANDROID

    //    //#elif UNITY_IPHONE
    //    //            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
    //    //#else
    //    //            string adUnitId = "unexpected_platform";
    //    //#endif

    //    // Create a 320x50 banner at the top of the screen.
    //    bannerView3 = new BannerView(adUnitId3, AdSize.Banner, AdPosition.Top);
    //    // Create an empty ad request.
    //    AdRequest request = new AdRequest.Builder().Build();

    //    // Load the banner with the request.
    //    bannerView3.LoadAd(request);
    //    bannerView3.Show();

    //}

    //private void RequestBanner4()
    //{
    //    //#if UNITY_ANDROID

    //    //#elif UNITY_IPHONE
    //    //            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
    //    //#else
    //    //            string adUnitId = "unexpected_platform";
    //    //#endif

    //    // Create a 320x50 banner at the top of the screen.
    //    bannerView4 = new BannerView(adUnitId4, AdSize.Banner, AdPosition.Bottom);
    //    // Create an empty ad request.
    //    AdRequest request = new AdRequest.Builder().Build();

    //    // Load the banner with the request.
    //    bannerView4.LoadAd(request);
    //    bannerView4.Show();

    //}

    public void ContinueBttn()
    {
        if (lose == false)
        {
            goFadeOut = false;
            goFadeIn = true;
        }
        //if (ended == true)
        //{
        //    //goFadeIn = true;
        //    //PlayerPrefs.DeleteKey("1");
        //    //PlayerPrefs.Save();
        //    ad = new InterstitialAd(gameover);
        //    AdRequest request = new AdRequest.Builder().Build();
        //    ad.LoadAd(request);
        //    ad.OnAdLoaded += onAdLoad;
        //    Application.LoadLevel(0);
        //    PlayerPrefs.SetString("Ended?", "Ended");

        //    PlayerPrefs.Save();
        //}
        //else
        else
       {
           SceneManager.LoadScene(0);
        //    Application.LoadLevel(0);
            ad = new InterstitialAd(gameover);
            AdRequest request = new AdRequest.Builder().Build();
            ad.LoadAd(request);
            ad.OnAdLoaded += onAdLoad;
          
         
        }
    }
    //    {

    //        goFadeIn = true;
    // 
           
    //    }
    //}
    private void continueLoad()
    {
        if (getsocre == false)
        {
            if (clickedAnswer == 0)
            {
                PlayerPrefs.SetInt("M", PlayerPrefs.GetInt("M") + 1);

            }

            if (clickedAnswer == 1)
            {
                PlayerPrefs.SetInt("M", PlayerPrefs.GetInt("M") + 2);

            }
            if (clickedAnswer == 2)
            {
                PlayerPrefs.SetInt("M", PlayerPrefs.GetInt("M") + 3);

            }
            if (clickedAnswer == 3)
            {
                PlayerPrefs.SetInt("M", PlayerPrefs.GetInt("M") + 4);

            }
            getsocre = true;
        }
        if (ended == true)
        {
    
            //PlayerPrefs.DeleteKey("1");
            //PlayerPrefs.Save();
            ad = new InterstitialAd(gameover);
            AdRequest request = new AdRequest.Builder().Build();
            ad.LoadAd(request);
            ad.OnAdLoaded += onAdLoad;
            Application.LoadLevel(0);
            PlayerPrefs.SetString("Ended?", "Ended");

            PlayerPrefs.Save();
        }
        else
        {
            
         
            //}
            i++;
 

            if ( wQ == 2 || wQ == 5|| wQ  == 7 || wQ  == 10)
            {
                ad = new InterstitialAd(banner);
                AdRequest request = new AdRequest.Builder().Build();
                ad.LoadAd(request);
                ad.OnAdLoaded += onAdLoad;
            }
            isLoaded = true;
            wQ++;
         
            PlayerPrefs.SetInt("wQ", wQ);
            PlayerPrefs.SetInt("i", i);
            PlayerPrefs.Save();
            SceneManager.LoadScene(1);
        }
    }

    public void selectedBttn(int clickBttn)
    {
        clickedAnswer = clickBttn;
    }
    public void OnClickMenu()
    {
        SceneManager.LoadScene(0);
        //Application.LoadLevel(0);
        //isLoaded = true;
        ad = new InterstitialAd(gameover);
        AdRequest request = new AdRequest.Builder().Build();
        ad.LoadAd(request);
        ad.OnAdLoaded += onAdLoad;
        //PlayerPrefs.DeleteAll();
        ////PlayerPrefs.DeleteKey("1");
        //PlayerPrefs.Save();
        //Application.LoadLevel(0);
        
        //bannerView.Hide();
        //bannerView2.Hide();
        

    }
    public void OnClickExit()
    {

        //PlayerPrefs.DeleteAll();
        ////PlayerPrefs.DeleteKey("1");
        //PlayerPrefs.Save();
        Application.Quit();
    }
    public void onAdLoad(object sender, System.EventArgs args)
    {
        ad.Show();

    }

}