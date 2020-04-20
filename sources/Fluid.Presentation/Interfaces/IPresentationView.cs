using System;
using Fluid.Core.Base.Interfaces;

namespace Fluid.Presentation.Interfaces
{
    /// <summary>
    ///     Interface for presentation views.
    /// </summary>
    public interface IPresentationView
    {
        /// <summary>
        ///     View model context.
        /// </summary>
        object DataContext { get; set; }

        /// <summary>
        ///     Event for message received handling.
        /// </summary>
        event EventHandler<IMessage> MessageReceived;
    }
}