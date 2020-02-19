namespace Fluid.Presentation.Interfaces
{
    public interface IPresentationView
    {
        /// <summary>
        /// Контекст данных.
        /// </summary>
        object DataContext { get; set; }
    }
}