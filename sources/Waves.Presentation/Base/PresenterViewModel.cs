using System;
using ReactiveUI.Fody.Helpers;
using Waves.Core.Base;
using Waves.Core.Base.Interfaces;
using Waves.Presentation.Interfaces;

namespace Waves.Presentation.Base
{
    /// <summary>
    ///     Abstract presenter view model base class.
    /// </summary>
    public abstract class PresenterViewModel : Waves.Core.Base.Object, IPresenterViewModel
    {
        /// <summary>
        /// Gets whether view model is initialized.
        /// </summary>
        [Reactive]
        public virtual bool IsInitialized { get; protected set; }

        /// <inheritdoc />
        public abstract void Initialize();
    }
}