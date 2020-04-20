using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Fluid.Core.Base;
using Fluid.Core.Base.Interfaces;
using Fluid.Presentation.Interfaces;

namespace Fluid.Presentation.Base
{
    /// <summary>
    ///     Abstract presentation controller base class.
    /// </summary>
    public abstract class PresentationController : ObservableObject, IPresentationController
    {
        private ICollection<IPresentation> _presentations =
            new ObservableCollection<IPresentation>();

        private IPresentation _selectedPresentation;

        /// <inheritdoc />
        public virtual IPresentation SelectedPresentation
        {
            get => _selectedPresentation;
            set
            {
                if (Equals(value, _selectedPresentation)) return;

                _selectedPresentation = value;
                OnPropertyChanged();
            }
        }

        /// <inheritdoc />
        public ICollection<IPresentation> Presentations
        {
            get => _presentations;
            private set
            {
                if (Equals(value, _presentations)) return;

                _presentations = value;
                OnPropertyChanged();
            }
        }

        /// <inheritdoc />
        public abstract void Initialize();

        /// <inheritdoc />
        public void RegisterPresentation(IPresentation presentation)
        {
            presentation.MessageReceived += OnPresentationMessageReceived;

            presentation.Initialize();

            Presentations.Add(presentation);
        }

        /// <inheritdoc />
        public void UnregisterPresentation(IPresentation presentation)
        {
            presentation.Dispose();

            presentation.MessageReceived -= OnPresentationMessageReceived;

            Presentations.Remove(presentation);
        }

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

        /// <summary>
        /// Actions when message received from presentation.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnPresentationMessageReceived(object sender, IMessage e)
        {
            OnMessageReceived(e);
        }
    }
}