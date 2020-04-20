using System;
using Fluid.Core.Base;
using Fluid.Core.Base.Interfaces;
using Fluid.Presentation.Interfaces;

namespace Fluid.Presentation.Base
{
    /// <summary>
    ///     Abstract presentation view model base class.
    /// </summary>
    public abstract class PresentationViewModel : ObservableObject, IPresentationViewModel
    {
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