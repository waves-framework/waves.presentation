using System;
using Waves.Core.Base;
using Waves.Core.Base.Interfaces;
using Waves.Presentation.Interfaces;

namespace Waves.Presentation.Base
{
    /// <summary>
    ///     Abstract presentation view model base class.
    /// </summary>
    public abstract class PresentationViewModel : ObservableObject, IPresentationViewModel
    {
        /// <summary>
        /// Gets whether view model is initialized.
        /// </summary>
        public virtual bool IsInitialized { get; private set; }

        /// <inheritdoc />
        public abstract void Initialize();

        /// <inheritdoc />
        public event EventHandler<IMessage> MessageReceived;

        /// <summary>
        /// Notifies when message received.
        /// </summary>
        /// <param name="e">Message.</param>
        protected virtual void OnMessageReceived(IMessage e)
        {
            MessageReceived?.Invoke(this, e);
        }
    }
}