using UnityEngine;

public class FinDeAnimacion : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Llamar a un script externo para iniciar movimiento
        animator.gameObject.GetComponent<RotateandGetCloser>()?.StartMovement();
    }
}
