namespace AE
{
    public interface IInteractable
    {
        string Label { get; }
        void Interact(Player player);
        void ShowLabel();
        void HideLabel();
    }
}
