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

    //public TMP_Text scoreText;
    //public TMP_Text timerText;

    float endTime;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //endTime = Time.time + 30.0f;
        //_audioSource = GetComponent<AudioSource>();
        //_badHitEffect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!GameOver())
        //{
            //UpdateTimerText();
            if (Random.value <= 0.002)
            {
                SpawnEnemy();
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
        score++;

        //UpdateScoreText();

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
        float y = Random.Range(3.0f, 4.0f);
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

    //public bool GameOver()
    //{
    //    return endTime - Time.time <= 0;
    //}


}
