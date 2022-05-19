using UnityEngine;
using System.Collections;
using TMPro;

public class TextTypewriter : MonoBehaviour
{
    private TMP_Text m_TextComponent;
    private bool hasTextChanged;
    public int visibleCount = 0;
    public bool Loop = true;
    public float PauseLetter = 0.05f;
    public float PauseLoop = 3;

    void Awake()
        {
            m_TextComponent = gameObject.GetComponent<TMP_Text>();
        }


        void Start()
        {
            StartCoroutine(RevealCharacters(m_TextComponent));
            //StartCoroutine(RevealWords(m_TextComponent));
        }


        void OnEnable()
        {
            // Subscribe to event fired when text object has been regenerated.
            TMPro_EventManager.TEXT_CHANGED_EVENT.Add(ON_TEXT_CHANGED);
        visibleCount = 0;
    }

        void OnDisable()
        {
            TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(ON_TEXT_CHANGED);
        visibleCount = 0;
    }


        // Event received when the text object has changed.
        void ON_TEXT_CHANGED(Object obj)
        {
            hasTextChanged = true;
        }


        /// <summary>
        /// Method revealing the text one character at a time.
        /// </summary>
        /// <returns></returns>
        IEnumerator RevealCharacters(TMP_Text textComponent)
        {
            textComponent.ForceMeshUpdate();

            TMP_TextInfo textInfo = textComponent.textInfo;

            int totalVisibleCharacters = textInfo.characterCount; // Get # of Visible Character in text object
            

            while (true)
            {
                if (hasTextChanged)
                {
                    totalVisibleCharacters = textInfo.characterCount; // Update visible character count.
                    hasTextChanged = false; 
                }

                if (visibleCount > totalVisibleCharacters)
                {
                if (!Loop) {

                }
                else
                {
                    yield return new WaitForSeconds(PauseLoop);
                    visibleCount = 0;
                }
                }

                textComponent.maxVisibleCharacters = visibleCount; // How many characters should TextMeshPro display?
            yield return new WaitForSeconds(PauseLetter);
            visibleCount += 1;

                yield return null;
            }
        }

    }