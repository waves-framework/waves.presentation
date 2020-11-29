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
        ///     Event for message received handling.
        /// </summary>
        event EventHandler<IWavesMessage> MessageReceived;
        
        /// <summary>
        /// Get instance of core.
        /// </summary>
        IWavesCore Core { get; }
        
        /// <summary>
        /// Gets Id.
        /// </summary>
        Guid Id { get; }
        
        /// <summary>
        /// Gets view name.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     View model context.
        /// </summary>
        object DataContext { get; set; }

        /// <summary>
        /// Attaches core.
        /// </summary>
        /// <param name="core"></param>
        void AttachCore(IWavesCore core);
    }
}