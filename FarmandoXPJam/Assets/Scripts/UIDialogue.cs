using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDialogue : MonoBehaviour
{
    public Rect dialogBoxRect = new Rect(20, 20, 400, 200);
    //                Posição Inicial na tela: (20, 20) com o tamanho de 400x200 pixels

    private string currentDialog;
    private bool isDialogActive = false;

    private void OnGUI() // condição para exibir a janela do dialogo
    {
        if (isDialogActive)
        {
            dialogBoxRect = GUI.Window(0, dialogBoxRect, DialogWindow, "Diálogo");
        }
    }

    private void DialogWindow(int windowID)
    {
        GUILayout.Label(currentDialog);

        if (GUILayout.Button("Proximo"))
        {
            currentDialog = GetNextDialog();
        }
    }

    public void StartDialog(string dialog)
    {
        currentDialog = dialog;
        isDialogActive = true;
    }

    private string GetNextDialog()
    {
        string nextDialog = "";

        // logica para obter a proxima pergunta

        return nextDialog; // retorna a próxima frase ou pergunta do diálogo
    }

}
