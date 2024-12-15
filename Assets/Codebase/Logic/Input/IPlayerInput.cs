namespace Codebase.Logic.Input
{
    public interface IPlayerInput
    {
        float? MovementDirection { get; }
        
        bool IsSingleShot { get; }
        bool IsBursting { get; }
    }
}