using UnityEngine;
using UnityEngine.UI;

public class TrocaDeImagens : MonoBehaviour
{
    public Image dogLv01Image;
    public Image dogLv02Image;
    public Image dogLv03Image;
    public Image foxLv01Image;
    public Image foxLv02Image;
    public Image foxLv03Image;

    private enum State
    {
        DogLv01,
        DogLv02,
        DogLv03,
        FoxLv01,
        FoxLv02,
        FoxLv03
    }

    private State currentState = State.DogLv01;

    private void Update()
    {
        VerificarEntradaUsuario();
    }

    private void VerificarEntradaUsuario()
    {
        // Trocar imagens ao pressionar a tecla "J"
        if (Input.GetKeyDown(KeyCode.J))
        {
            TrocarImagemDog();
            TrocarImagemFox();
        }

        // Trocar imagens ao pressionar a tecla "G"
        if (Input.GetKeyDown(KeyCode.G))
        {
            TrocarImagemFox();
            TrocarImagemDog();
        }
    }

    private void TrocarImagemDog()
    {
        currentState = (State)(((int)currentState + 1) % 3); // DogLv01, DogLv02, DogLv03

        switch (currentState)
        {
            case State.DogLv01:
                dogLv01Image.enabled = true;
                dogLv02Image.enabled = false;
                dogLv03Image.enabled = false;
                break;

            case State.DogLv02:
                dogLv01Image.enabled = false;
                dogLv02Image.enabled = true;
                dogLv03Image.enabled = false;
                break;

            case State.DogLv03:
                dogLv01Image.enabled = false;
                dogLv02Image.enabled = false;
                dogLv03Image.enabled = true;
                break;
        }
    }

    private void TrocarImagemFox()
    {
        currentState = (State)(((int)currentState + 3) % 6); // FoxLv01, FoxLv02, FoxLv03

        switch (currentState)
        {
            case State.FoxLv01:
                foxLv01Image.enabled = true;
                foxLv02Image.enabled = false;
                foxLv03Image.enabled = false;
                break;

            case State.FoxLv02:
                foxLv01Image.enabled = false;
                foxLv02Image.enabled = true;
                foxLv03Image.enabled = false;
                break;

            case State.FoxLv03:
                foxLv01Image.enabled = false;
                foxLv02Image.enabled = false;
                foxLv03Image.enabled = true;
                break;
        }
    }
}

