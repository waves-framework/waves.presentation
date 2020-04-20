using System;
using Fluid.Core.Base;
using Fluid.Core.Base.Interfaces;
using Fluid.Presentation.Interfaces;

namespace Fluid.Presentation.Base
{
    /// <summary>
    /// Abstract presentation base class.
    /// </summary>
    public abstract class Presentation : ObservableObject, IPresentation
    {
        /// <inheritdoc />
        public event EventHandler<IMessage> MessageReceived;

        /// <inheritdoc />
        public abstract IPresentationViewModel DataContext { get; }

        /// <inheritdoc />
        public abstract IPresentationView View { get; }

        /// <inheritdoc />
        public virtual void Initialize()
        {
            View.DataContext = DataContext;

            DataContext.MessageReceived += OnDataContextMessageReceived;
            View.MessageReceived += View_MessageReceived;

            DataContext.Initialize();
        }

        /// <summary>
        /// Notifies when message received.
        /// </summary>
        /// <param name="e">Message.</param>
        protected virtual void OnMessageReceived(IMessage e)
        {
            MessageReceived?.Invoke(this, e);
        }

        /// <summary>
        /// Actions when message received from data context.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDataContextMessageReceived(object sender, IMessage e)
        {
            OnMessageReceived(e);
        }

        /// <summary>
        /// Actions when message received from view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_MessageReceived(object sender, IMessage e)
        {
            OnMessageReceived(e);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            DataContext.MessageReceived -= OnDataContextMessageReceived;
            View.MessageReceived -= View_MessageReceived;
        }
    }
}
