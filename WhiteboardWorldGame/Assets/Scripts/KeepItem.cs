using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeepItem : MonoBehaviour {

    private string m_StartMenu = "StartMenu";
    private string m_Start = "StartUI";
    private string m_Level = "LevelUI";
    private bool m_visited = false;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

	private void Update () {

        if ((SceneManager.GetActiveScene().name != m_StartMenu) && (m_visited == false))
        {
            m_visited = true;
        }

        if ((SceneManager.GetActiveScene().name == m_StartMenu) && (m_visited == true))
        {
            m_visited = false;

            GameObject[] _items = GameObject.FindGameObjectsWithTag(gameObject.tag);

            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i] != gameObject)
                {
                    Destroy(_items[i]);
                }
            }

            GameObject.FindGameObjectWithTag(m_Start).SetActive(false);

            int _Child = GameObject.FindGameObjectWithTag(m_Level).transform.childCount;

            for (int i = 0; i < _Child; i++)
            {
                GameObject.FindGameObjectWithTag(m_Level).transform.GetChild(i).gameObject.SetActive(true);
            }
        }

    }

}
