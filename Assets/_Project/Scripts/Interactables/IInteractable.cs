namespace AE
{
    public interface IInteractable
    {
        string Label { get; }
        void Interact();
        void ShowLabel();
        void HideLabel();
    }
}
