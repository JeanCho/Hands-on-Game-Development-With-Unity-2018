
using UnityEngine;

namespace MyCompany.GameFramework.InputManagement.Interfaces
{
    public interface ImouseInputHandler 
    {
        Vector2 GetRawPosition();
        Vector2 GetInput();
    }
}

