using Fluid.Core.Base.Interfaces;

namespace Fluid.Presentation.Interfaces
{
    /// <summary>
    /// Interface for presentation view models.
    /// </summary>
    public interface IPresentationViewModel : IObservableObject
    {
        /// <summary>
        /// Initializes presentation view model.
        /// </summary>
        void Initialize();
    }
}