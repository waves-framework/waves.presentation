using System.ComponentModel;

namespace Fluid.Presentation.Interfaces
{
    /// <summary>
    /// Interface for presentations.
    /// </summary>
    public interface IPresentation : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets view model context.
        /// </summary>
        IPresentationViewModel DataContext { get; }

        /// <summary>
        /// Gets view.
        /// </summary>
        IPresentationView View { get; }

        /// <summary>
        /// Initializes presentation.
        /// </summary>
        void Initialize();
    }
}