using Fluid.Core.Base;
using Fluid.Presentation.Interfaces;

namespace Fluid.Presentation.Base
{
    public abstract class PresentationViewModel : ObservableObject, IPresentationViewModel
    {
        /// <inheritdoc />
        public abstract void Initialize();
    }
}