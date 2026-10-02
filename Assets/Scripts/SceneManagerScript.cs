using TMPro;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class SceneManagerScript : MonoBehaviour
{

    //public AudioClip _goodHitEffect;
    //public AudioClip _badHitEffect;

    //AudioSource _audioSource;

    int score = 0;

    public GameObject _basicEnemyPrefab;

    public GameObject _bossPrefab;
    public GameObject _starPrefab;

    public TMP_Text scoreText;
    //public TMP_Text timerText;

    private float nextBossSpawnTime;
    public float bossSpawnTime;
    private float nextEnemySpawnTime;
    public float enemySpawnTime;
    public float starSpawnTime; 
    private float nextStarSpawnTime;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextBossSpawnTime = Time.time + bossSpawnTime;
        nextEnemySpawnTime = Time.time + enemySpawnTime;
        for (int i=0; i<100; i++)
        {
            SpawnStar(true);
            SpawnStar();
        }
        nextStarSpawnTime = Time.time + starSpawnTime;
        //_audioSource = GetComponent<AudioSource>();
        //_badHitEffect = GetComponent<AudioSource>();
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        //if (!GameOver())
        //{
            if(Time.time >= nextEnemySpawnTime)
            {
                SpawnEnemy();
                if (Random.value < 0.01)
            {
                SpawnEnemy();
                SpawnEnemy();
            }
                nextEnemySpawnTime = Time.time + enemySpawnTime;
                enemySpawnTime -= 0.02f;
            }
            if (Time.time >= nextBossSpawnTime)
            {
                SpawnBoss();
                nextBossSpawnTime = Time.time + bossSpawnTime;
            }
            if (Time.time >= nextStarSpawnTime)
            {
               for (int i = 0; i < 100; i++)
               {
                  SpawnStar();
               }
            nextStarSpawnTime = Time.time + starSpawnTime;
            }
        //}
        //else
        //{
        //    timerText.text = "GAME OVER!!";
        //}

    }

    //void UpdateScoreText()
    //{
    //    int scoreCount = score;
    //    scoreText.text = scoreCount.ToString();
    //}

    //void UpdateTimerText()
    //{
    //    float time = endTime - Time.time;
    //    timerText.text = time.ToString();
    //}


    //private void SwapTargetColor()
    //{
    //    blackIsGood = !blackIsGood;
    //    scoreText.color = blackIsGood ? Color.black : Color.red;
    //}

    //public void HitPellet(bool wasBlack)
    //{
    //    if (blackIsGood == wasBlack)
    //    {
    //        _audioSource.PlayOneShot(_goodHitEffect);
    //        score++;
    //    }
    //    else
    //    {
    //        _audioSource.PlayOneShot(_badHitEffect);
    //        score = Mathf.Max(0, score - 1);

    //    }

    //    UpdateScoreText();

    //}

    public void HitEnemy()
    {
        //_audioSource.PlayOneShot(_goodHitEffect);
        score += 100;
        scoreText.text = score.ToString();

    }

    //GameObject SpawnPellet()
    //{
    //    float x = Random.Range(-9.0f, 9.0f);
    //    float y = Random.Range(-4.0f, 4.0f);
    //    GameObject newPellet = Instantiate(_pelletPrefab, new Vector3(x, y, 0), Quaternion.identity);

    //    SpriteRenderer sr = newPellet.GetComponent<SpriteRenderer>();
    //    if (sr != null)
    //    {
    //        sr.color = Random.value <= 0.5 ? Color.red : Color.black;

    //    }

    //    PelletScript ps = newPellet.GetComponent<PelletScript>();

    //    if (ps != null)
    //    {
    //        ps.manager = this;
    //    }

    //    return newPellet;

    //}

    GameObject SpawnEnemy()
    {
        float x = Random.Range(-9.0f, 9.0f);
        float y = Random.Range(5.0f, 6.0f);
        GameObject newEnemy = Instantiate(_basicEnemyPrefab, new Vector3(x, y, 0), Quaternion.identity);

        SpriteRenderer sr = newEnemy.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            //sr.color = Random.value <= 0.5 ? Color.red : Color.black;

        }

        BasicEnemyScript es = newEnemy.GetComponent<BasicEnemyScript>();

        if (es != null)
        {
            es.sceneManager = this;
        }

        return newEnemy;

    }

    GameObject SpawnBoss()
    {
        float x = Random.Range(-9.0f, 9.0f);
        float y = Random.Range(5.0f, 5.0f);
        GameObject newBoss = Instantiate(_bossPrefab, new Vector3(x, y, 0), Quaternion.identity);

        SpriteRenderer sr = newBoss.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            //sr.color = Random.value <= 0.5 ? Color.red : Color.black;

        }

        MissileEnemyScript es = newBoss.GetComponent<MissileEnemyScript>();

        if (es != null)
        {
            es.sceneManager = this;
        }

        return newBoss;

    }

    GameObject SpawnStar(bool initial=false)
    {
        float x = Random.Range(-9.0f, 9.0f);
        float y = Random.Range(5.0f, 14.0f);
        if (initial) { //initially appear on screen
            y -= 9.0f;
        }
        GameObject newStar = Instantiate(_starPrefab, new Vector3(x, y, 0), Quaternion.identity);
        return newStar;
    }

    //public bool GameOver()
    //{
    //    return endTime - Time.time <= 0;
    //}


}
