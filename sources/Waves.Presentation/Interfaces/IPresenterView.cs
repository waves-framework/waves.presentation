using System;
using Waves.Core.Base.Interfaces;

namespace Waves.Presentation.Interfaces
{
    /// <summary>
    ///     Interface for presenter views.
    /// </summary>
    public interface IPresenterView
    {
        /// <summary>
        /// Gets Id.
        /// </summary>
        Guid Id { get; }
        
        /// <summary>
        /// Gets name.
        /// </summary>
        string Name { get; }
        
        /// <summary>
        ///     Event for message received handling.
        /// </summary>
        event EventHandler<IMessage> MessageReceived;

        /// <summary>
        ///     View model context.
        /// </summary>
        object DataContext { get; set; }
    }
}