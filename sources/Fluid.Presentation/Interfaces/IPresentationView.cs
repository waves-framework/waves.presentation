namespace Fluid.Presentation.Interfaces
{
    /// <summary>
    ///     Interface for presentation views.
    /// </summary>
    public interface IPresentationView
    {
        /// <summary>
        ///     View model context.
        /// </summary>
        object DataContext { get; set; }
    }
}