using Fluid.Core.Base.Interfaces;

namespace Fluid.Presentation.Interfaces
{
    public interface IPresentationViewModel : IObservableObject
    {
        /// <summary>
        /// Инициализация.
        /// </summary>
        void Initialize();
    }
}