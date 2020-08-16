using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Waves.Core.Base;
using Waves.Core.Base.Interfaces;
using Waves.Presentation.Interfaces;

namespace Waves.Presentation.Base
{
    /// <summary>
    ///     Abstract presentation controller base class.
    /// </summary>
    public abstract class PresentationController : ObservableObject, IPresentationController
    {
        private IPresentation _selectedPresentation;

        private ICollection<IPresentation> _presentations = new ObservableCollection<IPresentation>();

        /// <inheritdoc />
        public event EventHandler<IMessage> MessageReceived;

        /// <inheritdoc />
        [Reactive]
        public virtual IPresentation SelectedPresentation
        {
            get => _selectedPresentation;
            set => this.RaiseAndSetIfChanged(ref _selectedPresentation, value);
        }

        /// <inheritdoc />
        [Reactive]
        public ICollection<IPresentation> Presentations
        {
            get => _presentations;
            protected set => this.RaiseAndSetIfChanged(ref _presentations, value);
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