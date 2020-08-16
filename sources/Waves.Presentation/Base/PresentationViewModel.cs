using System;
using ReactiveUI.Fody.Helpers;
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
        /// <inheritdoc />
        public event EventHandler<IMessage> MessageReceived;

        /// <summary>
        /// Gets whether view model is initialized.
        /// </summary>
        [Reactive]
        public virtual bool IsInitialized { get; protected set; }

        /// <inheritdoc />
        public abstract void Initialize();

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