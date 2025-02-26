
public static class InputManager{

    private static CubeInputActions inputActions;
    public static CubeInputActions InputActions => inputActions ??= new();

}