using System.ComponentModel;

namespace Fluid.Presentation.Interfaces
{
    public interface IPresentation : INotifyPropertyChanged
    {
        /// <summary>
        /// Контекст данных представления.
        /// </summary>
        IPresentationViewModel DataContext { get; }

        /// <summary>
        /// Представление.
        /// </summary>
        IPresentationView View { get; }

        /// <summary>
        /// Инициализация.
        /// </summary>
        void Initialize();
    }
}