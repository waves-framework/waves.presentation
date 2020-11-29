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
    public abstract class PresenterViewModel : Waves.Core.Base.WavesObject, IPresenterViewModel
    {
        /// <summary>
        /// Creates new instance of <see cref="PresenterViewModel"/>.
        /// </summary>
        /// <param name="core">Instance of core.</param>
        protected PresenterViewModel(IWavesCore core)
        {
            Core = core;
        }
        
        /// <inheritdoc />
        public IWavesCore Core { get; }
        
        /// <summary>
        /// Gets whether view model is initialized.
        /// </summary>
        [Reactive]
        public virtual bool IsInitialized { get; protected set; }

        /// <inheritdoc />
        public abstract void Initialize();
    }
}