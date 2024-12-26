using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateButtonsLab4 : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonPrefab;
    [SerializeField]
    private Transform content;
    [SerializeField]
    private ParticleSystem[] particles;

    // Start is called before the first frame update
    void Start()
    {
        foreach(ParticleSystem ps in particles)
        {
            ParticleButton button = Instantiate(buttonPrefab, content).GetComponent<ParticleButton>();
            string name = ps.gameObject.name;
            string buttonName = name.Remove(name.Length-3);
            print(buttonName);
            button.SetText(buttonName);
            Button buttonUI = button.GetComponent<Button>();
            buttonUI.onClick.AddListener(delegate { StopAllAndPlayOne(ps); });
        }
    }

    public void StopAllAndPlayOne(ParticleSystem clickedParticleSystem)
    {
        foreach(ParticleSystem ps in particles)
        {
            if (ps.isPlaying)
            {
                ps.Stop();
                ps.Clear();
                break;
            }
        }
        clickedParticleSystem.Play();
    }
}
