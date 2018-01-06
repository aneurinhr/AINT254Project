using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {

    [SerializeField]
    private GameObject m_player;
    [SerializeField]
    private GameObject m_Win;
    [SerializeField]
    private GameObject m_Lose;

    private int m_NumFin = 0;
    private bool m_possible = false;
    private bool m_Completed = false;

    public int maxDecals = 100;
    public int currentDecal = 0;
    public int numFriend = 0;

    public GameObject Timer;
    public GameObject Score;

    public AudioClip winSound;
    public AudioClip loseSound;

    private int m_numFriendStart;

    private void Start()
    {
        m_numFriendStart = numFriend;
    }

    public void ResetFinish()
    {
        numFriend = m_numFriendStart;
        m_Completed = false;
        m_possible = false;
        m_NumFin = 0;
        Score.SetActive(false);
        m_Win.SetActive(false);
        m_Lose.SetActive(false);
        currentDecal = 0;
        m_player.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Friendly")
        {
            other.GetComponent<FriendMovement>().finished = true;
            other.transform.position = transform.position;

            GameObject[] _friends = GameObject.FindGameObjectsWithTag("Friendly");
            int _NumFriend = _friends.Length;
            for (int i = 0; i < _NumFriend; i++)
            {
                _friends[i].GetComponent<FriendMovement>().FriendFinished();
            }

            m_NumFin++;
        }
        else if (other.gameObject.tag == "Ink")
        {
            m_possible = true;
        }

    }//End Trigger

    private void Update()
    {
        if (m_Completed == false) {
            if ((m_NumFin == numFriend) && (numFriend > 0))
            {
                m_player.SetActive(false);
                m_Win.SetActive(true);
                m_Completed = true;
                gameObject.GetComponent<AudioSource>().PlayOneShot(winSound);
                Timer.GetComponent<Timer>().finished = true;
                Score.SetActive(true);
                ScoreFriends();
            }
            else if (((currentDecal >= maxDecals) && (m_possible == false)) || (numFriend <= 0))
            {
                GameOver();
            }
        }
    }

    private void ScoreFriends()
    {
        Score.GetComponent<Score>().friendsLeft = numFriend;
        Score.GetComponent<Score>().timeLeft = Timer.GetComponent<Timer>().timer;
        Score.GetComponent<Score>().CalcScore = false;
    }

    public void GameOver()
    {
        if (m_Completed == false)
        {
            m_player.SetActive(false);
            m_Lose.SetActive(true);
            m_Completed = true;
            gameObject.GetComponent<AudioSource>().PlayOneShot(loseSound);
            Timer.GetComponent<Timer>().finished = true;

            Score.SetActive(true);
            Score.GetComponent<Score>().CalcScore = false;
        }
    }

}
