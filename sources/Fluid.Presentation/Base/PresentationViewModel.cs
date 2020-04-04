using Fluid.Core.Base;
using Fluid.Presentation.Interfaces;

namespace Fluid.Presentation.Base
{
    /// <summary>
    /// Abstract presentation view model base class.
    /// </summary>
    public abstract class PresentationViewModel : ObservableObject, IPresentationViewModel
    {
        /// <inheritdoc />
        public abstract void Initialize();
    }
}