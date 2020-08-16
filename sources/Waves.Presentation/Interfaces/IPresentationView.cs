﻿using System;
using Waves.Core.Base.Interfaces;

namespace Waves.Presentation.Interfaces
{
    /// <summary>
    ///     Interface for presentation views.
    /// </summary>
    public interface IPresentationView
    {
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