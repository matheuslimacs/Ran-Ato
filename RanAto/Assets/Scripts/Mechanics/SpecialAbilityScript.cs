using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpecialAbilityScript : MonoBehaviour {

    public GameObject shurikenPrefab;
    public GameObject shurikenSpawnLocation;

    private MovePlayer player;
    private TutorialManager tutorialScript;

    private AudioSource abilityAudioSource;

    public AudioClip meleeKatana;
    public AudioClip shuriken;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<MovePlayer>();
        tutorialScript = GameObject.Find("TutorialTrigger02").GetComponent<TutorialManager>();
        abilityAudioSource = GetComponent<AudioSource>();
    }

    public void Habilidade()
    {
        if (!TutorialManager.fezTutorialAtaque)
        {
            TutorialManager.fezTutorialAtaque = true;
            GameManager.bPause = false;
            tutorialScript.FezTutorial();
        }

        if (TutorialManager.tutorialAtaqueExibido)
        {
            switch (GameManager.character)
            {
                case 1:
                    break;
                case 2:
                    if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                    {
                        abilityAudioSource.clip = meleeKatana;

                        if (ColetaDeItens.hasUltimate)
                        {
                            StartCoroutine(Katanada());
                            ColetaDeItens.hasUltimate = false;
                        }
                    }
                    else
                    {
                        player.Jump();
                    }

                    break;
                case 3:
                    if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                    {
                        if (ColetaDeItens.hasUltimate)
                        {
                            Instantiate(shurikenPrefab, shurikenSpawnLocation.transform.position, shurikenSpawnLocation.transform.rotation);
                            ColetaDeItens.hasUltimate = false;
                        }
                    }
                    else
                    {
                        player.Jump();
                    }

                    break;
            }
        }        
    }

    public IEnumerator Katanada()
    {
        player.GetComponent<Animator>().SetBool("Ultimate", true);
        abilityAudioSource.Play();
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<Animator>().SetBool("Ultimate", false);
    }
}
