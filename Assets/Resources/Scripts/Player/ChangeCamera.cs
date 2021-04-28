using Cinemachine;
using System.Collections;
using UnityEngine;

public class ChangeCamera : SingletonMonobehaviour<ChangeCamera>
{
    public GameObject cinemachineCamera;
    public GameObject head;
    public GameObject mainCamera;

    public CinemachineVirtualCamera pov;
    public CinemachineVirtualCamera puzzle1;
    public CinemachineVirtualCamera puzzle2;
    public CinemachineVirtualCamera puzzle3;

    private void Start()
    {
        cinemachineCamera.SetActive(false);
    }

    public void StartReturnPOV()
    {
        StartCoroutine(ReturnPOV());
    }

    public void StartPuzzle1()
    {
        StartCoroutine(Puzzle1());
    }

    public void StartPuzzle2()
    {
        StartCoroutine(Puzzle2());
    }

    public void StartPuzzle3()
    {
        StartCoroutine(Puzzle3());
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(ReturnPOV());
        }
    }
    public IEnumerator ReturnPOV()
    {
        pov.m_Priority = 10;
        puzzle1.m_Priority = 0;
        puzzle2.m_Priority = 0;
        puzzle3.m_Priority = 0;
        yield return new WaitForSeconds(1);      
        head.transform.parent = mainCamera.transform;
        mainCamera.SetActive(true);
        cinemachineCamera.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public IEnumerator Puzzle1()
    {
        head.transform.parent = null;
        mainCamera.SetActive(false);
        cinemachineCamera.SetActive(true);
        pov.m_Priority = 10;
        yield return new WaitForSeconds(0.1f);
        pov.m_Priority = 0;
        puzzle1.m_Priority = 10;
        Cursor.lockState = CursorLockMode.None;
    }

    public IEnumerator Puzzle2()
    {
        head.transform.parent = null;
        mainCamera.SetActive(false);
        cinemachineCamera.SetActive(true);
        pov.m_Priority = 10;
        yield return new WaitForSeconds(0.1f);
        pov.m_Priority = 0;
        puzzle2.m_Priority = 10;
        Cursor.lockState = CursorLockMode.None;
    }

    public IEnumerator Puzzle3()
    {
        head.transform.parent = null;
        mainCamera.SetActive(false);
        cinemachineCamera.SetActive(true);
        pov.m_Priority = 10;
        yield return new WaitForSeconds(0.1f);
        pov.m_Priority = 0;
        puzzle3.m_Priority = 10;
        Cursor.lockState = CursorLockMode.None;
    }


}

