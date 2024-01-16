using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovimentoDoAsset : MonoBehaviour
{
    public float velocidade = 5f;
    public float rotaçãoMouse = 3f; // Ajuste a velocidade de rotação com o mouse
    public float suavidadeDerrapagem = 10f; // Ajuste a suavidade da derrapagem

    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MovimentarAsset();
        RotacionarAssetComMouse();
        VerificarEntradaUsuario();
    }

    private void MovimentarAsset()
    {
        float transH = Input.GetAxis("Vertical");  // Trocado de "Horizontal" para "Vertical"
        float transV = Input.GetAxis("Horizontal");  // Trocado de "Vertical" para "Horizontal"

        // Aplicar suavidade para evitar derrapagem excessiva
        transH = Mathf.Lerp(transH, 0f, Time.deltaTime * suavidadeDerrapagem);
        transV = Mathf.Lerp(transV, 0f, Time.deltaTime * suavidadeDerrapagem);

        Vector3 direcaoDesejada = new Vector3(transH, 0f, transV).normalized;

        // Aplicar movimento usando CharacterController
        Vector3 movimento = direcaoDesejada * velocidade * Time.deltaTime;
        characterController.Move(movimento);
    }

    private void RotacionarAssetComMouse()
    {
        // Rotacionar ao movimentar o mouse para a direita
        if (Input.GetAxis("Mouse X") > 0)
        {
            transform.Rotate(Vector3.up, rotaçãoMouse * Time.deltaTime);
        }
        // Rotacionar ao movimentar o mouse para a esquerda
        else if (Input.GetAxis("Mouse X") < 0)
        {
            transform.Rotate(Vector3.up, -rotaçãoMouse * Time.deltaTime);
        }
    }

    private void VerificarEntradaUsuario()
    {
        // Ocultar ou mostrar o objeto "Fence_Unity" da cena ao pressionar a tecla "Enter" ou "F"
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject fenceUnity = GameObject.Find("Fence_Unity");
            if (fenceUnity != null)
            {
                fenceUnity.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject fenceUnity = GameObject.Find("Fence_Unity");
            if (fenceUnity != null)
            {
                fenceUnity.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar se houve colisão com o objeto específico ("01foxFinal")
        if (other.gameObject.name == "01foxFinal")
        {
            // Ocultar o objeto "Fence_Unity" da cena
            GameObject fenceUnity = GameObject.Find("Fence_Unity");
            if (fenceUnity != null)
            {
                fenceUnity.SetActive(false);
            }
        }
    }
}




