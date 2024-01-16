using UnityEngine;

public class MovimentoDoAsset : MonoBehaviour
{
    public float velocidade = 5f;
    public float rotacaoAngulo = 90f;
    public float estabilizarAngulo = 0f;
    public float rotacaoMouse = 1f; // Ângulo de rotação ao arrastar o mouse

    private void Update()
    {
        MovimentarAsset();
        RotacionarAssetComMouse();
        EstabilizarAsset();
        VerificarEntradaUsuario();
    }

    private void MovimentarAsset()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(movimentoHorizontal, 0f, movimentoVertical) * velocidade * Time.deltaTime;

        // Manter a posição Y constante para garantir estabilidade
        movimento.y = 0f;

        transform.Translate(movimento);

        // Rotacionar 90 graus ao pressionar WASD
        if (movimento != Vector3.zero)
        {
            float targetAngle = Mathf.Atan2(movimento.x, movimento.z) * Mathf.Rad2Deg;
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, rotacaoAngulo * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, angle, 0);
        }
    }

    private void RotacionarAssetComMouse()
    {
        // Rotacionar 90 graus ao clicar com o botão direito do mouse
        if (Input.GetMouseButtonDown(1))
        {
            transform.Rotate(Vector3.up, 90f);
        }

        // Rotacionar ao arrastar o mouse para o lado direito
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * rotacaoMouse;
            transform.Rotate(Vector3.up, mouseX);
        }
    }

    private void EstabilizarAsset()
    {
        // Estabilizar no eixo Z ao clicar com o botão esquerdo
        if (Input.GetMouseButtonDown(0))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, estabilizarAngulo);
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









